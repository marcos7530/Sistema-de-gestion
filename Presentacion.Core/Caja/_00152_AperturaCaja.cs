namespace Presentacion.Core.Caja
{
    using Aplicacion.Constantes.Clases;
    using FormularioBase;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Usuario;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class _00152_AperturaCaja : Formulario
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        public _00152_AperturaCaja( ICajaServicio cajaServicio,
                                    IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();
            _cajaServicio = cajaServicio;
            _usuarioServicio = usuarioServicio;
        }

        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            try
            {

                long usuarioId = _usuarioServicio.Get(IdentidadUsuarioLogin.NombreEmpleado).FirstOrDefault().Id;
                IdentidadUsuarioLogin.CajaId =  _cajaServicio.AbrirCaja(
                    new Servicio.Interfaces.Caja.DTOs.CajaAperturaDto
                {
                    EstaEliminado = false,
                    UsuarioAperturaId = usuarioId,
                    MontoInicial = nudMonto.Value,
                    FechaApertura = DateTime.Now
                });
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"ERROR AL ABRIR CAJA {exception.Message}");
            }
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            nudMonto.Value = 0m;
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {

            this.Close();
        }
    }
}
