namespace Servicio.Interfaces.FormaPago.DTOs
{
    using Aplicacion.Constantes.Clases;

    public class FormaPagoDto: Base.BaseDto
    {
        public long ComprobanteId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }
    }
}
