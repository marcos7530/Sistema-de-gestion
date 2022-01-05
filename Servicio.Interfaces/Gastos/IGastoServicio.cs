using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Gastos.DTOs;

namespace Servicio.Interfaces.Gastos
{
    public interface IGastoServicio
    {
        long Add(GastoDto entidad);

        void Update(GastoDto entidad);

        void Delete(long id);

        IEnumerable<GastoDto> Get(string cadenaBuscar);

        IEnumerable<GastoDto> GetPorFecha(DateTime fechaDesde, DateTime fechaHasta);
        GastoDto GetById(long id);
    }
}
