namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;
    using Base;

    [Table("Precios")]
    [MetadataType(typeof(IPrecio))]
    public class Precio : Entidad
    {
        // Propiedades
        public long ListaPrecioId { get; set; }

        public long ArticuloId { get; set; }
        
        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }

        public DateTime FechaActualizacion { get; set; }

        // Propiedades de Navegacion
        public virtual Articulo Articulo { get; set; }

        public virtual ListaPrecio ListaPrecio { get; set; }
    }
}