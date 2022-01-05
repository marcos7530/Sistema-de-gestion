namespace Servicio.Interfaces.Comprobante.DTOs
{
    using Aplicacion.Constantes.Clases;
    using Servicio.Interfaces.DetalleComprobante.DTOs;
    using System.Collections.Generic;

    public class FacturaDto : ComprobanteDto
    {
        public string ApellidoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApyNomCliente => $"{ApellidoCliente}, {NombreCliente}";
        public long ClienteFacturaId { get; set; }
        public string DniCliente { get; set; }


    }
}
