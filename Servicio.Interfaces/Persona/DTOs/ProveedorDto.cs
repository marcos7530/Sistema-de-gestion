namespace Servicio.Interfaces.Persona.DTOs
{
    public class ProveedorDto : PersonaJuridicaDto
    {
        public long CondicionIvaId { get; set; }

        public string CondicionIva { get; set; }
    }
}
