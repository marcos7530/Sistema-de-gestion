using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.CuentaBancaria.DTOs;
using Servicio.Interfaces.DepositoCheque;
using Servicio.Interfaces.DepositoCheque.DTOs;

namespace Servicio.Implementacion.DepositoCheqque
{
    public class DepositoChequeServicio : IDepositoChequeServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DepositoChequeServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(DepositoChequeDto entidad)
        {
            var entidadId = _unidadDeTrabajo.DepositoChequeRepositorio.Insertar(new Dominio.Entidades.DepositoCheque()
                {
                    EstaEliminado = false,
                    /*=====================================*/
                    ChequeId= entidad.ChequeId,
                    CuentaBancariaId = entidad.CuentaBancariaId,
                    Fecha = entidad.Fecha
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.DepositoChequeRepositorio.Obtener(id);

            _unidadDeTrabajo.DepositoChequeRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<DepositoChequeDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.DepositoCheque, bool>> filtro = t =>
                !t.EstaEliminado;

            var resultado = _unidadDeTrabajo.DepositoChequeRepositorio.Obtener(filtro, "Cheque, CuentaBancaria");

            return resultado.Select(x => new DepositoChequeDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ///*===============================================*/
              ChequeId = x.ChequeId,
              CuentaBancariaId = x.CuentaBancariaId,
              Fecha = x.Fecha,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }

        public DepositoChequeDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.DepositoChequeRepositorio.Obtener(id);

            return new DepositoChequeDto()
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                /*========================================*/
                ChequeId = resultado.ChequeId,
                CuentaBancariaId = resultado.CuentaBancariaId,
                Fecha = resultado.Fecha,
                /*========================================*/
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(DepositoChequeDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.DepositoChequeRepositorio.Obtener(entidad.Id);

            /*========================================================*/
            entidadModificar.ChequeId = entidad.ChequeId;
            entidadModificar.CuentaBancariaId = entidad.CuentaBancariaId;
            entidadModificar.Fecha = entidad.Fecha;
            /*========================================================*/

            _unidadDeTrabajo.DepositoChequeRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
