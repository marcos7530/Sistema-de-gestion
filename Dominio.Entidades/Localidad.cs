namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Dominio.Entidades.MetaData;

    using Base;
    
    [Table("Localidad")]
    [MetadataType(typeof(ILocalidad))]
    public class Localidad : Entidad
    {
        // Propiedades

        public long ProvinciaId { get; set; }

        public string Descripcion { get; set; }
        

        // Propiedades de Navegacion
        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}