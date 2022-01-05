namespace Servicio.Implementacion.UnidadMedida
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.UnidadMedida;
    using Servicio.Interfaces.UnidadMedida.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class UnidadMedidaServicio: IUnidadMedidaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public UnidadMedidaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(UnidadMedidaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.UnidadMedidaRepositorio.Insertar(new Dominio.Entidades.UnidadMedida
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
            var entidad = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(id);

            _unidadDeTrabajo.UnidadMedidaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<UnidadMedidaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.UnidadMedida, bool>> filtro = u =>
                !u.EstaEliminado && u.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(filtro);

            return resultado.Select(x => new UnidadMedidaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public UnidadMedidaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(id);

            return new UnidadMedidaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(UnidadMedidaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.UnidadMedidaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
