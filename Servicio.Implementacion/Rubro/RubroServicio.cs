namespace Servicio.Implementacion.Rubro
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.Rubro.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class RubroServicio: IRubroServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public RubroServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(RubroDto entidad)
        {
            var entidadId = _unidadDeTrabajo.RubroRepositorio.Insertar(new Dominio.Entidades.Rubro
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.RubroRepositorio.Obtener(id);

            _unidadDeTrabajo.RubroRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<RubroDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Rubro, bool>> filtro = r =>
                !r.EstaEliminado && r.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.RubroRepositorio.Obtener(filtro);

            return resultado.Select(x => new RubroDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public RubroDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.RubroRepositorio.Obtener(id);

            return new RubroDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(RubroDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.RubroRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.RubroRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
