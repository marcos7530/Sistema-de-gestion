namespace Servicio.Implementacion.Perfil
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Base;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.Perfil.DTOs;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class PerfilServicio : IPerfilServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public PerfilServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(PerfilDto entidad)
        {
            var entidadId = _unidadDeTrabajo.PerfilRepositorio.Insertar(new Dominio.Entidades.Perfil
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion
            });

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.PerfilRepositorio.Obtener(id);

            _unidadDeTrabajo.PerfilRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<PerfilDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Perfil, bool>> filtro = perfil =>
                !perfil.EstaEliminado && perfil.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.PerfilRepositorio.Obtener(filtro);

            return resultado.Select(x => new PerfilDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public PerfilDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.PerfilRepositorio.Obtener(id);

            return new PerfilDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(PerfilDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.PerfilRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.PerfilRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
