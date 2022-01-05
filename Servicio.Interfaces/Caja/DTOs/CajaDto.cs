namespace Servicio.Interfaces.Caja.DTOs
{
    using Servicio.Interfaces.DetalleCaja.DTOs;
    using System;
    using System.Collections.Generic;

    public class CajaDto: Base.BaseDto
    {
        // Apertura

        //[ForeignKey("UsuarioApertura")]
        public long UsuarioAperturaId { get; set; }
        public string UsuarioApertura { get; set; }
        public string ApellidoEmpleadoApertura { get; set; }
        public string NombreEmpleadoApertura { get; set; }
        public decimal MontoInicial { get; set; }
        public DateTime FechaApertura { get; set; }

        // Cierre

        public DateTime? FechaCierre { get; set; }

        //[ForeignKey("UsuarioCierre")]
        public long? UsuarioCierreId { get; set; }
        public string UsuarioCierre { get; set; }
        public string ApellidoEmpleadoCierre { get; set; }
        public string NombreEmpleadoCierre { get; set; }
        public decimal? MontoCierre { get; set; }
        public decimal? TotalVentaEfectivo { get; set; }
        public decimal? TotalCobranzaEfectivo { get; set; }
        public decimal? TotalSalidaCompras { get; set; }
        public decimal? TotalSalidaGastos { get; set; }
        public decimal? TotalSalidaNotaCreditos { get; set; }

        public decimal? TotalTarjetaEntrada { get; set; }
        public decimal? TotalChequeEntrada { get; set; }
        public decimal? TotalCuentaCorrienteEntrada { get; set; }

        public decimal? TotalTarjetaSalida { get; set; }
        public decimal? TotalChequeSalida { get; set; }
        public decimal? TotalCuentaCorrienteSalida { get; set; }

        public IEnumerable<DetalleCajaDto> DetalleCajas { get; set; }
    }
}
