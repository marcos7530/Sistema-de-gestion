using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;

namespace Servicio.Interfaces.Cheque.DTOs
{
    public class ChequeDto:BaseDto
    {
        public long ClienteId { get; set; }

        public long BancoId { get; set; }

        public string Numero { get; set; }

        /*===========AGREGADO DESDE ENTIDAD======*/

        public decimal Monto { get; set; }

        /*========================================*/

        public DateTime FechaVencimiento { get; set; }

        public bool EstaRechazado { get; set; }
    }
}
