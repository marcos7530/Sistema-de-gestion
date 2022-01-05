namespace Servicio.Implementacion.DetalleArticuloCompuesto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.DetalleArticuloCompuesto;
    using Servicio.Interfaces.DetalleArticuloCompuesto.DTOs;

    public class DetalleArticuloCompuestoServicio : IDetalleArticuloCompuestoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DetalleArticuloCompuestoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(DetalleArticuloCompuestoDto entidad)
        {
            var entidadId = _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Insertar(new Dominio.Entidades.DetalleArticuloCompuesto
            {
                EstaEliminado = false,
                ArticuloHijoId = entidad.ArticuloHijoId,
                ArticuloPadreId = entidad.ArticuloPadreId,
                Cantidad = entidad.Cantidad
            });

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Obtener(id);

            _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<DetalleArticuloCompuestoDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.DetalleArticuloCompuesto, bool>> filtro = x =>
                x.ArticuloHijo.Descripcion.Contains(cadenaBuscar)
                || x.ArticuloPadre.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Obtener(filtro, "Articulo");

            return resultado.Select(x => new DetalleArticuloCompuestoDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ArticuloHijoId = x.ArticuloHijoId,
                ArticuloHijo = x.ArticuloHijo.Descripcion,
                ArticuloPadreId = x.ArticuloPadreId,
                ArticuloPadre = x.ArticuloPadre.Descripcion,
                Cantidad = x.Cantidad,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public DetalleArticuloCompuestoDto GetById(long id)
        {
            var x = _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Obtener(id, "Articulo");

            return new DetalleArticuloCompuestoDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ArticuloHijoId = x.ArticuloHijoId,
                ArticuloHijo = x.ArticuloHijo.Descripcion,
                ArticuloPadreId = x.ArticuloPadreId,
                ArticuloPadre = x.ArticuloPadre.Descripcion,
                Cantidad = x.Cantidad,
                RowVersion = x.RowVersion
            };
        }

        public void Update(DetalleArticuloCompuestoDto entidad)
        {
            var e = _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Obtener(entidad.Id);

            e.ArticuloHijoId = entidad.ArticuloHijoId;
            e.ArticuloPadreId = entidad.ArticuloPadreId;
            e.Cantidad = entidad.Cantidad;

            _unidadDeTrabajo.DetalleArticuloCompuestoRepositorio.Modificar(e);

            _unidadDeTrabajo.Commit();

        }
    }
}
