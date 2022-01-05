namespace Presentacion.Seguridad
{
    using System;
    using Presentacion.FormularioBase.Helpers;
    using System.Windows.Forms;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;
    using FormularioBase;
    using Servicio.Interfaces.Persona;

    public partial class _00001_Empleado : FormularioConsulta
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        public _00001_Empleado()
        {
            InitializeComponent();

            _empleadoServicio = ObjectFactory.GetInstance<IEmpleadoServicio>();

            AsignarEvento_EnterLeave(this);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            
            dgv.Columns["Legajo"].Visible = true;
            

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
            var datos = _empleadoServicio.Get(typeof(EmpleadoDto),
                !string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            dgv.DataSource = datos;
            
            FormatearGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00002_Abm_Empleado(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00002_Abm_Empleado(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00002_Abm_Empleado(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }
    }
}
