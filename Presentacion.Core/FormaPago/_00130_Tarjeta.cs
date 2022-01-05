namespace Presentacion.Core.FormaPago
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Tarjeta;
    using System;
    using System.Windows.Forms;

    public partial class _00130_Tarjeta : FormularioConsulta
    {
        private readonly ITarjetaServicio _tarjetaServicio;
        public _00130_Tarjeta(ITarjetaServicio tarjetaServivio)
        {
            InitializeComponent();
            _tarjetaServicio = tarjetaServivio;
            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _tarjetaServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CentrarCabecerasGrilla(dgv);
            CentrarCabecerasGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00131_Abm_Tarjeta(TipoOperacion.Nuevo);
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
                var fModificar = new _00131_Abm_Tarjeta(TipoOperacion.Modificar, _entidadId);
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
                var fEliminar = new _00131_Abm_Tarjeta(TipoOperacion.Eliminar, _entidadId);
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
