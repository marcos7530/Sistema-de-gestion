using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;

namespace Servicio.Interfaces.DepositoCheque.DTOs
{
    public class DepositoChequeDto:BaseDto
    {
        public long ChequeId { get; set; }

        public long CuentaBancariaId { get; set; }

        public DateTime Fecha { get; set; }
    }
}
