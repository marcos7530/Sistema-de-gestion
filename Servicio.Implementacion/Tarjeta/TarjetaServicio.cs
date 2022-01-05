using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Tarjeta;
using Servicio.Interfaces.Tarjeta.DTOs;

namespace Servicio.Implementacion.Tarjeta
{
    
    public class TarjetaServicio : ITarjetaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public TarjetaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(TarjetaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.TarjetaRepositorio.Insertar(new Dominio.Entidades.Tarjeta
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
            var entidad = _unidadDeTrabajo.TarjetaRepositorio.Obtener(id);

            _unidadDeTrabajo.TarjetaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<TarjetaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Tarjeta, bool>> filtro = t =>
                !t.EstaEliminado && t.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.TarjetaRepositorio.Obtener(filtro);

            return resultado.Select(x => new TarjetaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public TarjetaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.TarjetaRepositorio.Obtener(id);

            return new TarjetaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(TarjetaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.TarjetaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.TarjetaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
