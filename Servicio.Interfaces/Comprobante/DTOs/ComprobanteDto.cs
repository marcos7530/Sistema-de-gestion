using Aplicacion.Constantes.Clases;
using Servicio.Interfaces.DetalleComprobante.DTOs;
using Servicio.Interfaces.FormaPago.DTOs;
using System;
using System.Collections.Generic;

namespace Servicio.Interfaces.Comprobante.DTOs
{
    public class ComprobanteDto: Base.BaseDto
    {
        public long CajaId { get; set; }

        public long EmpleadoId { get; set; }

        public long UsuarioId { get; set; }

        public string ApellidoEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public string NombreUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public int Numero { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalStr => SubTotal.ToString("C");

        public decimal Descuento { get; set; }

        public string DescuentoStr => Descuento.ToString("C");

        public decimal Total { get; set; }

        public string TotalStr => Total.ToString();

        public TipoComprobante TipoComprobante { get; set; }

        public EstadoComprobante EstadoComprobante { get; set; }

        public decimal Iva21 { get; set; }

        public string Iva21Str => Iva21.ToString("C");

        public decimal Iva105 { get; set; }

        public string Iva105Str => Iva105.ToString("C");
        
        public List<DetalleComprobanteDto> Items { get; set; }

        public FormaPagoDto PagoEfectivoDto { get; set; }

        public FormaPagoChequeDto PagoChequeDto { get; set; }

        public FormaPagoCtaCteDto PagoCtaCteDto { get; set; }

        public FormaPagoTarjetaDto PagoTarjetaDto { get; set; }
    }
}
