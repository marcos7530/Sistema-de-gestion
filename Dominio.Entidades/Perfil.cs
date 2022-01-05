namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Perfiles")]
    [MetadataType(typeof(IPerfil))]
    public class Perfil : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navagacion
        public virtual ICollection<Formulario> Formularios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}