namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IFormulario
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        int Codigo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string NombreCompleto { get; set; }
    }
}
