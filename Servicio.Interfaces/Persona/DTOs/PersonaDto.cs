namespace Servicio.Interfaces.Persona.DTOs
{
    using Base;

    public class PersonaDto : BaseDto
    {
        public long LocalidadId { get; set; }

        public string Localidad { get; set; }

        public long ProvinciaId { get; set; }

        public string Provincia { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }
    }
}
