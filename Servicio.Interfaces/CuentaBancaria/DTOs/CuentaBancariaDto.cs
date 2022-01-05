using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;

namespace Servicio.Interfaces.CuentaBancaria.DTOs
{
    public class CuentaBancariaDto: BaseDto
    {
        public long BancoId { get; set; }

        public string Banco { get; set; }

        public string Numero { get; set; }

        public string Titular { get; set; }
    }
}
