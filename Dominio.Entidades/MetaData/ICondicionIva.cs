namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System.ComponentModel.DataAnnotations;

    public interface ICondicionIva
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoComprobante TipoComprobante { get; set; }
    }
}
