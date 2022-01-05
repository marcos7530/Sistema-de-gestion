namespace Servicio.Interfaces.BajaArticulo.DTOs
{
    using System;

    public class BajaArticuloDto: Base.BaseDto
    {
        public long ArticuloId { get; set; }

        public string  Articulo { get; set; }

        public long MotivoBajaId { get; set; }

        public string MotivoBaja { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }
    }
}
