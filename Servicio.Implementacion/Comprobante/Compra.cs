namespace Servicio.Implementacion.Comprobante
{
    using Dominio.Entidades.UnidadDeTrabajo;

    public class Compra: Comprobante
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public Compra(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
    }
}
