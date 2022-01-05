namespace Servicio.Interfaces.Caja.DTOs
{
    using System;

    public class CajaAperturaDto: Base.BaseDto
    {
        public long UsuarioAperturaId { get; set; }
        public decimal MontoInicial { get; set; }
        public DateTime FechaApertura { get; set; }
    }
}
