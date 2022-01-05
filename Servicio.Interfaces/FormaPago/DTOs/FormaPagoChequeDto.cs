namespace Servicio.Interfaces.FormaPago.DTOs
{
    using System;

    public class FormaPagoChequeDto: FormaPagoDto
    {
        public long  ChequeId { get; set; }
        public long ClienteId { get; set; }
        public long BancoId { get; set; }

        public string Numero { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public bool EstaRechazado { get; set; }
    }
}
