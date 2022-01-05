namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IFormaPagoCheque
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ChequeId { get; set; }
    }
}
