namespace Dominio.Entidades.MetaData
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;

    public interface ICaja
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long UsuarioAperturaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal MontoInicial { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        DateTime FechaApertura { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? FechaCierre { get; set; }
        long? UsuarioCierreId { get; set; }

        [DataType(DataType.Currency)]
        decimal? MontoCierre { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalVentaEfectivo { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalCobranzaEfectivo { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalSalidaCompras { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalSalidaGastos { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalSalidaNotaCreditos { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalTarjetaEntrada { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalChequeEntrada { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalCuentaCorrienteEntrada { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalTarjetaSalida { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalChequeSalida { get; set; }

        [DataType(DataType.Currency)]
        decimal? TotalCuentaCorrienteSalida { get; set; }
    }
}
