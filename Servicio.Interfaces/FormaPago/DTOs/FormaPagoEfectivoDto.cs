namespace Servicio.Interfaces.FormaPago.DTOs
{
    public class FormaPagoEfectivoDto: FormaPagoDto
    {
        public long ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
    }
}
