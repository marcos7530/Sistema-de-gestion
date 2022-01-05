namespace Servicio.Interfaces.Usuario.DTOs
{
    using Base;
    public class UsuarioDto : BaseDto
    {
        public bool Item { get; set; }

        // Datos de la Persona

        public long EmpleadoId { get; set; }

        public string ApellidoEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public string ApyNom => $"{ApellidoEmpleado} {NombreEmpleado}";

        public byte[] FotoEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }
        
        public string Bloqueado => EstaBloqueado ? "SI" : "NO";

        public string Eliminado => EstaEliminado ? "SI" : "NO";
    }
}
