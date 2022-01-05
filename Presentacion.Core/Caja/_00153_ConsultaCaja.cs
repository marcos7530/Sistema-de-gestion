namespace Presentacion.Core.Caja
{
    using System;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using FormularioBase;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Caja.DTOs;
    using Servicio.Interfaces.Seguridad;
    using StructureMap;

    public partial class _00153_ConsultaCaja : Formulario
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly ISeguridadServicio _seguridadServicio;
        private CajaDto _cajaSeleccionada;

        public _00153_ConsultaCaja(ICajaServicio cajaServicio,
                                    ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();
            _cajaServicio = cajaServicio;
            _seguridadServicio = seguridadServicio;
            _cajaSeleccionada = null;
            ActualizarCaja();
            PoblarGrilla();
        }

        private void ActualizarCaja()
        {
        }

        private void PoblarGrilla()
        {
            var _cajas = _cajaServicio.GetCajas();
            dgvGrilla.DataSource = _cajas;
            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["UsuarioApertura"].Visible = true;
            dgv.Columns["UsuarioApertura"].HeaderText = "Apertura:";
            dgv.Columns["UsuarioApertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["MontoInicial"].Visible = true;
            dgv.Columns["MontoInicial"].HeaderText = "Monto Inicial:";
            dgv.Columns["MontoInicial"].Width = 70;

            dgv.Columns["FechaApertura"].Visible = true;
            dgv.Columns["FechaApertura"].HeaderText = "Apertura:";
            dgv.Columns["FechaApertura"].Width = 120;

            dgv.Columns["TotalVentaEfectivo"].Visible = true;
            dgv.Columns["TotalVentaEfectivo"].HeaderText = "Efectivo ↑";
            dgv.Columns["TotalVentaEfectivo"].Width = 60;

            dgv.Columns["TotalCobranzaEfectivo"].Visible = true;
            dgv.Columns["TotalCobranzaEfectivo"].HeaderText = "Efectivo ↓";
            dgv.Columns["TotalCobranzaEfectivo"].Width = 60;

            dgv.Columns["TotalTarjetaEntrada"].Visible = true;
            dgv.Columns["TotalTarjetaEntrada"].HeaderText = "Tarjeta ↑";
            dgv.Columns["TotalTarjetaEntrada"].Width = 60;

            dgv.Columns["TotalTarjetaSalida"].Visible = true;
            dgv.Columns["TotalTarjetaSalida"].HeaderText = "Tarjetas ↓";
            dgv.Columns["TotalTarjetaSalida"].Width = 60;

            dgv.Columns["TotalChequeEntrada"].Visible = true;
            dgv.Columns["TotalChequeEntrada"].HeaderText = "Cheques ↑";
            dgv.Columns["TotalChequeEntrada"].Width = 60;

            dgv.Columns["TotalChequeSalida"].Visible = true;
            dgv.Columns["TotalChequeSalida"].HeaderText = "Cheques ↓";
            dgv.Columns["TotalChequeSalida"].Width = 60;

            dgv.Columns["TotalCuentaCorrienteEntrada"].Visible = true;
            dgv.Columns["TotalCuentaCorrienteEntrada"].HeaderText = "Cta. Ctes ↑";
            dgv.Columns["TotalCuentaCorrienteEntrada"].Width = 60;
                       
            dgv.Columns["TotalCuentaCorrienteSalida"].Visible = true;
            dgv.Columns["TotalCuentaCorrienteSalida"].HeaderText = "Cta. Ctes ↓";
            dgv.Columns["TotalCuentaCorrienteSalida"].Width = 60;

            CentrarCabecerasGrilla(dgv);
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            PoblarGrilla();
        }

        private void ActulizarGrilla()
        {
            dgvGrilla.DataSource = _cajaServicio.Get(dtpFechaDesde.Value, dtpFechaHasta.Value, txtBusqueda.Text);
            FormatearGrilla(dgvGrilla);
        }
                

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _cajaSeleccionada = (CajaDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_cajaSeleccionada.FechaCierre == null)
            {
                if (_cajaSeleccionada != null && _cajaSeleccionada.DetalleCajas != null)
                {
                    var fCierreCaja = new _00154_CierreCaja(_cajaSeleccionada);
                    fCierreCaja.Show();
                }
            }
            else
                MessageBox.Show($"La caja ya se cerró el:{_cajaSeleccionada.FechaCierre.ToString()}","ADVERTENCIA");
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId != 0)
            {
                IdentidadUsuarioLogin.CajaId = cajaViejaId;
                MessageBox.Show("Existe una caja abierta");
                return;
            }


            var fActualizaPrecio = ObjectFactory.GetInstance<_00152_AperturaCaja>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fActualizaPrecio.Name))
            {
                fActualizaPrecio.ShowDialog();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
