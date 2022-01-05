namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IFormaPagoEfectivo
    {
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        long ClienteId { get; set; }
    }
}
