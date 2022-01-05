namespace Servicio.Implementacion.Comprobante
{
    using Servicio.Interfaces.Comprobante.DTOs;
    using System.Collections.Generic;

    public class Comprobante
    {
        public virtual void Grabar(ComprobanteDto entidad)
        {
        }
        public virtual IEnumerable<ComprobanteDto> Get()
        {
            return null;
        }

        public virtual ComprobanteDto GetById(long entidadId)
        {
            return null;
        }

    }
}
