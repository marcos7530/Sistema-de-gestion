using System.Linq;

namespace Servicio.Implementacion.PerfilFormulario
{
    using System;
    using System.Transactions;
    using System.Collections.Generic;
    using Servicio.Interfaces.PerfilFormulario;
    using Servicio.Interfaces.PerfilFormulario.DTOs;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class PerfilFormularioServicio : IPerfilFormularioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public PerfilFormularioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void AsignarFormulario(long perfilId, List<PerfilFormularioDto> formularios)
        {
            using (var tran  = new TransactionScope())
            {
                try
                {
                    var perfil = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Formularios");

                    if(perfil == null)
                        throw new Exception("Ocurrió un error al Obtener el Perfil");

                    foreach (var formulario in formularios)
                    {
                        var formularioAsignar = _unidadDeTrabajo.FormularioRepositorio.Obtener(formulario.FormularioId);

                        if(formularioAsignar == null)
                            throw new Exception("Ocurrió un error al obtener el Formulario");

                        perfil.Formularios.Add(formularioAsignar);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrió un error al Asignar los formularios a un perfil.");
                }
            }
        }

        public IEnumerable<PerfilFormularioDto> ObtenerFormulariosAsignados(long perfilId, string cadenaBuscar)
        {
            var formularios = _unidadDeTrabajo.PerfilRepositorio
                .Obtener(perfilId, "Formularios").Formularios;

            return formularios
                .Where(x => !x.EstaEliminado &&
                            (x.Nombre.Contains(cadenaBuscar) 
                             || x.NombreCompleto.Contains(cadenaBuscar)))
                .Select(x => new PerfilFormularioDto
                {
                    Nombre = x.Nombre,
                    Codigo = x.Codigo,
                    NombreCompleto = x.NombreCompleto,
                    Item = false,
                    FormularioId = x.Id
                }).ToList();
        }

        public IEnumerable<PerfilFormularioDto> ObtenerFormulariosNoAsignados(long perfilId, string cadenaBuscar)
        {
            var resultado = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Formularios").Formularios;

            var formulariosAsignados = resultado
                .Where(x => !x.EstaEliminado &&
                            (x.Nombre.Contains(cadenaBuscar) 
                             || x.NombreCompleto.Contains(cadenaBuscar)))
                .Select(x => new PerfilFormularioDto
                {
                    Nombre = x.Nombre,
                    Codigo = x.Codigo,
                    NombreCompleto = x.NombreCompleto,
                    Item = false,
                    FormularioId = x.Id
                }).ToList();

            var formularios = _unidadDeTrabajo.FormularioRepositorio
                .Obtener(x=>!x.EstaEliminado)
                .Select(x => new PerfilFormularioDto
            {
                Nombre = x.Nombre,
                Codigo = x.Codigo,
                NombreCompleto = x.NombreCompleto,
                Item = false,
                FormularioId = x.Id
            }).ToList();

            return formularios
                .Except(formulariosAsignados, new FormularioComparer())
                .ToList();
        }

        public void QuitarFormulario(long perfilId, List<PerfilFormularioDto> formularios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var perfil = _unidadDeTrabajo.PerfilRepositorio.Obtener(perfilId, "Formularios");

                    if (perfil == null)
                        throw new Exception("Ocurrió un error al Obtener el Perfil");

                    foreach (var formulario in formularios)
                    {
                        var formularioAsignar = _unidadDeTrabajo.FormularioRepositorio.Obtener(formulario.FormularioId);

                        if (formularioAsignar == null)
                            throw new Exception("Ocurrió un error al obtener el Formulario");

                        perfil.Formularios.Remove(formularioAsignar);
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception("Ocurrió un error al Asignar los formularios a un perfil.");
                }
            }
        }
    }
}
