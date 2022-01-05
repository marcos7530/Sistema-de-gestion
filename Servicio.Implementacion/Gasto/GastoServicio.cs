using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Gastos;
using Servicio.Interfaces.Gastos.DTOs;
using Servicio.Interfaces.Tarjeta.DTOs;

namespace Servicio.Implementacion.Gasto
{
    public class GastoServicio : IGastoServicio
    {

        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public GastoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public long Add(GastoDto entidad)
        {
            var entidadId = _unidadDeTrabajo.GastoRepositorio.Insertar(new Dominio.Entidades.Gasto()
                {
                    EstaEliminado = false,
                    ConceptoGastoId = entidad.ConceptoGastoId,
                    Fecha = entidad.Fecha,
                    Descripcion = entidad.Descripcion,
                    Monto = entidad.Monto
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.GastoRepositorio.Obtener(id);

            _unidadDeTrabajo.GastoRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<GastoDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Gasto, bool>> filtro = t =>
                !t.EstaEliminado &&t.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.GastoRepositorio.Obtener(filtro);

            return resultado.Select(x => new GastoDto
            {
                 Id= x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ConceptoGastoId = x.ConceptoGastoId,
                Fecha = x.Fecha,
                Descripcion = x.Descripcion,
                Monto = x.Monto,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }

        public IEnumerable<GastoDto> GetPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            Expression<Func<Dominio.Entidades.Gasto, bool>> filtro = t =>
                !t.EstaEliminado && (fechaDesde <= t.Fecha && t.Fecha <= fechaHasta);

            var resultado = _unidadDeTrabajo.GastoRepositorio.Obtener(filtro);

            return resultado.Select(x => new GastoDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ConceptoGastoId = x.ConceptoGastoId,
                Fecha = x.Fecha,
                Descripcion = x.Descripcion,
                Monto = x.Monto,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }

        public GastoDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.GastoRepositorio.Obtener(id);

            return new GastoDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                /*=====================================================*/
                ConceptoGastoId = resultado.ConceptoGastoId,
                Fecha = resultado.Fecha,
                Descripcion = resultado.Descripcion,
                Monto = resultado.Monto,
                /*======================================================*/
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(GastoDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.GastoRepositorio.Obtener(entidad.Id);

            entidadModificar.ConceptoGastoId = entidad.ConceptoGastoId;
            entidadModificar.Fecha = entidad.Fecha;
            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.Monto = entidad.Monto;

            _unidadDeTrabajo.GastoRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
