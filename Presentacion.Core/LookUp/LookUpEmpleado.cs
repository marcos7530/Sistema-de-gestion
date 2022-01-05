namespace Presentacion.Core.LookUp
{
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using System.Linq;

    public partial class LookUpEmpleado : FormularioLookUp
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        public LookUpEmpleado(IEmpleadoServicio empleadoServicio)
        {
            InitializeComponent();
            _empleadoServicio = empleadoServicio;
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _empleadoServicio.Get(typeof(EmpleadoDto), string.Empty)
                .Where(x => !x.EstaEliminado).ToList();
        }
    }
}
