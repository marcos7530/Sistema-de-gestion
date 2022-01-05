namespace Servicio.Interfaces.Configuracion
{
    using Servicio.Interfaces.Configuracion.DTOs;

    public interface IConfiguracionServicio
    {
        void Grabar(ConfiguracionDto entidad);

        ConfiguracionDto Get();
      
    }
}
