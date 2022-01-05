using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.DetalleCaja;

namespace Servicio.Implementacion.DetalleCaja
{
    public class DetalleCajaServicio: IDetalleCajaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DetalleCajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
    }
}
