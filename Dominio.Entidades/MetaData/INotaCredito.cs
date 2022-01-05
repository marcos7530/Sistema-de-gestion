namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System.ComponentModel.DataAnnotations;

    public interface INotaCredito
    {
        [Required(ErrorMessage = "El campo {0} es Obligaotrio")]
        long ComprobanteId { get; set; }
    }
}
