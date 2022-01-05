namespace Servicio.Implementacion.Formulario
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.Linq.Expressions;
    using StructureMap;
    using Dominio.Base;
    using Servicio.Interfaces.Formulario;
    using Servicio.Interfaces.Formulario.DTOs;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class FormularioServicio : IFormularioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public FormularioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Add(List<FormularioDto> formularios)
        {
            try
            {
                foreach (var formularioDto in formularios)
                {
                    _unidadDeTrabajo.FormularioRepositorio.Insertar(new Dominio.Entidades.Formulario
                    {
                        EstaEliminado = false,
                        Codigo = formularioDto.Codigo,
                        Nombre = formularioDto.Nombre,
                        NombreCompleto = formularioDto.NombreCompleto
                    });
                }

                _unidadDeTrabajo.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al grabar los formularios");
            }
        }

        public IEnumerable<FormularioDto> Get(string cadenaBuscar, List<Type> TypesAssemblies)
        {
            var listadoFormularios = new List<FormularioDto>();
            var formulariosBaseDatos = _unidadDeTrabajo.FormularioRepositorio.Obtener();

            foreach (var type in TypesAssemblies)
            {
                if (!type.Name[0].ToString().Equals("_")) continue;

                var formulario = ObjectFactory.GetInstance<FormularioDto>();

                int codigoFormulario = 0;

                if (!int.TryParse(type.Name.Substring(1, 5), out codigoFormulario)) continue;

                formulario.Codigo = codigoFormulario;
                formulario.Nombre = type.Name.Substring(7, type.Name.Length - 7);
                formulario.NombreCompleto = type.Name;
                formulario.ExisteBaseDatos = formulariosBaseDatos != null && formulariosBaseDatos.Any()
                    ? formulariosBaseDatos.Any(x => x.NombreCompleto == type.Name)
                    : false;

                listadoFormularios.Add(formulario);
            }

            return listadoFormularios
                .Where(x => x.Nombre.Contains(cadenaBuscar)
                            || x.NombreCompleto.Contains(cadenaBuscar))
                .OrderBy(x => x.Codigo)
                .ToList();
        }


        public FormularioDto GetByName(string nombreFormulario)
        {
            Expression<Func<Dominio.Entidades.Formulario, bool>> filtro = formulario =>
                formulario.NombreCompleto == nombreFormulario || formulario.Nombre == nombreFormulario;

            return _unidadDeTrabajo.FormularioRepositorio.Obtener(filtro)
                .Select(x => new FormularioDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    RowVersion = x.RowVersion,
                    Nombre = x.Nombre,
                    Codigo = x.Codigo,
                    NombreCompleto = x.NombreCompleto,
                }).FirstOrDefault();
        }
    }
}
