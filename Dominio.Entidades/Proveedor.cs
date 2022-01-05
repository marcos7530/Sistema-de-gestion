namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Persona_Proveedor")]
    [MetadataType(typeof(IProveedor))]
    public class Proveedor : PersonaJuridica
    {
        public long CondicionIvaId { get; set; }

        public string CodigoProveedor { get; set; }

        // Propiedades de Navegacion

        public virtual CondicionIva CondicionIva { get; set; }
    }
}
