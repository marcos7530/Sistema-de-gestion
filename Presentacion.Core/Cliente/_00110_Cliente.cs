namespace Presentacion.Core.Cliente
{
    using System;
    using System.Windows.Forms;

    using FormularioBase.Helpers;
    using FormularioBase;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;
    

    public partial class _00110_Cliente : FormularioConsulta
    {
        private readonly IClienteServicio _clienteServicio;
        public _00110_Cliente()
        {
            InitializeComponent();

            _clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();

            AsignarEvento_EnterLeave(this);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].HeaderText = "DNI";

            dgv.Columns["Celular"].Visible = true;

            dgv.Columns["Email"].Visible = true;
            dgv.Columns["Email"].HeaderText = "Correo Electronico";
            dgv.Columns["Email"].Width = 200;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            var datos = _clienteServicio.Get(typeof(ClienteDto),
                !string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            dgv.DataSource = datos;

            FormatearGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00111_Abm_Cliente(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00111_Abm_Cliente(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00111_Abm_Cliente(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR. {e.Message}");
                return false;
            }
        }
    }
}
