namespace Servicio.Implementacion.Iva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.Iva.DTOs;

    public class IvaServicio: IIvaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public IvaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(IvaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.IvaRepositorio.Insertar(new Dominio.Entidades.Iva
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion,
                Porcentaje = entidad.Porcentaje
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.IvaRepositorio.Obtener(id);

            _unidadDeTrabajo.IvaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<IvaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Iva, bool>> filtro = i =>
                !i.EstaEliminado && i.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.IvaRepositorio.Obtener(filtro);

            return resultado.Select(x => new IvaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                Porcentaje = x.Porcentaje,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public IvaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.IvaRepositorio.Obtener(id);

            return new IvaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                Porcentaje = resultado.Porcentaje,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(IvaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.IvaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.Porcentaje = entidad.Porcentaje;

            _unidadDeTrabajo.IvaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
