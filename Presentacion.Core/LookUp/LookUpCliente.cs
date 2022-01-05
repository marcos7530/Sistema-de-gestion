namespace Presentacion.Core.LookUp
{
    using FormularioBase;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;
    using System.Linq;
    using System.Windows.Forms;

    public partial class LookUpCliente : FormularioLookUp
    {
        private readonly IClienteServicio _clienteServicio;
        public LookUpCliente()
        {
            InitializeComponent();
            _clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
        }


        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _clienteServicio.Get(typeof(ClienteDto), string.Empty)
                .Where(x => !x.EstaEliminado).ToList();
        }

        private void LookUpCliente_Load(object sender, System.EventArgs e)
        {

        }




    }
}
