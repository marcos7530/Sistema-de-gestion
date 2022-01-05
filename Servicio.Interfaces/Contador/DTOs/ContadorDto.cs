using Aplicacion.Constantes.Clases;

namespace Servicio.Interfaces.Contador.DTOs
{
    public class ContadorDto:Base.BaseDto
    {
        public TipoComprobante TipoComprobante { get; set; }

        public int Valor { get; set; }
    }
}
