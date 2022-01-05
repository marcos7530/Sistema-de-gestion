namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface ICliente
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CondicionIvaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType("bit")]
        bool ActivarCtaCte { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType("bit")]
        bool TieneLimiteCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }
    }
}
