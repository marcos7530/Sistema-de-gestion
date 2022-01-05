namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IComprobante
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long EmpleadoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.DateTime)]
        DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        int Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal SubTotal { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        decimal Descuento { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Currency)]
        decimal Total { get; set; }

        decimal Iva21 { get; set; }

        decimal Iva105 { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoComprobante TipoComprobante { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        EstadoComprobante EstadoComprobante { get; set; }
    }
}
