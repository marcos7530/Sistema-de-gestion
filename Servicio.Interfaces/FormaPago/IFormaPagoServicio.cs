using Servicio.Interfaces.FormaPago.DTOs;
using System;
using System.Collections.Generic;

namespace Servicio.Interfaces.FormaPago
{
    public interface IFormaPagoServicio
    {
        void Grabar(FormaPagoDto entidad);

        IEnumerable<FormaPagoDto> Get(Type tipo, string cadenaBuscar);

        FormaPagoDto GetById(Type tipo, long id);
    }
}
