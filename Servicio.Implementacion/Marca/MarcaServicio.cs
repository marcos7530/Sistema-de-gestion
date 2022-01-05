namespace Servicio.Implementacion.Marca
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Marca.DTOs;

    public class MarcaServicio: IMarcaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public MarcaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(MarcaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.MarcaRepositorio.Insertar(new Dominio.Entidades.Marca
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
            var entidad = _unidadDeTrabajo.MarcaRepositorio.Obtener(id);

            _unidadDeTrabajo.MarcaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<MarcaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Marca, bool>> filtro = marca =>
                !marca.EstaEliminado && marca.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.MarcaRepositorio.Obtener(filtro);

            return resultado.Select(x => new MarcaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public MarcaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.MarcaRepositorio.Obtener(id);

            return new MarcaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(MarcaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.MarcaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.MarcaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
