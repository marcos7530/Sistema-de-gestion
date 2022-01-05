using System;
using System.Windows.Forms;
using Presentacion.Core.Cheque;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.CuentaBancaria;
using Servicio.Interfaces.Gastos;

namespace Presentacion.Core.Caja
{
    using FormularioBase;
    
    public partial class _00148_Gastos : FormularioConsulta
    {
        private readonly IGastoServicio _gastoServicio;

        public _00148_Gastos(IGastoServicio gastoServicio)
        {
            InitializeComponent();
            _gastoServicio = gastoServicio;
            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
            dgv.DataSource = _gastoServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public void ActualizarDatosPorFecha(DataGridView dgv, DateTime desde, DateTime hasta)
        {
            dgv.DataSource = _gastoServicio.GetPorFecha(desde,hasta);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ConceptoGastoId"].Visible = true;
            dgv.Columns["ConceptoGastoId"].HeaderText = "Gasto Id";
            dgv.Columns["ConceptoGastoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Monto"].Visible = true;
            dgv.Columns["Monto"].HeaderText = "Monto";
            dgv.Columns["Monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }


        public override bool EjecutarComandoNuevo()
        {
            var fNuevo = new _00149_Abm_Gastos(TipoOperacion.Nuevo, null);
            fNuevo.ShowDialog();

            return fNuevo.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var fModificar = new _00149_Abm_Gastos(TipoOperacion.Modificar, _entidadId);
            fModificar.ShowDialog();

            return fModificar.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var fEliminar = new _00149_Abm_Gastos(TipoOperacion.Eliminar, _entidadId);
            fEliminar.ShowDialog();

            return fEliminar.RelizoAlgunaOperacion;
        }

        public override void BtnBuscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBusqueda.Text))
            {
                ActualizarDatosPorFecha(dgvGrilla, dtpFechaDesde.Value, dtpFechaHasta.Value);
            }
            else
            {
               ActualizarDatos(dgvGrilla,txtBusqueda.Text);
            }
        }
    }
}
