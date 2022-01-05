namespace Dominio.Entidades
{
    using Aplicacion.Constantes.Clases;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contadores")]
    [MetadataType(typeof(IContador))]
    public class Contador: Entidad
    {
        public TipoComprobante TipoComprobante { get; set; }

        public int Valor { get; set; }
    }
}
