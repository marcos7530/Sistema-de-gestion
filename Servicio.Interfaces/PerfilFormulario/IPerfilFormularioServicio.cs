namespace Servicio.Interfaces.PerfilFormulario
{
    using System.Collections.Generic;
    using DTOs;

    public interface IPerfilFormularioServicio
    {
        IEnumerable<PerfilFormularioDto> ObtenerFormulariosAsignados(long perfilId, string cadenaBuscar);

        IEnumerable<PerfilFormularioDto> ObtenerFormulariosNoAsignados(long perfilId, string cadenaBuscar);

        void AsignarFormulario(long perfilId, List<PerfilFormularioDto> formularios);

        void QuitarFormulario(long perfilId, List<PerfilFormularioDto> formularios);
    }
}
