namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;
    using Aplicacion.Constantes.Clases;

    public interface IDetalleCaja
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CajaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoPago TipoPago { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }
    }
}
