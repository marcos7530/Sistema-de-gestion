namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("FormaPagos")]
    [MetadataType(typeof(IFormaPagoCtaCte))]
    public class FormaPagoCtaCte : FormaPago
    {
        // Propiedades
        public long ClienteId { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}
