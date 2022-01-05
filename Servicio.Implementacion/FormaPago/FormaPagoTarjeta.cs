using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.FormaPago.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Implementacion.FormaPago
{
    public class FormaPagoTarjeta: FormaPago
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public FormaPagoTarjeta(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public override void Grabar(FormaPagoDto entidad)
        {
            var e = (FormaPagoTarjetaDto)entidad;
            _unidadDeTrabajo.FormaPagoTarjetaRepositorio.Insertar(
                new Dominio.Entidades.FormaPagoTarjeta
                {
                    ComprobanteId = e.ComprobanteId,
                    TipoPago = e.TipoPago,
                    Monto = e.Monto,
                    EstaEliminado = false,
                    NumeroTarjeta = e.NumeroTarjeta,
                    CuponPago = e.CuponPago,
                    CantidadCuotas = e.CantidadCuotas,
                    TarjetaId = e.TarjetaId
                });
            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<FormaPagoDto> Get()
        {
            return _unidadDeTrabajo.FormaPagoTarjetaRepositorio.Obtener(x => x.EstaEliminado == false, "Comprobante")
                .Select(x => new FormaPagoTarjetaDto
                {
                    Id = x.Id,
                    ComprobanteId = x.ComprobanteId,
                    TipoPago = x.TipoPago,
                    Monto = x.Monto,
                    NumeroTarjeta = x.NumeroTarjeta,
                    CuponPago = x.CuponPago,
                    CantidadCuotas = x.CantidadCuotas,
                    TarjetaId = x.TarjetaId,
                    EstaEliminado = x.EstaEliminado,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public override FormaPagoDto GetById(long entidadId)
        {
            var x = _unidadDeTrabajo.FormaPagoTarjetaRepositorio.Obtener(entidadId, "Comprobante");
            return new FormaPagoTarjetaDto
            {
                Id = x.Id,
                ComprobanteId = x.ComprobanteId,
                TipoPago = x.TipoPago,
                Monto = x.Monto,
                EstaEliminado = x.EstaEliminado,
                NumeroTarjeta = x.NumeroTarjeta,
                CuponPago = x.CuponPago,
                CantidadCuotas = x.CantidadCuotas,
                TarjetaId = x.TarjetaId,
                RowVersion = x.RowVersion
            };
        }
    }
}
