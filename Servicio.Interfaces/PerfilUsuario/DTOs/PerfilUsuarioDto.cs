using System.Security.Permissions;

namespace Servicio.Interfaces.PerfilUsuario.DTOs
{
    public class PerfilUsuarioDto
    {
        public bool Item { get; set; }

        public long UsuarioId { get; set; }

        public string Usuario { get; set; }

        // =============================================== //

        public long EmpleadoId { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";


    }
}
