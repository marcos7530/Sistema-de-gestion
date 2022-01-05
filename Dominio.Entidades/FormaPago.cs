using Aplicacion.Constantes.Clases;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;

    [Table("FormaPagos")]
    [MetadataType(typeof(IFormaPago))]
    public class FormaPago : Entidad
    {
        // Propiedades
        public long ComprobanteId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
    }
}
