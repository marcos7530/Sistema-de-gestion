namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.MotivoBaja;

    public partial class _00106_MotivoBajaArticulo : FormularioConsulta
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        public _00106_MotivoBajaArticulo(IMotivoBajaServicio motivoBajaServicio)
        {
            InitializeComponent();
            _motivoBajaServicio = motivoBajaServicio;
            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _motivoBajaServicio.Get(string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Está Eliminado";
            CentrarCabecerasGrilla(dgv);
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00107_Abm_MotivoBajaArticulo(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
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
                var fModificar = new _00107_Abm_MotivoBajaArticulo(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00107_Abm_MotivoBajaArticulo(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }
    }
}
