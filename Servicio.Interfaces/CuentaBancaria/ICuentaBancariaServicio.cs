using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.CuentaBancaria.DTOs;

namespace Servicio.Interfaces.CuentaBancaria
{
    public interface ICuentaBancariaServicio
    {
        long Add(CuentaBancariaDto entidad);

        void Update(CuentaBancariaDto entidad);

        void Delete(long id);

        IEnumerable<CuentaBancariaDto> Get(string cadenaBuscar);

        CuentaBancariaDto GetById(long id);
    }
}
