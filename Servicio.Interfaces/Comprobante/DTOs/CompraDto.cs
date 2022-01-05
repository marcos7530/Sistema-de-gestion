namespace Servicio.Interfaces.Comprobante.DTOs
{
    using System;

    public class CompraDto: ComprobanteDto
    {
        public long ProveedorId { get; set; }

        public DateTime FechaEntrega { get; set; }

        public decimal Iva27 { get; set; }

        public decimal PrecepcionTemp { get; set; }

        public decimal PrecepcionPyP { get; set; }

        public decimal PrecepcionIva { get; set; }

        public decimal PrecepcionIB { get; set; }
    }
}
