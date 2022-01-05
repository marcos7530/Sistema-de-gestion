namespace Servicio.Implementacion.ListaPrecio
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ListaPrecioServicio: IListaPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ListaPrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public long Add(ListaPrecioDto entidad)
        {
            var entidadId = _unidadDeTrabajo.ListaPrecioRepositorio.Insertar(new Dominio.Entidades.ListaPrecio
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion,
                PorcentajeGanancia = entidad.PorcentajeGanancia,
                NecesitaAutorizacion = entidad.NecesitaAutorizacion
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            _unidadDeTrabajo.ListaPrecioRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ListaPrecioDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.ListaPrecio, bool>> filtro = l =>
                !l.EstaEliminado &&
                l.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(filtro);

            return resultado.Select(x => new ListaPrecioDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                PorcentajeGanancia = x.PorcentajeGanancia,
                NecesitaAutorizacion = x.NecesitaAutorizacion,         
                RowVersion = x.RowVersion
            }).ToList();
        }

        public ListaPrecioDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            return new ListaPrecioDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                PorcentajeGanancia = resultado.PorcentajeGanancia,
                NecesitaAutorizacion = resultado.NecesitaAutorizacion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(ListaPrecioDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.PorcentajeGanancia = entidad.PorcentajeGanancia;
            entidadModificar.NecesitaAutorizacion = entidad.NecesitaAutorizacion;

            _unidadDeTrabajo.ListaPrecioRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }

    }
}
