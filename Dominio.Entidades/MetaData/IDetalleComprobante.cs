using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IDetalleComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ComprobanteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ArticuloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        string Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal SubTotal { get; set; }
    }
}
