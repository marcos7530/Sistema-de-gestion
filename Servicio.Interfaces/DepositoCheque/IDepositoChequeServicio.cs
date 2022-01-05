using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.DepositoCheque.DTOs;

namespace Servicio.Interfaces.DepositoCheque
{
    public interface IDepositoChequeServicio
    {
        long Add(DepositoChequeDto entidad);

        void Update(DepositoChequeDto entidad);

        void Delete(long id);

        IEnumerable<DepositoChequeDto> Get(string cadenaBuscar);

        DepositoChequeDto GetById(long id);
    }
}
