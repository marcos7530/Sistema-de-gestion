namespace Dominio.Entidades
{
    using Aplicacion.Constantes.Clases;
    using Dominio.Entidades.MetaData;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comprobantes")]
    [MetadataType(typeof(IFactura))]
    public class Factura : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }
        
        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}
