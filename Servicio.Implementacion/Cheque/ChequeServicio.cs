using Dominio.Entidades.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Cheque;
using Servicio.Interfaces.Cheque.DTOs;
using System.Linq.Expressions;

namespace Servicio.Implementacion.Cheque
{

    public class ChequeServicio : IChequeServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ChequeServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(ChequeDto entidad)
        {
            var entidadId = _unidadDeTrabajo.ChequeRepositorio.Insertar(new Dominio.Entidades.Cheque()
                {
                    EstaEliminado = false,
                    /*=============================================*/
                    ClienteId = entidad.ClienteId,
                    BancoId = entidad.BancoId,
                    Numero = entidad.Numero,
                    /*AGREGADO DESDE ENTIDAD========*/
                    Monto = entidad.Monto,
                    /*================================*/
                    FechaVencimiento = entidad.FechaVencimiento,
                    EstaRechazado = false
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.ChequeRepositorio.Obtener(id);

            _unidadDeTrabajo.ChequeRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public void UpdateRechazarCheque(ChequeDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ChequeRepositorio.Obtener(entidad.Id);

            entidadModificar.EstaRechazado = true;

            _unidadDeTrabajo.ChequeRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }

        public ChequeDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.ChequeRepositorio.Obtener(id);

            return new ChequeDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                /*========================================*/
                ClienteId = resultado.ClienteId,
                BancoId = resultado.BancoId,
                Numero = resultado.Numero,
                /*AGREGADO DESDE ENTIDAD========*/
                Monto = resultado.Monto,
                /*================================*/
                FechaVencimiento = resultado.FechaVencimiento,
                EstaRechazado = resultado.EstaRechazado,
                /*========================================*/
                RowVersion = resultado.RowVersion
            };
        }


        public void Update(ChequeDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ChequeRepositorio.Obtener(entidad.Id);

            entidadModificar.ClienteId = entidad.ClienteId;
            entidadModificar.BancoId = entidad.ClienteId;
            entidadModificar.Numero = entidad.Numero;
            /*AGREGADO DESDE ENTIDAD========*/
            entidadModificar.Monto = entidad.Monto;
            /*================================*/
            entidadModificar.FechaVencimiento = entidad.FechaVencimiento;
            entidadModificar.EstaRechazado = entidad.EstaRechazado;

            _unidadDeTrabajo.ChequeRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ChequeDto> GetChequesNoRechazados(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Cheque, bool>> filtro = t =>
                !t.EstaEliminado && t.EstaRechazado==false;

            var resultado = _unidadDeTrabajo.ChequeRepositorio.Obtener(filtro);

            return resultado.Select(x => new ChequeDto()
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ClienteId = x.ClienteId,
                BancoId = x.BancoId,
                Numero = x.Numero,
                /*AGREGADO DESDE ENTIDAD========*/
                Monto = x.Monto,
                /*================================*/
                FechaVencimiento = x.FechaVencimiento,
                EstaRechazado = x.EstaRechazado,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList(); throw new NotImplementedException();
        }

        public IEnumerable<ChequeDto> GetChequesRechazados(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Cheque, bool>> filtro = t =>
                !t.EstaEliminado && t.EstaRechazado == true;

            var resultado = _unidadDeTrabajo.ChequeRepositorio.Obtener(filtro);

            return resultado.Select(x => new ChequeDto()
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ClienteId = x.ClienteId,
                BancoId = x.BancoId,
                Numero = x.Numero,
                /*AGREGADO DESDE ENTIDAD========*/
                Monto = x.Monto,
                /*================================*/
                FechaVencimiento = x.FechaVencimiento,
                EstaRechazado = x.EstaRechazado,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList(); throw new NotImplementedException();
        }

        public IEnumerable<ChequeDto> GetPorFechaNoRechazados(DateTime fechaDesde, DateTime fechaHasta)
        {
            Expression<Func<Dominio.Entidades.Cheque, bool>> filtro = t =>
                !t.EstaEliminado 
                && (fechaDesde <= t.FechaVencimiento && t.FechaVencimiento <= fechaHasta)
                && t.EstaRechazado==false;

            var resultado = _unidadDeTrabajo.ChequeRepositorio.Obtener(filtro);

            return resultado.Select(x => new ChequeDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ClienteId = x.ClienteId,
                BancoId = x.BancoId,
                Numero = x.Numero,
                /*AGREGADO DESDE ENTIDAD========*/
                Monto = x.Monto,
                /*================================*/
                FechaVencimiento = x.FechaVencimiento,
                EstaRechazado = x.EstaRechazado,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }


        public IEnumerable<ChequeDto> GetPorFechaRechazados(DateTime fechaDesde, DateTime fechaHasta)
        {
            Expression<Func<Dominio.Entidades.Cheque, bool>> filtro = t =>
                !t.EstaEliminado
                && (fechaDesde <= t.FechaVencimiento && t.FechaVencimiento <= fechaHasta)
                && t.EstaRechazado == true;

            var resultado = _unidadDeTrabajo.ChequeRepositorio.Obtener(filtro);

            return resultado.Select(x => new ChequeDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                /*===============================================*/
                ClienteId = x.ClienteId,
                BancoId = x.BancoId,
                Numero = x.Numero,
                /*AGREGADO DESDE ENTIDAD========*/
                Monto = x.Monto,
                /*================================*/
                FechaVencimiento = x.FechaVencimiento,
                EstaRechazado = x.EstaRechazado,
                /*===============================================*/
                RowVersion = x.RowVersion
            }).ToList();
        }


      
    }
}
