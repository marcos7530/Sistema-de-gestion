using System.Linq;
using Aplicacion.Constantes.Clases;
using Aplicacion.Constantes.Imagenes;
using Servicio.Interfaces.Caja;
using Servicio.Interfaces.Comprobante.DTOs;

namespace Presentacion.Core.FormaPago
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Comprobante;

    public partial class _00177_CobroFactura : Formulario
    {/*
        private readonly IFacturaServicio _facturaServicio;
        private readonly ICajaServicio _cajaServicio;

        private FacturaDto _nuevaFactura;

        public _00177_CobroFactura(IFacturaServicio facturaServicio, ICajaServicio cajaServicio)
        {
            InitializeComponent();

            _facturaServicio = facturaServicio;
            _cajaServicio = cajaServicio;

            _nuevaFactura = null;

            btnSalir.Image = Imagen.Salir;
            btnFacturar.Image = Imagen.Grabar;

            Observable.Interval(TimeSpan.FromSeconds(30))
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(_ =>
                {
                    dgvFacturas.DataSource = _facturaServicio.ObtenerPendientesDePagos();
                    FormatearGrilla(dgvFacturas);
                });
        }*/

        private void _00177_CobroFactura_Load(object sender, System.EventArgs e)
        {/*
            dgvFacturas.DataSource = _facturaServicio.ObtenerPendientesDePagos();
            FormatearGrilla(dgvFacturas);*/
        }
        /*
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNomCliente"].Visible = true;
            dgv.Columns["ApyNomCliente"].HeaderText = "Cliente";
            dgv.Columns["ApyNomCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Total"].Visible = true;
            dgv.Columns["Total"].HeaderText = "Monto Pagar";
            dgv.Columns["Total"].Width = 150;

            CentrarCabecerasGrilla(dgv);
        }
        */
        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void dgvFacturas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {/*
            if (dgvFacturas.RowCount > 0)
            {
                _nuevaFactura = (FacturaDto) dgvFacturas.Rows[e.RowIndex].DataBoundItem;

                if (_nuevaFactura == null) return;

                dgvDetalle.DataSource = _nuevaFactura.Items.ToList();

                FormatearGrillaDetalle();

                nudTotal.Value = _nuevaFactura.Total;
            }
            else
            {
                _nuevaFactura = null;
            }*/
        }
        /*
        private void FormatearGrillaDetalle()
        {
            for (int i = 0; i < dgvDetalle.ColumnCount; i++)
            {
                dgvDetalle.Columns[i].Visible = false;
            }

            dgvDetalle.Columns["Descripcion"].Visible = true;
            dgvDetalle.Columns["Descripcion"].HeaderText = "Articulo";
            dgvDetalle.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDetalle.Columns["Cantidad"].Visible = true;
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalle.Columns["Cantidad"].Width = 100;
        }
        */
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.RowCount > 0)
            {/*
                if (_nuevaFactura != null)
                {
                    _nuevaFactura.CajaId = IdentidadUsuarioLogin.CajaId;

                    _nuevaFactura.EstadoFactura = EstadoFactura.Pagada;

                    var formaPago = new FormaPago(_nuevaFactura);
                    formaPago.ShowDialog();

                    if (!formaPago.RealizoLaFacturacion) return;

                    dgvDetalle.DataSource = null;
                    dgvFacturas.DataSource = _facturaServicio.ObtenerPendientesDePagos();
                    
                    FormatearGrilla(dgvFacturas);
                }
            }
            else
            {*/
                MessageBox.Show("No hay facturas pendientes");
            }
        }
        
        private void dgvFacturas_DoubleClick(object sender, EventArgs e)
        {
            btnFacturar.PerformClick();
        }
    }
}
