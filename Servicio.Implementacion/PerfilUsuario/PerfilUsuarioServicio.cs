namespace Servicio.Implementacion.PerfilUsuario
{
    using System;
    using System.Linq;
    using System.Transactions;
    using System.Collections.Generic;
    using Servicio.Interfaces.PerfilUsuario;
    using Servicio.Interfaces.PerfilUsuario.DTOs;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class PerfilUsuarioServicio : IPerfilUsuarioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public PerfilUsuarioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void AsignarUsuario(long perfilId, List<PerfilUsuarioDto> usuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Usuarios");

                    if (perfil == null)
                        throw new Exception("Ocurrió un error al Obtener el Perfil");

                    foreach (var usuario in usuarios)
                    {
                        var usuarioAsignar = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuario.UsuarioId);

                        if (usuarioAsignar == null)
                            throw new Exception("Ocurrió un error al obtener el Usuario");

                        perfil.Usuarios.Add(usuarioAsignar);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Ocurrió un error al Asignar los Usuarios a un perfil.");
                }
            }
        }

        public IEnumerable<PerfilUsuarioDto> ObtenerUsuariosAsignados(long perfilId, string cadenaBuscar)
        {
            var usuarios = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Usuarios, Usuarios.Empleado").Usuarios;

            return usuarios
                .Where(x => !x.EstaEliminado && (x.Nombre.Contains(cadenaBuscar) 
                                                || x.Empleado.Apellido.Contains(cadenaBuscar) 
                                                || x.Empleado.Nombre.Contains(cadenaBuscar)))
                .Select(x => new PerfilUsuarioDto
                {
                    Usuario = x.Nombre,
                    UsuarioId = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    Nombre = x.Empleado.Nombre,
                    Apellido = x.Empleado.Apellido
                }).ToList();
        }

        public IEnumerable<PerfilUsuarioDto> ObtenerUsuariosNoAsignados(long perfilId, string cadenaBuscar)
        {
            var resultado = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Usuarios, Usuarios.Empleado").Usuarios;

            var usuariosAsignados = resultado
                .Where(x => !x.EstaEliminado && (x.Nombre.Contains(cadenaBuscar)
                                                || x.Empleado.Apellido.Contains(cadenaBuscar)
                                                || x.Empleado.Nombre.Contains(cadenaBuscar)))
                .Select(x => new PerfilUsuarioDto
                {
                    Usuario = x.Nombre,
                    UsuarioId = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    Nombre = x.Empleado.Nombre,
                    Apellido = x.Empleado.Apellido
                }).ToList();

            var usuarios = _unidadDeTrabajo.UsuarioRepositorio.Obtener(x=>!x.EstaEliminado, "Empleado")
                .Select(x => new PerfilUsuarioDto
                {
                    Usuario = x.Nombre,
                    UsuarioId = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    Nombre = x.Empleado.Nombre,
                    Apellido = x.Empleado.Apellido
                }).ToList();

            return usuarios.Except(usuariosAsignados, new UsuarioComparer()).ToList();
        }

        public void QuitarUsuario(long perfilId, List<PerfilUsuarioDto> usuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId);

                    if (perfil == null)
                        throw new Exception("Ocurrió un error al Obtener el Perfil");

                    foreach (var usuario in usuarios)
                    {
                        var usuarioAsignar = _unidadDeTrabajo.UsuarioRepositorio.Obtener(usuario.UsuarioId);

                        if (usuarioAsignar == null)
                            throw new Exception("Ocurrió un error al obtener el Usuario");

                        perfil.Usuarios.Remove(usuarioAsignar);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Ocurrió un error al Asignar los usuarios a un perfil.");
                }
            }
        }
    }
}
