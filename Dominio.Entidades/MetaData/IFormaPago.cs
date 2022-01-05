namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;
    using Aplicacion.Constantes.Clases;

    public interface IFormaPago
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ComprobanteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoPago TipoPago { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }
    }
}
