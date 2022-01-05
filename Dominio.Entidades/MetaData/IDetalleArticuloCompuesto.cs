using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IDetalleArticuloCompuesto
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ArticuloPadreId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ArticuloHijoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Cantidad { get; set; }
    }
}
