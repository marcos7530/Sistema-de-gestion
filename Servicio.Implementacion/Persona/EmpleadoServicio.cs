namespace Servicio.Implementacion.Persona
{
    using Servicio.Interfaces.Persona;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class EmpleadoServicio : PersonaServicio, IEmpleadoServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public EmpleadoServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public int ObtenerSiguienteNumeroLegajo()
        {
            return _unidadDeTrabajo.EmpleadoRepositorio.ObtenerSiguienteNumeroLegajo();
        }
    }
}
