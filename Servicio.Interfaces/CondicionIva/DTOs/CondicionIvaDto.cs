namespace Servicio.Interfaces.CondicionIva.DTOs
{
    using Base;
    using Aplicacion.Constantes.Clases;

    public class CondicionIvaDto : BaseDto
    {
        public string Descripcion { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public string EliminadoStr => EstaEliminado ? "SI" : "NO";

        public string TipoComprobanteStr => TipoComprobante.ToString();
    }
}
 