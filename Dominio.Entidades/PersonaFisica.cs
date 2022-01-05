using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Persona")]
    [MetadataType(typeof(IPersonaFisica))]
    public abstract class PersonaFisica : Persona
    {
        // Propiedades
        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Dni { get; set; }

        public string Cuil { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public byte[] Foto { get; set; }
    }
}
