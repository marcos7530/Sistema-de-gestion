using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Cheque.DTOs;

namespace Servicio.Interfaces.Cheque
{
    public interface IChequeServicio
    {
        long Add(ChequeDto entidad);

        void Update(ChequeDto entidad);

        void UpdateRechazarCheque(ChequeDto entidad);

        void Delete(long id);

        IEnumerable<ChequeDto> GetChequesRechazados(string cadenaBuscar);

        IEnumerable<ChequeDto> GetChequesNoRechazados(string cadenaBuscar);

        IEnumerable<ChequeDto> GetPorFechaNoRechazados(DateTime fechaDesde, DateTime fechaHasta);

        IEnumerable<ChequeDto> GetPorFechaRechazados(DateTime fechaDesde, DateTime fechaHasta);

        ChequeDto GetById(long id);
    }
}
