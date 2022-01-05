namespace Servicio.Interfaces.DetalleCaja.DTOs
{
    using Aplicacion.Constantes.Clases;

    public class DetalleCajaDto: Base.BaseDto
    {
        public long CajaId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }
    }
}
