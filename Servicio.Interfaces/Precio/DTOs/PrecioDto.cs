namespace Servicio.Interfaces.Precio.DTOs
{
    using System;

    public class PrecioDto: Base.BaseDto
    {
        public long ListaPrecioId { get; set; }

        public long ArticuloId { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
