using System.Windows.Forms;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.CuentaBancaria;

namespace Presentacion.Core.Cheque
{
    using FormularioBase;

    public partial class _00134_CuentasBancarias : FormularioConsulta
    {

        private readonly ICuentaBancariaServicio _cuentaBancariaServicio;

        public _00134_CuentasBancarias(ICuentaBancariaServicio cuentaBancariaServicio)
        {

            InitializeComponent();
            _cuentaBancariaServicio = cuentaBancariaServicio;
            AsignarEvento_EnterLeave(this);
        }


        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _cuentaBancariaServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Titular"].Visible = true;
            dgv.Columns["Titular"].HeaderText = "Titular";
            dgv.Columns["Titular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].HeaderText = "Numero";
            dgv.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["BancoId"].Visible = true;
            dgv.Columns["BancoId"].HeaderText = "BancoId";
            dgv.Columns["BancoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }


        public override bool EjecutarComandoNuevo()
        {
            var fNuevo = new _00135_AbmCuentaBancarias(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();

            return fNuevo.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var fModificar = new _00135_AbmCuentaBancarias(TipoOperacion.Modificar, _entidadId);
            fModificar.ShowDialog();

            return fModificar.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var fEliminar = new _00135_AbmCuentaBancarias(TipoOperacion.Eliminar, _entidadId);
            fEliminar.ShowDialog();

            return fEliminar.RelizoAlgunaOperacion;
        }



    }
}
