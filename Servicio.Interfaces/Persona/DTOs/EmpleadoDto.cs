namespace Servicio.Interfaces.Persona.DTOs
{
    using System;

    public class EmpleadoDto : PersonaFisicaDto
    {
        public int Legajo { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}
