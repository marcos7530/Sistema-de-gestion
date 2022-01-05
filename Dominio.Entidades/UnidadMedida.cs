namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("UnidadMedidas")]
    [MetadataType(typeof(IUnidadMedida))]
    public class UnidadMedida : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Articulo> Articulos { get; set; }    
    }
}