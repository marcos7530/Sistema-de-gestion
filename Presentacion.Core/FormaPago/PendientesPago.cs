namespace Presentacion.Core.FormaPago
{
    using System;
    using System.Windows.Forms;
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Comprobante;
    using Servicio.Interfaces.Comprobante.DTOs;
    using Servicio.Interfaces.DetalleComprobante.DTOs;

    public partial class PendientesPago : Formulario
    {
        private readonly IFacturaServicio _facturaServicio;
        private FacturaDto _factura;
        public PendientesPago(IFacturaServicio facturaServicio)
        {
            InitializeComponent();
            _facturaServicio = facturaServicio;
            _factura = null;
            InicializarGrilla();
        }

        private void InicializarGrilla()
        {
            dgvGrillaPendientes.DataSource = null;

            var pendientes = _facturaServicio.ObtenerPendientesDePagos();
            
            dgvGrillaPendientes.DataSource = pendientes;
            
            FormatearGrilla(dgvGrillaPendientes);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ClienteFacturaId"].Visible = true;
            dgv.Columns["ClienteFacturaId"].Width = 50;
            dgv.Columns["ClienteFacturaId"].HeaderText = "Cliente Id";

            dgv.Columns["ApyNomCliente"].Visible = true;
            dgv.Columns["ApyNomCliente"].HeaderText = "Total";
            dgv.Columns["ApyNomCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Total"].Visible = true;
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["Total"].Width = 100;
            CentrarCabecerasGrilla(dgv);
        }

        private void dgvGrillaPendientes_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvGrillaPendientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount > 0)
            {
                _factura = (FacturaDto)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
                if (_factura.Items != null)
                {
                    dgvGrillaDetalles.DataSource = _factura.Items;
                    
                    for (int i = 0; i < dgvGrillaDetalles.ColumnCount; i++)
                    {
                        dgvGrillaDetalles.Columns[i].Visible = false;
                    }

                    dgvGrillaDetalles.Columns["ArticuloId"].Visible = true;
                    dgvGrillaDetalles.Columns["ArticuloId"].HeaderText = "Id Art.";
                    dgvGrillaDetalles.Columns["ArticuloId"].Width = 50;

                    dgvGrillaDetalles.Columns["Descripcion"].Visible = true;
                    dgvGrillaDetalles.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvGrillaDetalles.Columns["Descripcion"].HeaderText = "Descripción";

                    dgvGrillaDetalles.Columns["Cantidad"].Visible = true;
                    dgvGrillaDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
                    dgvGrillaDetalles.Columns["Cantidad"].Width = 100;

                    nudTotal.Value = _factura.Total;
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            if (_factura.Items != null)
            {
                var fPago = new Presentacion.Core.FormaPago.FormaPago(_factura);
                fPago.Show();
            }

            InicializarGrilla();

        }
    }
}
