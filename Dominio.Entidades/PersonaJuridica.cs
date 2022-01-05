namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Persona")]
    [MetadataType(typeof(IPersonaJuridica))]
    public abstract class PersonaJuridica : Persona
    {
        // Propiedades

        public string RazonSocial { get; set; }

        public string CUIT { get; set; }
    }
}
