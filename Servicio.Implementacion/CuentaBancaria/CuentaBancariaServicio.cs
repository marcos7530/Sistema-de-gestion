using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades.MetaData;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Banco;
using Servicio.Interfaces.CuentaBancaria;
using Servicio.Interfaces.CuentaBancaria.DTOs;
using StructureMap;

namespace Servicio.Implementacion.CuentaBancaria
{
    public class CuentaBancariaServicio : ICuentaBancariaServicio
    {

        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public CuentaBancariaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(CuentaBancariaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.CuentaBancariaRepositorio.Insertar(new Dominio.Entidades.CuentaBancaria()
            {
                EstaEliminado = false,
                
                BancoId = entidad.BancoId,
                Numero = entidad.Numero,
                Titular = entidad.Titular
            }
           );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.CuentaBancariaRepositorio.Obtener(id);

            _unidadDeTrabajo.CuentaBancariaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<CuentaBancariaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.CuentaBancaria, bool>> filtro = t =>
                !t.EstaEliminado&& t.Titular.Contains(cadenaBuscar);

            var resultado = 
                _unidadDeTrabajo.CuentaBancariaRepositorio.Obtener(filtro,"Banco");

            return resultado.Select(x => new CuentaBancariaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                BancoId = x.BancoId,
                Banco = x.Banco.Descripcion,
                Numero = x.Numero,
                Titular = x.Titular,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }

        public CuentaBancariaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.CuentaBancariaRepositorio.Obtener(id);

            return new CuentaBancariaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                /*=====================================================*/
                BancoId = resultado.BancoId,
                Banco = resultado.Banco.Descripcion,
                Numero = resultado.Numero,
                Titular = resultado.Titular,
                /*======================================================*/
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(CuentaBancariaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.CuentaBancariaRepositorio.Obtener(entidad.Id);

            entidadModificar.BancoId = entidad.BancoId;
            entidadModificar.Numero = entidad.Numero;
            entidadModificar.Titular = entidad.Titular;

            _unidadDeTrabajo.CuentaBancariaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
