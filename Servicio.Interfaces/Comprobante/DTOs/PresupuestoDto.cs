namespace Servicio.Interfaces.Comprobante.DTOs
{
    public class PresupuestoDto: ComprobanteDto
    {
        public string ApyNomCliente { get; set; }
        public long ClienteId { get; set; }
    }
}
