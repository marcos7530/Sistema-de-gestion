using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IUsuario
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long EmpleadoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DefaultValue(false)]
        bool EstaBloqueado { get; set; }
    }
}
