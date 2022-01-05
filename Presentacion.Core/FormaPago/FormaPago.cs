namespace Presentacion.Core.FormaPago
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.Core.LookUp;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Caja.DTOs;
    using Servicio.Interfaces.Comprobante;
    using Servicio.Interfaces.Comprobante.DTOs;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Tarjeta;
    using StructureMap;

    public partial class FormaPago : Formulario
    {
        private readonly FacturaDto _factura;
        private readonly ITarjetaServicio _tarjetaServicio;
        private readonly IFacturaServicio _facturaServicio;
        private readonly ICajaServicio _cajaServicio;
        private readonly IClienteServicio _clienteServicio;
        private ClienteDto clientCtaCte;
        public FormaPago(FacturaDto factura)
        {
            InitializeComponent();
            _factura = factura;
            _tarjetaServicio = ObjectFactory.GetInstance<ITarjetaServicio>();
            _facturaServicio = ObjectFactory.GetInstance<IFacturaServicio>();
            _cajaServicio = ObjectFactory.GetInstance<ICajaServicio>();
            _clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
            clientCtaCte = null;
            Inicializar();
        }

        private void Inicializar()
        {
            if (_factura.EstadoComprobante == Aplicacion.Constantes.Clases.EstadoComprobante.Pagado)
            {
                MessageBox.Show("COMPROBANTE PAGADO");
                this.Close();
            }
            txtTotalAbonar.Text = _factura.Total.ToString("C");
            var _tarjetas = _tarjetaServicio.Get(string.Empty);
            if (_tarjetas!= null)
            {
                Poblar_ComboBox(cmbTarjeta, _tarjetas, "Descripcion", "Id");
                nudTotalTarjeta.Enabled = true;
            }
            
        }

        private void tabPage4_Click(object sender, System.EventArgs e)
        {

        }

        private void nudMontoEfectivo_ValueChanged(object sender, EventArgs e)
        {
            nudTotalEfectivo.Value = nudMontoEfectivo.Value;
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            nudTotal.Value = nudTotalEfectivo.Value + nudTotalTarjeta.Value + nudTotalCheque.Value + nudTotalCtaCte.Value;
        }

        private void nudMontoTarjeta_ValueChanged(object sender, EventArgs e)
        {
            nudTotalTarjeta.Value = nudMontoTarjeta.Value;
            
            if (nudMontoTarjeta.Value != 0)
            {
                txtNumeroTarjeta.Enabled = true;
                txtCuponPago.Enabled = true;
                nudCantidadCuotas.Enabled = true;
            }

            ActualizarTotal();
        }

        private void nudMontoCheque_ValueChanged(object sender, EventArgs e)
        {
            nudTotalCheque.Value = nudMontoCheque.Value;
            ActualizarTotal();
        }

        private void nudMotoCtaCte_ValueChanged(object sender, EventArgs e)
        {
            nudTotalCtaCte.Value = nudMotoCtaCte.Value;
            ActualizarTotal();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (nudTotal.Value == 0 || nudTotal.Value > _factura.Total)
            {
                MessageBox.Show("INGRESE UN MONTO VALIDO PARA ABONAR");
                return;
            }
            long _cajaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            _factura.CajaId = _cajaId;

            if (nudTotalEfectivo.Value > 0)
            {
                _factura.PagoEfectivoDto = new Servicio.Interfaces.FormaPago.DTOs.FormaPagoEfectivoDto
                {
                    Monto = nudTotalEfectivo.Value,
                    ClienteId = _factura.CajaId,
                    TipoPago = Aplicacion.Constantes.Clases.TipoPago.Efectivo
                };
            }

            if (nudTotalCheque.Value > 0)
            {
                _factura.PagoChequeDto = new Servicio.Interfaces.FormaPago.DTOs.FormaPagoChequeDto
                {
                    Numero = txtNumeroCheque.Text,
                    TipoPago = Aplicacion.Constantes.Clases.TipoPago.Cheque,
                    BancoId = (long)cmbBanco.SelectedItem,
                    ClienteId = 1, //die hard code
                    FechaVencimiento = dtpFechaVencimientoCheque.Value,
                    Monto = nudTotalCheque.Value                    
                };
            }

            if (nudTotalCtaCte.Value > 0)
            {
                _factura.PagoCtaCteDto = new Servicio.Interfaces.FormaPago.DTOs.FormaPagoCtaCteDto
                {
                    ClienteId = clientCtaCte.Id, 
                    Monto = nudTotalCtaCte.Value,
                    TipoPago = Aplicacion.Constantes.Clases.TipoPago.CtaCte
                };
            }

            if (nudTotalTarjeta.Value > 0)
            {
                if ( string.IsNullOrEmpty(txtNumeroTarjeta.Text) ||
                     string.IsNullOrEmpty(txtCuponPago.Text) )
                {
                    MessageBox.Show("COMPLETE LOS DATOS NECESARIOS DE LA TARJETA");
                    return;
                }

                _factura.PagoTarjetaDto = new Servicio.Interfaces.FormaPago.DTOs.FormaPagoTarjetaDto
                {
                    ComprobanteId = _factura.Id,
                    Monto = nudTotalTarjeta.Value,
                    TipoPago = Aplicacion.Constantes.Clases.TipoPago.Tarjeta,
                    CantidadCuotas = (int)nudCantidadCuotas.Value,
                    CuponPago = txtCuponPago.Text,
                    NumeroTarjeta = txtNumeroTarjeta.Text,
                    TarjetaId = (long)cmbTarjeta.SelectedValue
                };
            }            

            try
            {
                _facturaServicio.Grabar(_factura);

            }
            catch (Exception ed)
            {
                MessageBox.Show($"NI IDEA {ed.Message}");
            }
            MessageBox.Show("ESTA HECHO");
            this.Close();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = new LookUpCliente();
            fLookUpCliente.ShowDialog();
            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                
                var _cliente = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                clientCtaCte = (ClienteDto)_clienteServicio.GetById(typeof(ClienteDto), _cliente.Id);
                if (clientCtaCte.ActivarCtaCte)
                {
                    txtApellido.Text = clientCtaCte.Apellido;
                    txtNombre.Text = clientCtaCte.Nombre;
                    txtDni.Text = clientCtaCte.Dni;
                    txtCUIL.Text = clientCtaCte.Cuil;
                    txtCelular.Text = clientCtaCte.Celular;
                    txtTelefono.Text = clientCtaCte.Telefono;
                    txtMontoAdeudado.Text = clientCtaCte.Movimientos.Any()
                        ? clientCtaCte.Movimientos.Sum(x => x.Monto).ToString("C")
                        : "$ 0.00";
                }
                else
                {
                    MessageBox.Show("EL CLIENTE NO TIENE CUENTA CORRIENTE ACTIVA", "ADVERTENCIA");
                }
            }
        }

        private void FormaPago_Load(object sender, EventArgs e)
        {
            var _cliente = (ClienteDto)_clienteServicio.GetById(typeof(ClienteDto), _factura.ClienteFacturaId);
            if (_cliente != null)
            {
                if (_cliente.ActivarCtaCte)
                {
                    txtApellido.Text = _cliente.Apellido;
                    txtNombre.Text = _cliente.Nombre;
                    txtDni.Text = _cliente.Dni;
                    txtCUIL.Text = _cliente.Cuil;
                    txtCelular.Text = _cliente.Celular;
                    txtTelefono.Text = _cliente.Telefono;
                    txtMontoAdeudado.Text = _cliente.Movimientos.Any()
                        ? _cliente.Movimientos.Sum(x => x.Monto).ToString("C")
                        : "$ 0.00";
                }
            }
        }
    }
}
