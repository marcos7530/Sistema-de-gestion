using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Base;
using Servicio.Interfaces.ConceptoGasto;
using Servicio.Interfaces.ConceptoGasto.DTOs;
using Servicio.Interfaces.Tarjeta.DTOs;

namespace Servicio.Implementacion.ConceptoGasto
{
    public class ConceptoGastoServicio : IConceptoGastoServicio
    {

        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ConceptoGastoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(ConceptoGastoDto entidad)
        {
            var entidadId = _unidadDeTrabajo.ConceptoGastoRepositorio.Insertar(new Dominio.Entidades.ConceptoGasto()
                {
                    EstaEliminado = false,
                    /*======================================================*/
                    Descripcion = entidad.Descripcion
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.TarjetaRepositorio.Obtener(id);

            _unidadDeTrabajo.TarjetaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ConceptoGastoDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.ConceptoGasto, bool>> filtro = t =>
                !t.EstaEliminado && t.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.ConceptoGastoRepositorio.Obtener(filtro);

            return resultado.Select(x => new ConceptoGastoDto()
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*==========================================*/
                Descripcion = x.Descripcion,
                /*==========================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }

        public ConceptoGastoDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.ConceptoGastoRepositorio.Obtener(id);

            return new ConceptoGastoDto()
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(ConceptoGastoDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ConceptoGastoRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.ConceptoGastoRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
