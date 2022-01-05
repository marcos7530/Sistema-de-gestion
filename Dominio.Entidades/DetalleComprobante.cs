using Dominio.Base;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;

    [Table("DetalleComprobantes")]
    [MetadataType(typeof(IDetalleComprobante))]
    public class DetalleComprobante : Entidad
    {
        // Propiedades
        public long ComprobanteId { get; set; }

        public long ArticuloId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Iva { get; set; }

        public decimal SubTotal { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
    }
}