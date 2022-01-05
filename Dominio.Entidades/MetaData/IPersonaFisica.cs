using System;

namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IPersonaFisica
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(9, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Dni { get; set; }

        [StringLength(13, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Cuil { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        byte[] Foto { get; set; }
    }
}
