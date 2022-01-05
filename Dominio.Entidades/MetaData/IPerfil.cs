namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IPerfil
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }
    }
}
