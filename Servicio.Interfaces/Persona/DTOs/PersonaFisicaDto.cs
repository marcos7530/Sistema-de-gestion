namespace Servicio.Interfaces.Persona.DTOs
{
    using System;

    public class PersonaFisicaDto : PersonaDto
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string ApyNom => $"{Apellido} {Nombre}";
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte[] Foto { get; set; }
    }
}
