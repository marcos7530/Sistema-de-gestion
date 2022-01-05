using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;

namespace Servicio.Interfaces.Gastos.DTOs
{
    public class GastoDto:BaseDto
    {
        public long ConceptoGastoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }
    }
}
