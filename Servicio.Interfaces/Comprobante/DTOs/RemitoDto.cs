namespace Servicio.Interfaces.Comprobante.DTOs
{
    public class RemitoDto: ComprobanteDto
    {
        public string ApyNomCliente { get; set; }
        public long ClienteId { get; set; }
    }
}
