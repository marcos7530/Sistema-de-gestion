namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System.ComponentModel.DataAnnotations;

    public interface IRemito
    {
        [Required(ErrorMessage ="El Campo {0} es Obligatorio.")]
        long ClienteId { get; set; }

    }
}
