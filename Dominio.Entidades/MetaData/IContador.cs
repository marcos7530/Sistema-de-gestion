namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public interface IContador
    {
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        TipoComprobante TipoComprobante { get; set; }

        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        [DefaultValue(0)]
        int Valor { get; set; }
    }
}
