namespace Presentacion.Core.Proveedor
{
    using FormularioBase;
    using System;
    using System.Windows.Forms;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;

    public partial class _00117_Proveedor : FormularioConsulta
    {
        private readonly IProveedorServicio _proveedorServicio;
        public _00117_Proveedor()
        {
            InitializeComponent();

            _proveedorServicio = ObjectFactory.GetInstance<IProveedorServicio>();

            AsignarEvento_EnterLeave(this);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["RazonSocial"].Visible = true;
            dgv.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgv.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["CUIT"].Visible = true;
            dgv.Columns["CUIT"].HeaderText = "C.U.I.T.";

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
            var datos = _proveedorServicio.Get(typeof(ProveedorDto),
                !string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            dgv.DataSource = datos;

            FormatearGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00118_Abm_Proveedor(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00118_Abm_Proveedor(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00118_Abm_Proveedor(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }
    }
}
