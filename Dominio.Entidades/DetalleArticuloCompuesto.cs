using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Entidades.MetaData;

namespace Dominio.Entidades
{
    using Base;

    [Table("DetalleArticuloCompuestos")]
    [MetadataType(typeof(IDetalleArticuloCompuesto))]
    public class DetalleArticuloCompuesto : Entidad
    {
        // Propiedades
        [ForeignKey("ArticuloPadre")]
        public long ArticuloPadreId { get; set; }

        [ForeignKey("ArticuloHijo")]
        public long ArticuloHijoId { get; set; }

        public decimal Cantidad { get; set; }

        // Propiedades de Navegacion
        public virtual Articulo ArticuloPadre { get; set; }

        public virtual Articulo ArticuloHijo { get; set; }
    }
}
