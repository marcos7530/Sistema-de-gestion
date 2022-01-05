namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using MetaData;

    [Table("FormaPagos")]
    [MetadataType(typeof(IFormaPagoCheque))]
    public class FormaPagoCheque : FormaPago
    {
        // Propiedades
        public long ChequeId { get; set; }

        // Propiedades de Navegacion
        public virtual Cheque Cheque { get; set; }
    }
}
