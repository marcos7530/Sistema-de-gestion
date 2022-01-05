namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;
    
    public interface IFormaPagoTarjeta
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long TarjetaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string CuponPago { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        int CantidadCuotas { get; set; }
    }
}
