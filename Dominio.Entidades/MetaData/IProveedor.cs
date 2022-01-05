namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IProveedor
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CondicionIvaId { get; set; }

        string CodigoProveedor { get; set; }
    }
}
