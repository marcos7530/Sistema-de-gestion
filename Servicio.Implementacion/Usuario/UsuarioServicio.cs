namespace Servicio.Implementacion.Usuario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Servicio.Interfaces.Usuario;
    using Servicio.Interfaces.Usuario.DTOs;
    using static Aplicacion.Constantes.Clases.Password;
    using System.Transactions;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        
        public void Add(List<UsuarioDto> empleados)
        {
            using (var tran  = new TransactionScope())
            {
                try
                {
                    foreach (var emple in empleados)
                    {
                        _unidadDeTrabajo.UsuarioRepositorio.Insertar(new Dominio.Entidades.Usuario
                        {
                            Nombre = ObtenerNombreUsuario(emple.ApellidoEmpleado, emple.NombreEmpleado),
                            EstaBloqueado = false,
                            EstaEliminado = false,
                            Password = Encriptar($"P$assword"),
                            EmpleadoId = emple.EmpleadoId
                        });
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    throw new Exception("Ocurrio un error al Crear los Usuarios");
                }
            }
        }

        public void BloquearDesbloquear(List<UsuarioDto> usuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var usuario in usuarios)
                    {
                        var usuarioBloquear = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuario.Id);

                        if (usuarioBloquear == null)
                            throw new Exception(
                                $"Ocurrió un error al Bloquear/Desbloquear el Usuario: {usuario.ApyNom}");

                        usuarioBloquear.EstaBloqueado = !usuarioBloquear.EstaBloqueado;

                        _unidadDeTrabajo.UsuarioRepositorio.Modificar(usuarioBloquear);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    throw new Exception("Ocurrio un error al Crear los Usuarios");
                }
            }
        }
        
        public void ResetearPassword(List<UsuarioDto> usuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var usuario in usuarios)
                    {
                        var usuarioBloquear = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuario.Id);

                        if (usuarioBloquear == null)
                            throw new Exception(
                                $"Ocurrió un error al Resetear el Usuario: {usuario.ApyNom}");

                        usuarioBloquear.Password = Encriptar($"P$assword");

                        _unidadDeTrabajo.UsuarioRepositorio.Modificar(usuarioBloquear);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();

                    throw new Exception("Ocurrio un error al Crear los Usuarios");
                }
            }
        }

        public IEnumerable<UsuarioDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Empleado, bool>> filtro = x =>
                x.Apellido.Contains(cadenaBuscar)
                || x.Nombre.Contains(cadenaBuscar)
                || x.Dni == cadenaBuscar;

            return _unidadDeTrabajo.EmpleadoRepositorio.Obtener(filtro, "Usuarios")
                .Select(x => new UsuarioDto
                {
                    Id = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Id : -1,
                    EstaBloqueado = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().EstaBloqueado : false,
                    Nombre = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Nombre : "NO REGISTRADO",
                    Password = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Password : string.Empty,
                    EstaEliminado = x.EstaEliminado,
                    RowVersion = x.RowVersion,
                    NombreEmpleado = x.Nombre,
                    ApellidoEmpleado = x.Apellido,
                    EmpleadoId = x.Id
                }).OrderBy(x => x.ApellidoEmpleado).ThenBy(x => x.NombreEmpleado)
                .ToList();
        }

        public UsuarioDto GetByUser(string nombreUsuario)
        {
            Expression<Func<Dominio.Entidades.Usuario, bool>> filtro = x =>
                !x.EstaEliminado && x.Nombre == nombreUsuario;

            return _unidadDeTrabajo.UsuarioRepositorio.Obtener(filtro, "Empleado")
                .Select(x => new UsuarioDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Password = x.Password,
                    EstaEliminado = x.EstaEliminado,
                    RowVersion = x.RowVersion,
                    EstaBloqueado = x.EstaBloqueado,
                    NombreEmpleado = x.Empleado.Nombre,
                    ApellidoEmpleado = x.Empleado.Apellido,
                    FotoEmpleado = x.Empleado.Foto,
                    EmpleadoId = x.EmpleadoId
                }).OrderBy(x => x.ApellidoEmpleado).ThenBy(x => x.NombreEmpleado)
                .FirstOrDefault();
        }

        // ================================================================ //
        // =============           Metodos Privados          ============== //
        // ================================================================ //

        private string ObtenerNombreUsuario(string apellido, string nombre)
        {
            int contadorLetras = 1;

            var nombreUsuario = $"{nombre.Trim().ToLower().Substring(0, contadorLetras)}{apellido.Trim().ToLower()}";

            Expression<Func<Dominio.Entidades.Usuario, bool>> filtro = usuario =>
                usuario.Nombre == nombreUsuario;

            while (_unidadDeTrabajo.UsuarioRepositorio.Obtener(filtro).Any())
            {
                contadorLetras++;

                nombreUsuario = $"{nombre.Trim().ToLower().Substring(0, contadorLetras)}{apellido.Trim().ToLower()}";
            }

            return nombreUsuario;
        }
    }
}
