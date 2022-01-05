namespace Dominio.Entidades.MetaData
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface ICompra
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ProveedorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Iva27 { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal PrecepcionTemp { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal PrecepcionPyP { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal PrecepcionIva { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal PrecepcionIB { get; set; }
        
    }
}
