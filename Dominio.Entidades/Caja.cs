namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("Cajas")]
    [MetadataType(typeof(ICaja))]
    public class Caja : Entidad
    {
        // Propiedades

        // Apertura

        [ForeignKey("UsuarioApertura")]
        public long UsuarioAperturaId { get; set; }
        public decimal MontoInicial { get; set; }
        public DateTime FechaApertura { get; set; }
        
        // Cierre

        public DateTime? FechaCierre { get; set; }
        
        [ForeignKey("UsuarioCierre")]
        public long? UsuarioCierreId { get; set; }
        public decimal? MontoCierre { get; set; } //toma el monto de cierre anterior como caja de inicio
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


        // Propiedades de Navegacion
        public Usuario UsuarioApertura { get; set; }

        public Usuario UsuarioCierre { get; set; }

        public virtual ICollection<DetalleCaja> DetalleCajas { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
