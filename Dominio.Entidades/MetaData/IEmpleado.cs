namespace Dominio.Entidades.MetaData
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IEmpleado
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [Range(1, 99999999, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
        int Legajo { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime FechaIngreso { get; set; }
    }
}
