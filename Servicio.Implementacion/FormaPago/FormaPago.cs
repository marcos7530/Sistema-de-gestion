namespace Servicio.Implementacion.FormaPago
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.FormaPago.DTOs;
    using System.Collections.Generic;
    using System.Linq;

    public class FormaPago
    {       
        public virtual void Grabar(FormaPagoDto entidad)
        {
            
        }

        public virtual IEnumerable<FormaPagoDto> Get()
        {
            return null;
        }

        public virtual FormaPagoDto GetById(long entidadId)
        {
            return null;
        }
    }
}
