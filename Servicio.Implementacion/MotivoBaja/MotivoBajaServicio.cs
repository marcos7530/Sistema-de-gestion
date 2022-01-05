namespace Servicio.Implementacion.MotivoBaja
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.MotivoBaja;
    using Servicio.Interfaces.MotivoBaja.DTOs;

    public class MotivoBajaServicio: IMotivoBajaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public MotivoBajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(MotivoBajaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.MotivoBajaRepositorio.Insertar(new Dominio.Entidades.MotivoBaja
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
            var entidad = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(id);

            _unidadDeTrabajo.MotivoBajaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<MotivoBajaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.MotivoBaja, bool>> filtro = MotivoBaja =>
                MotivoBaja.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(filtro);

            return resultado.Select(x => new MotivoBajaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public MotivoBajaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(id);

            return new MotivoBajaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(MotivoBajaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.MotivoBajaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.MotivoBajaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
