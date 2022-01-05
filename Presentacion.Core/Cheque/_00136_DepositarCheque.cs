using System;
using System.Windows.Forms;
using Presentacion.Core.Caja;
using Presentacion.Core.LookUp;
using Servicio.Interfaces.Banco;
using Servicio.Interfaces.Banco.DTOs;
using Servicio.Interfaces.Cheque;
using Servicio.Interfaces.Cheque.DTOs;
using Servicio.Interfaces.CuentaBancaria.DTOs;
using Servicio.Interfaces.DepositoCheque;
using Servicio.Interfaces.DepositoCheque.DTOs;
using StructureMap;

namespace Presentacion.Core.Cheque
{
    using FormularioBase;

    public partial class _00136_DepositarCheque : Formulario
    {
        private readonly IChequeServicio _chequeServicio;
        private readonly IBancoServicio _bancoServicio;
        private readonly IDepositoChequeServicio _depositoChequeServicio;

        private ChequeDto _cheque;
        private CuentaBancariaDto _cuenta;


        public _00136_DepositarCheque(ChequeDto chequeSeleccionado)
        {
            InitializeComponent();

            _cheque = chequeSeleccionado;
            _chequeServicio = ObjectFactory.GetInstance<IChequeServicio>();
            _bancoServicio= ObjectFactory.GetInstance<IBancoServicio>();
            _depositoChequeServicio = ObjectFactory.GetInstance<IDepositoChequeServicio>();

            AsignarEvento_EnterLeave(this);


            CargarDatos(_cheque);
            CargarDatosObligatorios();

        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(txtBancoDestino, "Banco Destino");
            AgregarControlesObligatorios(txtNumeroCuentaDestino, "Numero Cuenta Destino");
            AgregarControlesObligatorios(txtTitularDestino, "Titular Cuenta Destino");
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtBancoDestino.Text)) return false;
            if (string.IsNullOrEmpty(txtNumeroCuentaDestino.Text)) return false;
            if (string.IsNullOrEmpty(txtTitularDestino.Text)) return false;

            return true;
        }

        private void CargarDatos(ChequeDto cheque)
        {
            txtBancoOrigen.Enabled =false;
            txtNroCheque.Enabled = false;
            txtMonto.Enabled = false;
            txtFechaVencimiento.Enabled = false;

            var _banco = _bancoServicio.GetById(cheque.BancoId);

            txtBancoOrigen.Text = _banco.Descripcion;
            txtNroCheque.Text = cheque.Numero;
            txtMonto.Text = cheque.Monto.ToString();
            txtFechaVencimiento.Text = cheque.FechaVencimiento.ToShortDateString();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            _depositoChequeServicio.Add(new DepositoChequeDto
            {
                ChequeId = _cheque.Id,
                CuentaBancariaId = _cuenta.Id,
                Fecha = _cheque.FechaVencimiento
            });



        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBancoDestino.Clear();
            txtNumeroCuentaDestino.Clear();
            txtTitularDestino.Clear();
        }

        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            //ESTO ES SE USA EN EL CASO DE QUE USE EL LOOKUP PARA PONER EL CLIENTE EN UN TEXTBOX

            var fLookUpCuentasBancarias = ObjectFactory.GetInstance<LookUpCuentaBancaria>();
            fLookUpCuentasBancarias.ShowDialog();
            if (fLookUpCuentasBancarias.EntidadSeleccionada != null)
            {
                var cuentaSeleccionada = (CuentaBancariaDto)fLookUpCuentasBancarias.EntidadSeleccionada;
                AgregarDatosCliente(cuentaSeleccionada);
                _cuenta = cuentaSeleccionada;
            }
        }

        private void AgregarDatosCliente(CuentaBancariaDto cuentaSeleccionada)
        {
            var nombreBancoDestino = _bancoServicio.GetById(cuentaSeleccionada.BancoId);

            txtBancoDestino.Text = nombreBancoDestino.Descripcion;
            txtNumeroCuentaDestino.Text = cuentaSeleccionada.Numero;
            txtTitularDestino.Text = cuentaSeleccionada.Titular;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
