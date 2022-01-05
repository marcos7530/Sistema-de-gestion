namespace Servicio.Interfaces.DetalleArticuloCompuesto.DTOs
{
    public class DetalleArticuloCompuestoDto: Base.BaseDto
    {
        public long ArticuloPadreId { get; set; }

        public string ArticuloPadre { get; set; }

        public long ArticuloHijoId { get; set; }

        public string ArticuloHijo { get; set; }//lo estraño a mi hijo

        public decimal Cantidad { get; set; }
    }
}
