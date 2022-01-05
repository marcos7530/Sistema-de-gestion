namespace Servicio.Interfaces.PerfilUsuario
{
    using System.Collections.Generic;
    using DTOs;

    public interface IPerfilUsuarioServicio
    {
        IEnumerable<PerfilUsuarioDto> ObtenerUsuariosAsignados(long perfilId, string cadenaBuscar);

        IEnumerable<PerfilUsuarioDto> ObtenerUsuariosNoAsignados(long perfilId, string cadenaBuscar);

        void AsignarUsuario(long perfilId, List<PerfilUsuarioDto> usuarios);

        void QuitarUsuario(long perfilId, List<PerfilUsuarioDto> usuarios);
    }
}
