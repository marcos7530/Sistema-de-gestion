using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aplicacion.Constantes.Clases;
using Presentacion.Core.Administracion;
using Presentacion.Core.Articulo;
using Presentacion.Core.LookUp;
using Presentacion.Core.Venta.Venta;
using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.Articulo;
using Servicio.Interfaces.Articulo.DTOs;
using Servicio.Interfaces.Caja;
using Servicio.Interfaces.Comprobante;
using Servicio.Interfaces.Comprobante.DTOs;
using Servicio.Interfaces.CondicionIva;
using Servicio.Interfaces.Configuracion;
using Servicio.Interfaces.Configuracion.DTOs;
using Servicio.Interfaces.Contador;
using Servicio.Interfaces.DetalleComprobante;
using Servicio.Interfaces.DetalleComprobante.DTOs;
using Servicio.Interfaces.Persona;
using Servicio.Interfaces.Persona.DTOs;
using Servicio.Interfaces.Precio;
using Servicio.Interfaces.Usuario;
using StructureMap;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00053_Compra : Formulario
    {
        private EmpleadoDto _empleado;
        private ProveedorDto _proveedor;
        private FacturaView _factura;
        private ItemsView _itemSeleccionado;
        private ArticuloDto _articulo;
        private ConfiguracionDto _configuracion;

        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IArticuloServicio _articuloServicio;
        //private readonly ICondicionIvaServicio _condicionIvaServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IFacturaServicio _facturaServicio;
        private readonly IDetalleComprobanteServicio _detalleComprobanteServicio;
        //private readonly IContadorServicio _contadorServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ICajaServicio _cajaServicio;

        /*========================================================*/

        private readonly IPrecioServicio _precioServicio;
        private readonly IComprobanteServicio _comprobanteServicio;
        private readonly ICompraServicio _compraServicio;

        public _00053_Compra(
            IEmpleadoServicio empleadoServicio,
            IArticuloServicio articuloServicio,
           // ICondicionIvaServicio condicionIvaServicio,
            IFacturaServicio facturaServicio,
            IDetalleComprobanteServicio detalleComprobanteServicio,
           // IContadorServicio contadorServicio,
            IUsuarioServicio usuarioServicio,
            ICajaServicio cajaServicio,
            /*================================================================*/
            IPrecioServicio precioServicio)
        {
            InitializeComponent();
            _empleadoServicio = empleadoServicio;
            _articuloServicio = articuloServicio;
           // _condicionIvaServicio = condicionIvaServicio;
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _comprobanteServicio = ObjectFactory.GetInstance<IComprobanteServicio>();
            _compraServicio = ObjectFactory.GetInstance<ICompraServicio>();
            
            _facturaServicio = facturaServicio;
            _detalleComprobanteServicio = detalleComprobanteServicio;
           // _contadorServicio = contadorServicio;
            _usuarioServicio = usuarioServicio;
            _cajaServicio = cajaServicio;
            /*============================================================*/
            _precioServicio = precioServicio;

            _configuracion = _configuracionServicio.Get();

            _itemSeleccionado = null;

            _factura = ObjectFactory.GetInstance<FacturaView>();

            _empleado = (EmpleadoDto)_empleadoServicio.GetById(typeof(EmpleadoDto), IdentidadUsuarioLogin.EmpleadoId);

            _factura.UsuarioId = IdentidadUsuarioLogin.UsuarioId;

            _proveedor = null;

            AsignarDatosEmpleado(_empleado);
        }

        private void AsignarDatosEmpleado(EmpleadoDto empleado)
        {
            _factura.VendedorId = empleado.Id;
            _factura.ApyNomVendedor = empleado.ApyNom;
        }

        private void btnLookUpArticulo_Click(object sender, System.EventArgs e)
        {
            var fLookUpArticulo = ObjectFactory.GetInstance<LookUpArticulo>();
            fLookUpArticulo.ShowDialog();
            if (fLookUpArticulo.EntidadSeleccionada != null)
            {
                var articuloSeleccionado = (ArticuloDto)fLookUpArticulo.EntidadSeleccionada;
               
                if (articuloSeleccionado != null)
                {
                    _articulo = articuloSeleccionado;

                    var objetoPrecioCosto = _precioServicio.Get(_articulo.Id)
                        .OrderByDescending(x => x.FechaActualizacion).First();
                    _articulo.PrecioCosto= objetoPrecioCosto.PrecioCosto;

                    txtCodigo.Text = _articulo.CodigoBarra;
                    txtDescripcion.Text = _articulo.Descripcion;
                    nudPrecioUnitario.Value = _articulo.PrecioCosto;
                    nudCantidad.Value = 1m;//_articulo.Stock;
                    txtSubTotalLinea.Text = (nudPrecioUnitario.Value * nudCantidad.Value).ToString();
                }
            }
        }

        private void btnNuevoArticulo_Click(object sender, System.EventArgs e)
        {
            var fNuevo = new _00101_Abm_Articulo(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();
        }

        private void btnBuscarProveedor_Click(object sender, System.EventArgs e)
        {
            var fLookUpProveedor = ObjectFactory.GetInstance<LookUpProveedor>();
            fLookUpProveedor.ShowDialog();
            if (fLookUpProveedor.EntidadSeleccionada != null)
            {
                var proveedorSeleccionado = (ProveedorDto)fLookUpProveedor.EntidadSeleccionada;
                if (proveedorSeleccionado != null)
                {
                    _proveedor = proveedorSeleccionado;
                    txtDni.Text = _proveedor.CUIT;
                    txtNombre.Text = _proveedor.RazonSocial;
                    txtDomicilio.Text = _proveedor.Direccion;
                    txtTelefono.Text = _proveedor.Telefono;
                    txtCondicionIva.Text = _proveedor.CondicionIva;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarItem( _articulo  , nudCantidad.Value);
            ActualizarItems();
            ActualizarTotalizadores();
        }

        private void ActualizarTotalizadores()
        {
            if (chk27.Checked) { nud27.Value = _factura.Total * 0.27m; }else { nud27.Value = 0m; }
            if (chk21.Checked) { nud21.Value = _factura.Total * 0.21m; } else { nud21.Value = 0m; }
            if (chk105.Checked) { nud105.Value = _factura.Total * 0.105m; } else { nud105.Value = 0m; }
            if (chkImpuestoInterno.Checked) 
            { nudImpuestoInterno.Value = _factura.Total * 0.05m; } 
            else { nudImpuestoInterno.Value = 0m; }
            if (chkPercepcionTemp.Checked) 
            { nudPercepcionTemp.Value = _factura.Total * 0.02m; } 
            else { nudPercepcionTemp.Value = 0m; }
            if (chkPercepcionPyP.Checked)
            { nudPercepcionPyP.Value = _factura.Total * 0.04m; } 
            else { nudPercepcionPyP.Value = 0m; }
            if (chkPercepcionIva.Checked)
            { nudPercepcionIva.Value = _factura.Total * 0.06m; }
            else { nudPercepcionIva.Value = 0m; }
            if (chkPercepcionIB.Checked) 
            { nudPercepcionIB.Value = _factura.Total * 0.025m; } 
            else { nudPercepcionIB.Value = 0m; }

            nudTotal.Value +=_factura.Total 
                             + nud27.Value 
                             + nud21.Value 
                             + nud105.Value 
                             + nudImpuestoInterno.Value 
                             + nudPercepcionTemp.Value 
                             + nudPercepcionPyP.Value 
                             + nudPercepcionIva.Value
                             +nudPercepcionIB.Value;
        }

        private void AgregarItem(ArticuloDto articulo, decimal cantidad)
        { 
            var _itemunificado = _factura.Items.FirstOrDefault(x => x.CodigoBarraArticulo == _articulo.CodigoBarra);

            articulo.PrecioCosto = nudPrecioUnitario.Value;

            _factura.Items.Add(new ItemsView()
            {
                Cantidad = cantidad,
                CodigoArticulo = articulo.Codigo,
                CodigoBarraArticulo = articulo.CodigoBarra,
                DescripcionArticulo = articulo.Descripcion,
                PrecioArticulo = articulo.PrecioCosto,
                ProductoId = articulo.Id,
            });
        }
        private void ActualizarItems()
        {
            this.dgvGrilla.DataSource = _factura.Items.ToList();
            FormatearGrilla(dgvGrilla);
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtSubTotalLinea.Clear();
            nudCantidad.Value = 1m;
            nudPrecioUnitario.Value = 0m;
            _articulo = null;
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["CodigoBarraArticulo"].Visible = true;
            dgv.Columns["CodigoBarraArticulo"].HeaderText = "Código Barra";
            dgv.Columns["CodigoBarraArticulo"].Width = 100;

            dgv.Columns["DescripcionArticulo"].Visible = true;
            dgv.Columns["DescripcionArticulo"].HeaderText = "Descripción";
            dgv.Columns["DescripcionArticulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["PrecioProductoStr"].Visible = true;
            dgv.Columns["PrecioProductoStr"].HeaderText = "Precio";

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 50;

            dgv.Columns["SubtotalStr"].Visible = true;
            dgv.Columns["SubtotalStr"].HeaderText = "Sub-Total";
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (_factura.Items.Count>0)
            {
                _factura.Fecha=DateTime.Now;
                _factura.Numerofactura = Convert.ToInt32(txtNroComprobante.Text); 
                _factura.TipoComprobante = TipoComprobante.Compra;
                var caja = _cajaServicio.GetCajas().Where(x=>x.FechaCierre==null).FirstOrDefault();

                _comprobanteServicio.Grabar(new ComprobanteDto()
                //_comprobanteServicio.Grabar(new CompraDto()
                {
                    CajaId = caja.Id,
                    EmpleadoId = _factura.VendedorId,
                    UsuarioId = _factura.UsuarioId,
                    ApellidoEmpleado = _empleado.Apellido,
                    NombreEmpleado = _empleado.Nombre,
                    NombreUsuario = _empleado.ApyNom,
                    Fecha = _factura.Fecha,
                    Numero =_factura.Numerofactura,
                    SubTotal = _factura.Total,
                    Descuento = 0m,
                    Total = nudTotal.Value,
                    Iva21 = _factura.Iva21,
                    Iva105 = _factura.Iva105,
                    TipoComprobante = TipoComprobante.Compra,
                    EstadoComprobante = EstadoComprobante.Pendiente,
                    EstaEliminado = false,
                    //ProveedorId = _proveedor.Id,
                    //FechaEntrega = DateTime.Now,
                    //Iva27 = nud27.Value,
                    //PrecepcionTemp = nudPercepcionTemp.Value,
                    //PrecepcionPyP = nudPercepcionPyP.Value,
                    //PrecepcionIva = nudPercepcionIB.Value,
                    Items = CargarItemsView()
                });

              
               

            }



            LimpiarControles(this);
        }

        private List<DetalleComprobanteDto> CargarItemsView()
        {
            var _items = new List<DetalleComprobanteDto>();
            foreach (var i in _factura.Items)
            {

                var articulo=_articuloServicio.GetById(i.ProductoId);
                //
                //articulo.PrecioCosto = i.PrecioArticulo;
                articulo.Stock += i.Cantidad;
                
                _articuloServicio.Update(articulo);

                _items.Add(new DetalleComprobanteDto
                {
                    ArticuloId = i.ProductoId,
                    Codigo = i.CodigoBarraArticulo,
                    Descripcion = i.DescripcionArticulo,
                    Cantidad = i.Cantidad,
                    Precio = i.PrecioArticulo,
                    Iva = i.Iva105 + i.Iva21,
                    SubTotal = i.Subtotal
                });
            }
            return _items;
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSubTotalLinea.Text = (nudPrecioUnitario.Value * nudCantidad.Value).ToString();
        }

        private void nudPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSubTotalLinea.Text = (nudPrecioUnitario.Value * nudCantidad.Value).ToString();
        }
    }
}
