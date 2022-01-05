namespace Servicio.Interfaces.Contador
{
    using Aplicacion.Constantes.Clases;
    using Servicio.Interfaces.Contador.DTOs;

    public interface IContadorServicio
    {
        void Grabar(ContadorDto dto);
        int ObtenerSiguienteNumeroComprobante(TipoComprobante tipoComprobante);
    }
}
