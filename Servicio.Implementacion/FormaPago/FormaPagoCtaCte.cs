using Dominio.Entidades.UnidadDeTrabajo;

namespace Servicio.Implementacion.FormaPago
{
    public class FormaPagoCtaCte: FormaPago
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public FormaPagoCtaCte(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
    }
}
