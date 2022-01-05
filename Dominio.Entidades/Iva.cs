namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Ivas")]
    [MetadataType(typeof(IIva))]
    public class Iva : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Articulo> Articulos { get; set; }    
    }
}