using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.BajaArticulo;
using Servicio.Interfaces.BajaArticulo.DTOs;

namespace Servicio.Implementacion.BajaArticulo
{
    public class BajaArticuloServicio: IBajaArticuloServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public BajaArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(BajaArticuloDto entidad)
        {
            var entidadId = _unidadDeTrabajo.BajaArticuloRepositorio.Insertar(new Dominio.Entidades.BajaArticulo
            {
                EstaEliminado = false,
                ArticuloId = entidad.ArticuloId,
                MotivoBajaId = entidad.MotivoBajaId,
                Cantidad = entidad.Cantidad,
                Fecha = entidad.Fecha,
                Observacion = entidad.Observacion
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(id);

            _unidadDeTrabajo.BajaArticuloRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<BajaArticuloDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.BajaArticulo, bool>> filtro = x =>
                !x.EstaEliminado && x.Articulo.Descripcion.Contains(cadenaBuscar)
                || x.MotivoBaja.Descripcion.Contains(cadenaBuscar)
                || x.Observacion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(filtro, "Articulo, MotivoBaja");

            return resultado.Select(x => new BajaArticuloDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ArticuloId = x.ArticuloId,
                Articulo = x.Articulo.Descripcion,
                MotivoBajaId = x.MotivoBajaId,
                MotivoBaja = x.MotivoBaja.Descripcion,
                Cantidad = x.Cantidad,
                Fecha = x.Fecha,
                Observacion = x.Observacion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public BajaArticuloDto GetById(long id)
        {
            var x = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(id, "Articulo, MotivoBaja");

            return new BajaArticuloDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ArticuloId = x.ArticuloId,
                Articulo = x.Articulo.Descripcion,
                MotivoBajaId = x.MotivoBajaId,
                MotivoBaja = x.MotivoBaja.Descripcion,
                Cantidad = x.Cantidad,
                Fecha = x.Fecha,
                Observacion = x.Observacion,
                RowVersion = x.RowVersion
            };
        }

        public void Update(BajaArticuloDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.BajaArticuloRepositorio.Obtener(entidad.Id);

            entidadModificar.ArticuloId = entidad.ArticuloId;
            entidadModificar.MotivoBajaId = entidad.MotivoBajaId;
            entidadModificar.Cantidad = entidad.Cantidad;
            entidadModificar.Observacion = entidad.Observacion;

            _unidadDeTrabajo.BajaArticuloRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
