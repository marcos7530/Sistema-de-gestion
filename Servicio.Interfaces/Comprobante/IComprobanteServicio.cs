using Servicio.Interfaces.Comprobante.DTOs;
using System;
using System.Collections.Generic;

namespace Servicio.Interfaces.Comprobante
{
    public interface IComprobanteServicio
    {

        void Grabar(ComprobanteDto entidad);

        IEnumerable<ComprobanteDto> Get(Type tipo);

        ComprobanteDto GetById(Type tipo, long id);
    }
}
