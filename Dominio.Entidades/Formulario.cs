namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("Formularios")]
    [MetadataType(typeof(IFormulario))]
    public class Formulario : Entidad
    {
        // Propiedades

        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string NombreCompleto { get; set; }

        // Propiedades de Navegacion

        public virtual ICollection<Perfil> Perfiles { get; set; }
    }
}
