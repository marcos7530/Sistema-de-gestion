namespace Servicio.Implementacion.Banco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Banco;
    using Servicio.Interfaces.Banco.DTOs;

    public class BancoServicio : IBancoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public BancoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(BancoDto entidad)
        {
            var entidadId = _unidadDeTrabajo.BancoRepositorio.Insertar(new Dominio.Entidades.Banco
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
            var entidad = _unidadDeTrabajo.BancoRepositorio.Obtener(id);

            _unidadDeTrabajo.BancoRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<BancoDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Banco, bool>> filtro = Banco =>
                !Banco.EstaEliminado && Banco.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.BancoRepositorio.Obtener(filtro);

            return resultado.Select(x => new BancoDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public BancoDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.BancoRepositorio.Obtener(id);

            return new BancoDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(BancoDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.BancoRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.BancoRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
