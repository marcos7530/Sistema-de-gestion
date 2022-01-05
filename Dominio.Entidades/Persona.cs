namespace Dominio.Entidades
{
    using Base;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Dominio.Entidades.MetaData;

    [Table("Persona")]
    [MetadataType(typeof(IPersona))]
    public /*abstract*/ class Persona : Entidad
    {
        // Propiedades
        public long LocalidadId { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }
        
        // Propiedades de Navegacion
        public virtual Localidad Localidad { get; set; }
    }
}
