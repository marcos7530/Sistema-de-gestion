namespace Servicio.Implementacion.Localidad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Localidad.DTOs;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class LocalidadServicio : ILocalidadServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public LocalidadServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(LocalidadDto entidad)
        {
            var entidadId = _unidadDeTrabajo.LocalidadRepositorio.Insertar(new Dominio.Entidades.Localidad
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion,
                ProvinciaId = entidad.ProvinciaId
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.LocalidadRepositorio.Obtener(id);

            _unidadDeTrabajo.LocalidadRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<LocalidadDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Localidad, bool>> filtro = localidad =>
                !localidad.EstaEliminado && localidad.Descripcion.Contains(cadenaBuscar)
                || localidad.Provincia.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.LocalidadRepositorio.Obtener(filtro,"Provincia");

            return resultado.Select(x => new LocalidadDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ProvinciaId = x.ProvinciaId,
                Provincia = x.Provincia.Descripcion,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public IEnumerable<LocalidadDto> Get(long provinciaId)
        {
            Expression<Func<Dominio.Entidades.Localidad, bool>> filtro = Localidad =>
                !Localidad.EstaEliminado && Localidad.ProvinciaId == provinciaId;

            var resultado = _unidadDeTrabajo.LocalidadRepositorio.Obtener(filtro, "Provincia");

            return resultado.Select(x => new LocalidadDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ProvinciaId = x.ProvinciaId,
                Provincia = x.Provincia.Descripcion,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public LocalidadDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.LocalidadRepositorio.Obtener(id);

            return new LocalidadDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(LocalidadDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.LocalidadRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.ProvinciaId = entidad.ProvinciaId;

            _unidadDeTrabajo.LocalidadRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
