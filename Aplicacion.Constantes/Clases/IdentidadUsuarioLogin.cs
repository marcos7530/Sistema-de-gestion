using System.Drawing;
using Aplicacion.Constantes.Imagenes;

namespace Aplicacion.Constantes.Clases
{
    public static class IdentidadUsuarioLogin
    {
        public static long CajaId { get; set; }

        public static long EmpleadoId { get; set; }

        public static long UsuarioId { get; set; }

        public static string ApellidoEmpleado { get; set; }

        public static string NombreEmpleado { get; set; }

        public static string ApyNom => $"{ApellidoEmpleado} {NombreEmpleado}";

        public static byte[] FotoEmpleadoByte { get; set; }

        public static Image FotoEmpleado => Imagen.Convertir(FotoEmpleadoByte);

        public static string NombreUsuario { get; set; }

        public static string SaludoUsuarioLogin => $"Hola {ApyNom}";
    }
}
