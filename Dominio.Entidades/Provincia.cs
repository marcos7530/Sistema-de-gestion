namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Dominio.Entidades.MetaData;
    using Base;

    [Table("Provincia")]
    [MetadataType(typeof(IProvincia))]
    public class Provincia : Entidad
    {
        // Propiedades 
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}