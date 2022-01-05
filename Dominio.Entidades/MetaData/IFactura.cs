using Aplicacion.Constantes.Clases;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IFactura
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ClienteId { get; set; }

    }
}
