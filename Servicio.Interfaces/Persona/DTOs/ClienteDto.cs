using Dominio.Entidades;
using Servicio.Interfaces.MOvimientoCuentaCorriente.DTOs;
using System.Collections.Generic;

namespace Servicio.Interfaces.Persona.DTOs
{
    public class ClienteDto : PersonaFisicaDto
    {
        public long CondicionIvaId { get; set; }
        public string CondicionIva { get; set; }
        public bool ActivarCtaCte { get; set; }
        public bool TieneLimiteCompra { get; set; }
        public decimal Monto { get; set; }

        public List<MovimientoCuentaCorrienteDto> Movimientos { get; set; }
    }
}
