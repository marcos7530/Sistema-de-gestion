namespace Servicio.Interfaces.Comprobante
{
    using Servicio.Interfaces.Comprobante.DTOs;
    using System.Collections;
    using System.Collections.Generic;

    public interface IFacturaServicio: IComprobanteServicio
    {
        IEnumerable<FacturaDto> ObtenerPendientesDePagos();
    }
}
