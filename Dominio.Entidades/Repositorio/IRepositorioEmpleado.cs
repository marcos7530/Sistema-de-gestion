namespace Dominio.Entidades.Repositorio
{
    using Dominio.Base;

    public interface IRepositorioEmpleado : IRepositorio<Dominio.Entidades.Empleado>
    {
        int ObtenerSiguienteNumeroLegajo();
    }
}
