using System.Windows.Forms;

namespace Presentacion.Core.Administracion
{
    using System;
    using Aplicacion.Constantes.Clases;
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Provincia;

    public partial class _90000_ConfiguracionSistema : Formulario
    {
        IConfiguracionServicio _configuracionServicio;
        IProvinciaServicio _provinciaServicio;
        ILocalidadServicio _localidadServicio;
        IListaPrecioServicio _listaPrecioServicio;

        public _90000_ConfiguracionSistema( IConfiguracionServicio configuracionServicio,
                                            IProvinciaServicio provinciaServicio,
                                            ILocalidadServicio localidadServicio,
                                            IListaPrecioServicio listaPrecioServicio)
        {
            InitializeComponent();
            _configuracionServicio = configuracionServicio;
            _provinciaServicio = provinciaServicio;
            _localidadServicio = localidadServicio;
            _listaPrecioServicio = listaPrecioServicio;

            AgregarControlesObligatorios(txtRazonSocial, "Nombre de la empresa");
            AgregarControlesObligatorios(txtDireccion, "Direccion");

            CargarDatos();
            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(txtRazonSocial, "Razon Social");
            AgregarControlesObligatorios(txtCUIL, "Cuil");
            AgregarControlesObligatorios(txtTelefono, "Telefono");
            AgregarControlesObligatorios(txtCelular, "Celular");
            AgregarControlesObligatorios(txtDireccion, "Direccion");
            AgregarControlesObligatorios(txtEmail, "Mail");
            AgregarControlesObligatorios(cmbTipoPagoCompraPorDefecto, "Tipo de PagoCompra Por Defecto");
            AgregarControlesObligatorios(cmbTipoPagoPorDefecto, "Lista Precio Por Defecto");
            AgregarControlesObligatorios(cmbProvincia, "Provincia");
            AgregarControlesObligatorios(cmbLocalidad, "Localidad");
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text)) return false;
            if (string.IsNullOrEmpty(txtCUIL.Text)) return false;
            if (string.IsNullOrEmpty(txtTelefono.Text)) return false;
            if (string.IsNullOrEmpty(txtCelular.Text)) return false;
            if (string.IsNullOrEmpty(txtDireccion.Text)) return false;
            if (string.IsNullOrEmpty(txtEmail.Text)) return false;

            if (cmbTipoPagoCompraPorDefecto.Items.Count <= 0) return false;
            if (cmbTipoPagoPorDefecto.Items.Count <= 0) return false;
            if (cmbProvincia.Items.Count <= 0) return false;
            if (cmbLocalidad.Items.Count <= 0) return false;

            return true;
        }

        private void CargarDatos()
        {
            var prov = _provinciaServicio.Get(string.Empty);
            var loca = _localidadServicio.Get(string.Empty);
            var listaPrecios = _listaPrecioServicio.Get(string.Empty);

            if (prov != null) Poblar_ComboBox(cmbProvincia, prov, "Descripcion", "Id");
            if (loca != null) Poblar_ComboBox(cmbLocalidad, loca, "Descripcion", "Id");
            if (listaPrecios != null) Poblar_ComboBox(cmbTipoPagoPorDefecto, listaPrecios, "Descripcion", "Id");
            Poblar_ComboBox(cmbTipoPagoCompraPorDefecto, Enum.GetValues(typeof(TipoPago)));

            var conf = _configuracionServicio.Get();
            if (conf != null)
            {
                txtRazonSocial.Text = conf.RazonSocial;
                txtCUIL.Text = conf.Cuit;
                txtTelefono.Text = conf.Telefono;
                txtCelular.Text = conf.Celular;
                txtDireccion.Text = conf.Direccion;
                cmbProvincia.SelectedValue = conf.ProvinciaId;
                cmbLocalidad.SelectedValue = conf.LocalidadId;
                txtEmail.Text = conf.Email;

                chkFacturaDescuentaStock.Checked = conf.FacturaDescuentaStock;
                chkPresupuestoDescuentaStock.Checked = conf.PresupuestoDescuentaStock;
                chkRemitoDescuentaStock.Checked = conf.ActualizaCostoDesdeCompra;
                chkModificaPrevioVentaDesdeCompra.Checked = conf.ModificaPrecioVentaDesdeCompra;
                cmbTipoPagoCompraPorDefecto.SelectedItem = conf.TipoPagoCompraPorDefecto;

                cmbTipoPagoPorDefecto.SelectedValue = conf.ListaPrecioPorDefectoVentaId;
                txtObservacionFactura.Text = conf.ObservacionEnPieFactura;
                chkRenglonesFactura.Checked = conf.UnificarRenglonesIngresarMismoProducto;
                chkCajaSeparada.Checked = conf.CajaSeparada;

                if (conf.IngresoManualCajaInicial)
                {
                    rdbIngresoManualCaja.Checked = true;
                    rdbIngresoPorCierreDelDIaAnterior.Checked = false;
                }
                else
                {
                    rdbIngresoManualCaja.Checked = false;
                    rdbIngresoPorCierreDelDIaAnterior.Checked = true;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            _configuracionServicio.Grabar(new Servicio.Interfaces.Configuracion.DTOs.ConfiguracionDto
            {               
                EstaEliminado = false,
                RazonSocial = txtRazonSocial.Text,
                Cuit = txtCUIL.Text,
                Telefono = txtTelefono.Text,
                Celular = txtCelular.Text,
                Direccion = txtDireccion.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Email = txtEmail.Text,

                FacturaDescuentaStock = chkFacturaDescuentaStock.Checked,
                PresupuestoDescuentaStock = chkPresupuestoDescuentaStock.Checked,
                RemitoDescuentaStock = chkRemitoDescuentaStock.Checked,
                ModificaPrecioVentaDesdeCompra = chkModificaPrevioVentaDesdeCompra.Checked,

                TipoPagoCompraPorDefecto = (TipoPago)cmbTipoPagoCompraPorDefecto.SelectedItem,
                ListaPrecioPorDefectoVentaId = (long)cmbTipoPagoPorDefecto.SelectedValue,
                ObservacionEnPieFactura = txtObservacionFactura.Text,
                UnificarRenglonesIngresarMismoProducto = chkRenglonesFactura.Checked,
                CajaSeparada = chkCajaSeparada.Checked,
                IngresoManualCajaInicial = rdbIngresoManualCaja.Checked ? true : false
            }) ;
        }
    }
}
