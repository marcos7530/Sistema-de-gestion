namespace Servicio.Interfaces.Seguridad
{
    public interface ISeguridadServicio
    {
        bool VerificarAcceso(string usuario, string password);

        bool VerificarAccesoFormulario(string usuarioLogin, string nombreFormulario);
    }
}
