using System;
using System.Windows.Forms;
using Servicio.Interfaces.Cheque;
using Servicio.Interfaces.Cheque.DTOs;

namespace Presentacion.Core.Cheque
{
    using Presentacion.FormularioBase;

    public partial class _00133_Cheques : Formulario
    {
        private readonly IChequeServicio _chequeServicio;
        private ChequeDto _chequeSeleccionado;

        public _00133_Cheques(IChequeServicio chequeServicio)
        {
            InitializeComponent();
            _chequeServicio = chequeServicio;
            AsignarEvento_EnterLeave(this);
            ActualizarNoRechazados(dgvCheques,string.Empty);
            ActualizarRechazados(dgvRechazados, string.Empty); 
        }

        private void ActualizarRechazados(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _chequeServicio.GetChequesRechazados(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public void ActualizarNoRechazados(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _chequeServicio.GetChequesNoRechazados(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public void ActualizarNoRechazadosPorFecha(DataGridView dgv, DateTime desde, DateTime hasta)
        {
            dgv.DataSource = _chequeServicio.GetPorFechaNoRechazados(desde, hasta);
            FormatearGrilla(dgv);
        }

        public void ActualizarRechazadosPorFecha(DataGridView dgv, DateTime desde, DateTime hasta)
        {
            dgv.DataSource = _chequeServicio.GetPorFechaRechazados(desde, hasta);
            FormatearGrilla(dgv);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarNoRechazados(dgvCheques, string.Empty);
            ActualizarRechazados(dgvRechazados, string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarNoRechazadosPorFecha(dgvCheques, dateTimePicker1.Value, dateTimePicker2.Value);
            ActualizarRechazadosPorFecha(dgvRechazados, dateTimePicker1.Value, dateTimePicker2.Value);
            //dateTimePicker1.Value = DateTime.Today;
            //dateTimePicker2.Value = DateTime.Today;
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].HeaderText = "Numero";
            dgv.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["FechaVencimiento"].Visible = true;
            dgv.Columns["FechaVencimiento"].HeaderText = "FechaVencimiento";
            dgv.Columns["FechaVencimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaRechazado"].Visible = true;
            dgv.Columns["EstaRechazado"].HeaderText = "Esta Rechazado";
            dgv.Columns["EstaRechazado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(dgv);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCheques_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheques.RowCount > 0)
            {
                _chequeSeleccionado = (ChequeDto)dgvCheques.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void btnRechazado_Click(object sender, EventArgs e)
        {

            if (_chequeSeleccionado != null)
            {
            _chequeServicio.UpdateRechazarCheque(_chequeSeleccionado);
            btnActualizar.PerformClick();
            }
        }

        

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            var fDepositarCheque = new _00136_DepositarCheque(_chequeSeleccionado);
            fDepositarCheque.Show();
        }
    }
}
