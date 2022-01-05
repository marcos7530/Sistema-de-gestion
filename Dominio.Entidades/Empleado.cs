using System.Collections.Generic;

namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Persona_Empleado")]
    [MetadataType(typeof(IEmpleado))]
    public class Empleado : PersonaFisica
    {
        // Propiedades
        public int Legajo { get; set; }

        public DateTime FechaIngreso { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
