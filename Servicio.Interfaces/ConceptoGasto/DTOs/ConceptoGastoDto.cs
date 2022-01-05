using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;

namespace Servicio.Interfaces.ConceptoGasto.DTOs
{
    public class ConceptoGastoDto: BaseDto
    {
        public string Descripcion { get; set; }
    }
}
