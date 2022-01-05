namespace Servicio.Interfaces.DetalleComprobante.DTOs
{
    public class DetalleComprobanteDto: Base.BaseDto
    {
        public long ComprobanteId { get; set; }

        public long ArticuloId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Iva { get; set; }

        public decimal SubTotal { get; set; }
    }
}
