using Presentacion.Core.Cheque;
using Presentacion.Core.Compra;
using Presentacion.Core.Comprobantes;

namespace X_Commerce
{
    using Aplicacion.Constantes.Clases;
    using System;
    using System.Windows.Forms;
    using Presentacion.Core;
    using Presentacion.Core.Articulo;
    using Presentacion.Core.Cliente;
    using Presentacion.Core.Proveedor;
    using Presentacion.Core.Venta;
    using Presentacion.FormularioBase.Helpers;
    using Presentacion.Seguridad;
    using Servicio.Interfaces.Seguridad;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.IdentidadUsuarioLogin;
    using Presentacion.Core.Administracion;
    using Servicio.Interfaces.ListaPrecio;
    using System.Linq;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Caja;
    using Presentacion.Core.Caja;
    using Presentacion.Core.FormaPago;

    public partial class Principal : Form
    {
        private readonly ISeguridadServicio _seguridadServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly ICajaServicio _cajaServicio;

        public Principal( ISeguridadServicio seguridadServicio,
                          IListaPrecioServicio listaPrecioServicio,
                          IArticuloServicio articuloServicio,
                          IClienteServicio clienteServicio,
                          ICajaServicio cajaServicio)
        {
            InitializeComponent();

            _seguridadServicio = seguridadServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _articuloServicio = articuloServicio;
            _clienteServicio = clienteServicio;
            _cajaServicio = cajaServicio;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            imgFotoEmpleado.Image = FotoEmpleado;
            lblUsuarioLogin.Text = IdentidadUsuarioLogin.ApyNom/*SaludoUsuarioLogin*/;
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Desea salir del Sistema ?",
                    "Atención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ConsultaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaEmpleado = ObjectFactory.GetInstance<_00001_Empleado>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaEmpleado.Name))
            {
                fConsultaEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeProvinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaProvicnia = ObjectFactory.GetInstance<_00005_Provincia>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaProvicnia.Name))
            {
                fConsultaProvicnia.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaCliente = ObjectFactory.GetInstance<_00110_Cliente>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCliente.Name))
            {
                fConsultaCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoCliente = new _00111_Abm_Cliente(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoCliente.Name))
            {
                fNuevoCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoEmpleado = new _00002_Abm_Empleado(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoEmpleado.Name))
            {
                fNuevoEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaProveedor = ObjectFactory.GetInstance<_00117_Proveedor>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaProveedor.Name))
            {
                fConsultaProveedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoProveedor = new _00118_Abm_Proveedor(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoProveedor.Name))
            {
                fNuevoProveedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeLocalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaLocalidad = ObjectFactory.GetInstance<_00003_Localidad>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaLocalidad.Name))
            {
                fConsultaLocalidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaLocalidad = new _00004_Abm_Localidad(TipoOperacion.Nuevo, null);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaLocalidad.Name))
            {
                fNuevaLocalidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaCondicionDeIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaCondicionIva = ObjectFactory.GetInstance<_00125_CondicionIva>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCondicionIva.Name))
            {
                fConsultaCondicionIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaCondicionDeIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaCondicionIva = new _00126_Abm_CondicionIva(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaCondicionIva.Name))
            {
                fNuevaCondicionIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaProvinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00006_Abm_Provincia(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaProvincia.Name))
            {
                fNuevaProvincia.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaUsuarios_Click(object sender, EventArgs e)
        {
            var fUsuario = ObjectFactory.GetInstance<_00007_Usuario>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fUsuario.Name))
            {
                fUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.imgFotoEmpleado.Image = null;
            this.lblUsuarioLogin.Text = string.Empty;

            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (fLogin.PuedeAcceder)
            {
                this.imgFotoEmpleado.Image = FotoEmpleado;
                this.lblUsuarioLogin.Text = SaludoUsuarioLogin;
            }
            else
            {
                Application.Exit();
            }
        }

        private void FormulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fFormularios = ObjectFactory.GetInstance<_00011_Formulario>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fFormularios.Name))
            {
                // Obtiene los Assemblys de los otros Formularios
                fFormularios.TypesAssemblies.AddRange(CoreAssembly.GetAssembly.GetTypes());
                fFormularios.TypesAssemblies.AddRange(SeguridadAssembly.GetAssembly.GetTypes());

                fFormularios.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaPerfil = ObjectFactory.GetInstance<_00008_Perfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaPerfil.Name))
            {
                fConsultaPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoPerfil = new _00009_Abm_Perfil(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoPerfil.Name))
            {
                fNuevoPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AsignarQuitarUsuarioDeUnPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fUsuarioPerfil = ObjectFactory.GetInstance<_00010_UsuarioPerfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fUsuarioPerfil.Name))
            {
                fUsuarioPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AsignarQuitarFormularioDeUnPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fFormularioPerfil = ObjectFactory.GetInstance<_00012_FormularioPerfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fFormularioPerfil.Name))
            {
                fFormularioPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PuntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //conttrolar si esta abierta la caja
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId == 0)
            {
                MessageBox.Show("ABRA CAJA ANTES DE CONTINUAR");
                return;
            }
            if (!_clienteServicio.Get(typeof(ClienteDto), string.Empty).Any())
            {
                MessageBox.Show("Tiene que Loguearse para acceder a Ventas",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (!_listaPrecioServicio.Get(string.Empty).Any())
            {
                MessageBox.Show("Por favor cargue una Lista de precios antes de continuar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (!_articuloServicio.Get(string.Empty).Any())
            {
                MessageBox.Show("Por favor cargue algunos Articulos antes de continuar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            var fVenta = ObjectFactory.GetInstance<_00121_Ventas>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fVenta.Name))
            {
                fVenta.Show();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaArticulo = ObjectFactory.GetInstance<_00100_Articulo>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaArticulo.Name))
            {
                fConsultaArticulo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fConsultaIva = ObjectFactory.GetInstance<_00122_Iva>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaIva.Name))
            {
                fConsultaIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fConsultaMarca = ObjectFactory.GetInstance<_00102_Marca>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaMarca.Name))
            {
                fConsultaMarca.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fConsultaRubro = ObjectFactory.GetInstance<_00104_Rubro>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaRubro.Name))
            {
                fConsultaRubro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var fConsultaListaPrecio = ObjectFactory.GetInstance < _00155_ListaPrecio>();

            //if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaListaPrecio.Name))
            //{
            fConsultaListaPrecio.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void consultaUnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaUnidadMedida = ObjectFactory.GetInstance<_00158_UnidadMedida>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaUnidadMedida.Name))
            {
                fConsultaUnidadMedida.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00123_Abm_Iva(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ocurrió un Error. {ex.Message}");
            }
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00103_Abm_Marca(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show($@"Ocurrió un Error. {exc.Message}");
            }
        }

        private void nuevaUnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00159_Abm_UnidadMedida(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

            }
            catch (Exception exce)
            {
                MessageBox.Show($@"Ocurrió un Error. {exce.Message}");
            }
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00105_Abm_Rubro(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show($@"Ocurrió un Error. {excep.Message}");
            }
        }

        private void nuevaListaDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00156_Abm_ListaPrecio(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show($@"Ocurrió un Error. {excep.Message}");
            }
        }

        private void consultaMotivosDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaMotivoBaja = ObjectFactory.GetInstance<_00106_MotivoBajaArticulo>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaMotivoBaja.Name))
            {
                fConsultaMotivoBaja.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoMotivoDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00107_Abm_MotivoBajaArticulo(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();
            }
            catch (Exception excepc)
            {
                MessageBox.Show($@"Ocurrió un Error. {excepc.Message}");
            }
        }

        private void salidaDeMercaderíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fBajaArticulo = ObjectFactory.GetInstance<_00109_NuevaBajaDeArticulos>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fBajaArticulo.Name))
            {
                fBajaArticulo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void configuracionDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_listaPrecioServicio.Get(string.Empty).Any())
            {
                MessageBox.Show("CARGUE POR LO MENOS 1 LISTA DE PRECIOS ANTES DE CONTINUAR.",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            //controlar la caja q no existe

            var fConfiguracion = ObjectFactory.GetInstance<_90000_ConfiguracionSistema>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConfiguracion.Name))
            {
                fConfiguracion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void actualizarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fActualizaPrecio = ObjectFactory.GetInstance<_00124_ActualizacionPrecios>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fActualizaPrecio.Name))
            {
                fActualizaPrecio.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void aperturaDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId != 0)
            {
                IdentidadUsuarioLogin.CajaId = cajaViejaId;
                MessageBox.Show("EXISTE UNA CAJA ABIERTA");
                return;
            }

            //TODO opcion de la configuracion para tomar monto anterior

            var fActualizaPrecio = ObjectFactory.GetInstance<_00152_AperturaCaja>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fActualizaPrecio.Name))
            {
                fActualizaPrecio.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void consultaBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaBanco = ObjectFactory.GetInstance<_00128_Banco>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaBanco.Name))
            {
                fConsultaBanco.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00129_Abm_Banco(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void consultaDeTarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaTArjetas = ObjectFactory.GetInstance<_00130_Tarjeta>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaTArjetas.Name))
            {
                fConsultaTArjetas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevaTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00131_Abm_Tarjeta(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void consultaDeCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaCajas = ObjectFactory.GetInstance<_00153_ConsultaCaja>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCajas.Name))
            {
                fConsultaCajas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00101_Abm_Articulo(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //CONTROLA SI ESTA ABIERTA LA CAJA
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId == 0)
            {
                MessageBox.Show("ABRA CAJA, ANTES DE CONTINUAR");
                return;
            }
            if (!_clienteServicio.Get(typeof(ClienteDto), string.Empty).Any())
            {
                MessageBox.Show("PARA CONTINUAR DEBE TENER CARGADO POR LO MENOS UN CLIENTE",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (!_listaPrecioServicio.Get(string.Empty).Any())
            {
                MessageBox.Show("DEBE TENER CARGADA AL MENOS 1 LISTA DE PRECIOS PARA CONTINUAR",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (!_articuloServicio.Get(string.Empty).Any())
            {
                MessageBox.Show("DEBE TENER CARGADO AL MENOS 1 ARTICULO PARA CONTINUAR",
                                "ADVERTENCIA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            var fVenta = ObjectFactory.GetInstance<_00121_Ventas>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fVenta.Name))
            {
                fVenta.Show();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId == 0)
            {
                MessageBox.Show("DEBE ABRIR CAJA PARA CONTINUAR");
                return;
            }

            var fCobranza = ObjectFactory.GetInstance<PendientesPago>();
            fCobranza.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            long cajaViejaId = _cajaServicio.ObtenerUltimaCajaSinCerrar();
            if (cajaViejaId != 0)
            {
                IdentidadUsuarioLogin.CajaId = cajaViejaId;
                MessageBox.Show("EXIXTE UNA CAJA ABIERTA");
                return;
            }

            //TODO opcion de la configuracion para tomar monto anterior

            var fActualizaPrecio = ObjectFactory.GetInstance<_00152_AperturaCaja>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fActualizaPrecio.Name))
            {
                fActualizaPrecio.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var fConsultaCajas = ObjectFactory.GetInstance<_00153_ConsultaCaja>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCajas.Name))
            {
                fConsultaCajas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultarBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaBanco = ObjectFactory.GetInstance<_00128_Banco>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaBanco.Name))
            {
                fConsultaBanco.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoBancoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00129_Abm_Banco(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void ConsultarTarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaTArjetas = ObjectFactory.GetInstance<_00130_Tarjeta>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaTArjetas.Name))
            {
                fConsultaTArjetas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaTarjetaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00131_Abm_Tarjeta(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            var fConfiguracionSistema = ObjectFactory.GetInstance<_90000_ConfiguracionSistema>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConfiguracionSistema.Name))
            {
                fConfiguracionSistema.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            var fCompra = ObjectFactory.GetInstance<_00053_Compra>();

            //if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fCompra.Name))
            //{
            fCompra.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var fCliente = ObjectFactory.GetInstance<_00110_Cliente>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fCliente.Name))
            {
                fCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            var fConsultaArticulo = ObjectFactory.GetInstance<_00100_Articulo>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaArticulo.Name))
            {
                fConsultaArticulo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void consultaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void consultaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
           var fConceptoGastos= ObjectFactory.GetInstance<_00150_ConceptoGastos>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConceptoGastos.Name))
            {
                fConceptoGastos.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoConceptoDeGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00151_Abm_ConceptoGastos(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void consultaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var fBancos = ObjectFactory.GetInstance<_00128_Banco>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fBancos.Name))
            {
                fBancos.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoBancoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var fNuevo = new _00129_Abm_Banco(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void consultaToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var fTarjetas = ObjectFactory.GetInstance<_00130_Tarjeta>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fTarjetas.Name))
            {
                fTarjetas.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevaTarjetaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var fNuevo = new _00131_Abm_Tarjeta(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void cONSULTAToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            var fGastos = ObjectFactory.GetInstance<_00148_Gastos>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fGastos.Name))
            {
                fGastos.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevo = new _00149_Abm_Gastos(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void nuevoChequeToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            new _00157_Abm_Cheque(TipoOperacion.Nuevo, null).ShowDialog();
        }

        private void nuevaCuentaBancariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new _00135_AbmCuentaBancarias(TipoOperacion.Nuevo, null).ShowDialog();
        }

        private void consultaToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            var fCuentasBancarias = ObjectFactory.GetInstance<_00134_CuentasBancarias>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fCuentasBancarias.Name))
            {
                fCuentasBancarias.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void consultaToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            var fCheques = ObjectFactory.GetInstance<_00133_Cheques>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fCheques.Name))
            {
                fCheques.ShowDialog(); ;
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
