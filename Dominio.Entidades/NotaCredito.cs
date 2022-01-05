namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Aplicacion.Constantes.Clases;
    using Dominio.Entidades.MetaData;

    [Table("Comprobantes")]
    [MetadataType(typeof(INotaCredito))]
    public class NotaCredito : Comprobante
    {
        // Propiedades
        public long ComprobanteId { get; set; }
        
        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
    }
}
/**************************************************
 * La nota de credito es interno,lo genera la empresa
 * cuando tengo una devolucion de un(os) articulos 
 *  motivo de baja del producto
 ****************************************/
