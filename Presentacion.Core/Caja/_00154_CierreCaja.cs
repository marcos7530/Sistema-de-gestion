namespace Presentacion.Core.Caja
{
    using System;
    using Aplicacion.Constantes.Clases;
    using FormularioBase;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Caja.DTOs;
    using Servicio.Interfaces.Usuario;
    using StructureMap;

    public partial class _00154_CierreCaja : Formulario
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private CajaDto _caja;

        public _00154_CierreCaja(CajaDto cajaSeleccionada)
        {
            InitializeComponent();
            _cajaServicio = ObjectFactory.GetInstance<ICajaServicio>();
            _usuarioServicio = ObjectFactory.GetInstance<IUsuarioServicio>();
            _caja = cajaSeleccionada;
            CargarDatos();
        }

        private void CargarDatos()
        {
            decimal _totalIngresosEfectivo = 0m;
            decimal _totalEgresosEfectivo = 0m;

            decimal _totalIngresosTarjeta = 0m;
            decimal _totalEgresosTarjeta = 0m;

            decimal _totalIngresosCtaCte = 0m;
            decimal _totalEgresosCtaCte = 0m;

            decimal _totalIngresosCheque = 0m;
            decimal _totalEgresosCheque = 0m;

            foreach (var d in _caja.DetalleCajas)
            {
                if (d.TipoPago == Aplicacion.Constantes.Clases.TipoPago.Efectivo)
                {
                    txtIngresoEfectivo.Text = d.Monto.ToString("C");
                    _totalIngresosEfectivo += d.Monto;
                }
                if (d.TipoPago == Aplicacion.Constantes.Clases.TipoPago.Cheque)
                {
                    txtIngresoCheque.Text = d.Monto.ToString("C");
                    _totalIngresosCheque += d.Monto;
                }
                if (d.TipoPago == Aplicacion.Constantes.Clases.TipoPago.Tarjeta)
                {
                    txtIngresoTarjeta.Text = d.Monto.ToString("C");
                    _totalIngresosTarjeta += d.Monto;
                }
                if (d.TipoPago == Aplicacion.Constantes.Clases.TipoPago.CtaCte)
                {
                    txtIngresoCtaCte.Text = d.Monto.ToString("C");
                    _totalIngresosCtaCte += d.Monto;
                }
            }
            txtMontoInicial.Text = _caja.MontoInicial.ToString("C");
            lblFechaApertura.Text = $"Fecha Apertura {_caja.FechaApertura.ToShortDateString()}";
            txtIngresoEfectivo.Text = _totalIngresosEfectivo.ToString("C");
            txtIngresoCheque.Text = _totalIngresosCheque.ToString("C");
            txtIngresoCtaCte.Text = _totalIngresosCtaCte.ToString("C");
            txtIngresoTarjeta.Text = _totalIngresosTarjeta.ToString("C");
            _caja.TotalVentaEfectivo = _totalIngresosEfectivo;
            _caja.TotalChequeEntrada = _totalIngresosCheque;
            _caja.TotalCuentaCorrienteEntrada = _totalIngresosCtaCte;
            _caja.TotalTarjetaEntrada = _totalIngresosTarjeta;

            _caja.MontoCierre = _caja.MontoInicial + _totalIngresosCheque + _totalIngresosCtaCte + _totalIngresosTarjeta + _totalIngresosEfectivo
                - _totalEgresosCtaCte - _totalEgresosCheque - _totalEgresosTarjeta - _totalEgresosEfectivo;
            txtTotalEfectivo.Text = _caja.MontoCierre.Value.ToString("C");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            _caja.UsuarioCierreId = _usuarioServicio.GetByUser(IdentidadUsuarioLogin.NombreUsuario).Id;
            _cajaServicio.CerrarCaja(_caja);
            CargarDatos();
        }
    }
}
