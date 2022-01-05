namespace Servicio.Implementacion.Provincia
{
    using Servicio.Interfaces.Provincia;
    using Servicio.Interfaces.Provincia.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ProvinciaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long AddProvincia(ProvinciaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.ProvinciaRepositorio.Insertar(new Dominio.Entidades.Provincia
                {
                    EstaEliminado = false,
                    Descripcion = entidad.Descripcion
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void DeleteProvincia(long id)
        {
            var entidad = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(id);

            _unidadDeTrabajo.ProvinciaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ProvinciaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Provincia, bool>> filtro = provincia =>
                !provincia.EstaEliminado && provincia.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(filtro);

            return resultado.Select(x => new ProvinciaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public ProvinciaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(id);

            return new ProvinciaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void UpdateProvincia(ProvinciaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ProvinciaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.ProvinciaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
