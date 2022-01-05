namespace Presentacion.Core.Venta
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using Presentacion.Core.LookUp;
    using Presentacion.Core.Venta.Clases;
    using Presentacion.Core.Venta.Venta;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Comprobante;
    using Servicio.Interfaces.Comprobante.DTOs;
    using Servicio.Interfaces.CondicionIva;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Interfaces.Contador;
    using Servicio.Interfaces.DetalleComprobante;
    using Servicio.Interfaces.DetalleComprobante.DTOs;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Usuario;
    using StructureMap;

    public partial class _00121_Ventas : Formulario
    {
        private EmpleadoDto _vendedor;
        private ClienteDto _cliente;
        private FacturaView _factura;
        private ItemsView _itemSeleccionado;

        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IFacturaServicio _facturaServicio;
        private readonly IDetalleComprobanteServicio _detalleComprobanteServicio;
        private readonly IContadorServicio _contadorServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ICajaServicio _cajaServicio;

        public _00121_Ventas(IClienteServicio clienteServicio,
                              IEmpleadoServicio empleadoServicio,
                              IListaPrecioServicio listaPrecioServicio,
                              IArticuloServicio articuloServicio,
                              ICondicionIvaServicio condicionIvaServicio,
                              IFacturaServicio facturaServicio,
                              IDetalleComprobanteServicio detalleComprobanteServicio,
                              IContadorServicio contadorServicio,
                              IUsuarioServicio usuarioServicio,
                              ICajaServicio cajaServicio)
        {
            InitializeComponent();

            _clienteServicio = clienteServicio;
            _empleadoServicio = empleadoServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _articuloServicio = articuloServicio;
            _condicionIvaServicio = condicionIvaServicio;
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _facturaServicio = facturaServicio;
            _detalleComprobanteServicio = detalleComprobanteServicio;
            _contadorServicio = contadorServicio;
            _usuarioServicio = usuarioServicio;
            _cajaServicio = cajaServicio;

            _itemSeleccionado = null;

            _factura = ObjectFactory.GetInstance<FacturaView>();

            _vendedor = null;
            _cliente = null;

            AsignarEvento_EnterLeave(this.txtCodigoArticulo);
        }

        private void _00121_Ventas_Load(object sender, System.EventArgs e)
        {
            InicializarDatosCabecera();
            InicializarDatosPie();
        }

        private void InicializarDatosPie()
        {
            nudPorcentajeDescuento.Value = 0;
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

            dgv.Columns["IvaStr"].Visible = true;
            dgv.Columns["IvaStr"].HeaderText = "IVA";
            dgv.Columns["IvaStr"].Width = 70;

            dgv.Columns["PrecioProductoStr"].Visible = true;
            dgv.Columns["PrecioProductoStr"].HeaderText = "Precio";

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 50;

            dgv.Columns["TotalIvaStr"].Visible = true;
            dgv.Columns["TotalIvaStr"].HeaderText = "Total IVA";

            dgv.Columns["SubtotalStr"].Visible = true;
            dgv.Columns["SubtotalStr"].HeaderText = "Sub-Total";

            CentrarCabecerasGrilla(dgv);

        }

        private void InicializarDatosCabecera()
        {
            try
            {
                //3 ontener vendedor que esta logueado
                _vendedor = (EmpleadoDto)_empleadoServicio.GetById(typeof(EmpleadoDto), IdentidadUsuarioLogin.EmpleadoId);
                if (_vendedor == null) throw new Exception("NO SE PUDO OBTENER EL VENDEDOR POR DEFECTO.");
                
                _factura.UsuarioId = IdentidadUsuarioLogin.UsuarioId;
                //_factura.UsuarioId = _usuarioServicio.Get(_vendedor.Nombre).FirstOrDefault().Id;

                AsignarDatosVendedor(_vendedor);

                //4 fecha y hora del dia en curso                
                _factura.Fecha = DateTime.Now;
                dtpFechaFactura.Value = _factura.Fecha;

                var condicionIvas = _condicionIvaServicio.Get(string.Empty);
                Poblar_ComboBox(cmbCondicionIva, condicionIvas, "Descripcion", "Id");
                //5 Obtener cliente por defecto
                _cliente = (ClienteDto)_clienteServicio.Get(typeof(ClienteDto), "99999999").FirstOrDefault();
                if (_cliente == null) throw new Exception("OCURRIO UN ERROR AL OBTENER EL CLIENTE POR DEFECTO.");

                AgregarDatosCliente(_cliente);

                //datos de la lista de precios
                var listaPrecios = _listaPrecioServicio.Get(string.Empty);
                Poblar_ComboBox(cmbListaPrecio, listaPrecios, "Descripcion", "Id");
                nudPorcentajeDescuento.Value = 0M;

                //1 Obtener los tipos de factura
                MostrarTipoFactura((long)cmbCondicionIva.SelectedValue);

                ActualizarItems();
                ActualizarTotalizadores();
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop)
                ;
                Close();
            }
        
        }

        private void ObtenerNumeroFactura(long value)
        {
            int i = _contadorServicio.ObtenerSiguienteNumeroComprobante(
                     _condicionIvaServicio.GetById(value).TipoComprobante);

            txtNumeroFactura.Text = i.ToString();
            _factura.Numerofactura = i;
        }

        private void AsignarDatosVendedor(EmpleadoDto vendedor)
        {
            txtVendedor.Text = vendedor.ApyNom;
            _factura.VendedorId = vendedor.Id;
            _factura.ApyNomVendedor = vendedor.ApyNom;
        }

        private void MostrarTipoFactura(long value)
        {
            var condicionIva = _condicionIvaServicio.GetById(value);
            lblTipoFactura.Text = condicionIva.TipoComprobanteStr;
            ObtenerNumeroFactura(value);
            _factura.TipoComprobante = condicionIva.TipoComprobante;

        }

        private void AgregarDatosCliente(ClienteDto cliente)
        {
            cmbCondicionIva.SelectedValue = cliente.CondicionIvaId;

            txtApyNomCliente.Text = cliente.ApyNom;
            txtDireccionCliente.Text = cliente.Direccion;
            txtDniCuitCuilCliente.Text = cliente.Dni;
            _factura.ApyNomCliente = cliente.ApyNom;
            _factura.ClienteId = cliente.Id;
            _factura.CuilCliente = cliente.Cuil;
            _factura.CondicionIvaClienteId = cliente.CondicionIvaId;
        }

        private void ActualizarTotalizadores()
        {
            _factura.PorcentajeDescuento = nudPorcentajeDescuento.Value;

            txtSubTotal.Text = _factura.Subtotal.ToString("C");
            txtMontoDescuento.Text = _factura.MontoDescuento.ToString("C");
            txtTotal.Text = _factura.Total.ToString("C");
            txtIva105.Text = _factura.Iva105.ToString("C");
            txtIva21.Text = _factura.Iva21.ToString("C");

            //txtIva105.Text = txtIva21.Text

        }

      
        private void ActualizarItems()
        {
            this.dgvGrilla.DataSource = _factura.Items.ToList();
            FormatearGrilla(dgvGrilla);
            txtCodigoArticulo.Clear();
            txtCodigoArticulo.Focus();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<LookUpCliente>();
            fLookUpCliente.ShowDialog();
            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                var clienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                AgregarDatosCliente(clienteSeleccionado);
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            var fBuscarEmpleado = ObjectFactory.GetInstance<LookUpEmpleado>();
            fBuscarEmpleado.ShowDialog();

            //MOSTRAR DATOS SI SELECCIONO EMPLEADO
            if (fBuscarEmpleado.EntidadSeleccionada != null)
            {
                var empleadoSeleccionado = (EmpleadoDto)fBuscarEmpleado.EntidadSeleccionada;
                AsignarDatosVendedor(empleadoSeleccionado);
            }
        }

        private void _00121_Ventas_Activated(object sender, EventArgs e)
        {
           
            txtCodigoArticulo.Clear();
            txtCodigoArticulo.Focus();
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCodigoArticulo.Text)) return;
                var listaPrecioSeleccionadaId = (long)cmbListaPrecio.SelectedValue;

                var articulo = _articuloServicio.GetByCode(txtCodigoArticulo.Text, listaPrecioSeleccionadaId);
                if (articulo != null)  //existe el articulo
                {
                    AgregarItem(articulo, 1, (long)cmbListaPrecio.SelectedValue);
                }
                else
                {
                    if (MostrarLookUpArticulo(listaPrecioSeleccionadaId)) return;
                }

                ActualizarItems();
                ActualizarTotalizadores();

            }
        }

        private bool MostrarLookUpArticulo(long listaPrecioSeleccionadaId)
        {
            var fLookUpArticulo = ObjectFactory.GetInstance<LookUpArticulo>();
            fLookUpArticulo.ShowDialog();
            if (fLookUpArticulo.EntidadSeleccionada != null)
            {
                var articuloSeleccionado = (ArticuloDto)fLookUpArticulo.EntidadSeleccionada;
                var articuloVenta = _articuloServicio
                    .GetByCode(articuloSeleccionado.CodigoBarra, listaPrecioSeleccionadaId);
                if (articuloVenta != null)
                {
                    AgregarItem(articuloVenta, 1, (long)cmbListaPrecio.SelectedValue);
                    return true;
                }
            }
            return false;
        }

        private bool HoraVenta(bool condicion, DateTime inicio, DateTime fin)
        {
            var horaCero = new TimeSpan(0, 0, 0);
            var horaInicioRestriccion = new TimeSpan(inicio.Hour, inicio.Minute, inicio.Second);
            var horaFinRestriccion = new TimeSpan(fin.Hour, fin.Minute, fin.Second);

            if (!condicion)
            {
                return true;
            }
            else
            {
                if ((horaInicioRestriccion < DateTime.Now.TimeOfDay && horaCero > DateTime.Now.TimeOfDay)
                 || (horaCero < DateTime.Now.TimeOfDay && horaFinRestriccion > DateTime.Now.TimeOfDay))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void AgregarItem(ArticuloVentaDto articulo, decimal cantidad, long listaPrecio)
        {
            var _unificarRenglones = _configuracionServicio.Get().UnificarRenglonesIngresarMismoProducto;

            if (!HoraVenta(articulo.ActivarHoraVenta, articulo.HoraLimiteVentaInicio, articulo.HoraLimiteVentaFin))
            {
                MessageBox.Show($"{articulo.DescripcionArticulo} NO SE PUEDE VENDER DESPUES DE LAS HORAS: {articulo.HoraLimiteVentaInicio.ToShortTimeString()}");
                return;
            }

            if (_unificarRenglones)
            {
                var _itemUnificado = _factura.Items.FirstOrDefault(x =>
                    x.CodigoBarraArticulo == articulo.CodigoBarraArticulo &&
                    x.ListaPrecioId == listaPrecio);

                if (_itemUnificado != null)
                {
                    if (!articulo.PermiteStockNegativo)
                    {
                        if (ValidarStock(articulo, _itemUnificado.Cantidad + cantidad) &&
                            ValidarRestriccionCantidad(articulo, _itemUnificado.Cantidad + cantidad))
                        {
                            _itemUnificado.Cantidad += cantidad;
                        }
                    }
                    else
                    {
                        if (ValidarRestriccionCantidad(articulo, cantidad))
                        {
                            _itemUnificado.Cantidad += cantidad;
                        }
                    }
                }
                else
                {
                    if (ValidarRestriccionCantidad(articulo, cantidad))
                    {
                        _factura.Items.Add(new ItemsView
                        {
                            Cantidad = cantidad,
                            CodigoArticulo = articulo.CodigoArticulo,
                            CodigoBarraArticulo = articulo.CodigoBarraArticulo,
                            DescripcionArticulo = articulo.DescripcionArticulo,
                            PrecioArticulo = articulo.PrecioArticulo,
                            ProductoId = articulo.Id,
                            ListaPrecioId = listaPrecio,                          
                            IvaStr = articulo.IvaStr,
                            Iva105 = articulo.MontoIva105,
                            Iva21 = articulo.MontoIva21,


                        });
                    }
                }
            }
            else// ESTO ES POR SI NO SE UNIFICAN LOS RENGLONES
            {
                decimal _cantidadEnGrilla = 0M;
                foreach (var i in _factura.Items)
                {
                    if (i.CodigoBarraArticulo == articulo.CodigoBarraArticulo &&
                        i.ListaPrecioId == listaPrecio)
                    {
                        _cantidadEnGrilla += 1;
                    }
                }
                if (!articulo.PermiteStockNegativo)
                {
                    if (ValidarStock(articulo, _cantidadEnGrilla + cantidad) &&
                        ValidarRestriccionCantidad(articulo, _cantidadEnGrilla + cantidad))
                    {
                        for (int i = 0; i < cantidad; i++)
                        {
                            _factura.Items.Add(new ItemsView
                            {
                                Cantidad = 1,
                                CodigoArticulo = articulo.CodigoArticulo,
                                CodigoBarraArticulo = articulo.CodigoBarraArticulo,
                                DescripcionArticulo = articulo.DescripcionArticulo,
                                PrecioArticulo = articulo.PrecioArticulo,
                                ProductoId = articulo.Id,
                                ListaPrecioId = listaPrecio,

                                IvaStr = articulo.IvaStr,
                                Iva105 = articulo.MontoIva105,
                                Iva21 = articulo.MontoIva21,
                            });
                        }
                    }
                }
                else
                {
                    if (ValidarRestriccionCantidad(articulo, _cantidadEnGrilla + cantidad))
                    {
                        for (int i = 0; i < cantidad; i++)
                        {
                            _factura.Items.Add(new ItemsView
                            {

                                Cantidad = 1,
                                CodigoArticulo = articulo.CodigoArticulo,
                                CodigoBarraArticulo = articulo.CodigoBarraArticulo,
                                DescripcionArticulo = articulo.DescripcionArticulo,
                                PrecioArticulo = articulo.PrecioArticulo,
                                ProductoId = articulo.Id,
                                ListaPrecioId = listaPrecio,

                                IvaStr = articulo.IvaStr,
                                Iva105 = articulo.MontoIva105,
                                Iva21 = articulo.MontoIva21,
                            });
                        }
                    }
                }
            }

            ActualizarItems();
            ActualizarTotalizadores();
            txtCodigoArticulo.Clear();
            txtCodigoArticulo.Focus();
        }

        private bool ValidarStock(ArticuloVentaDto articulo, decimal cantidad)
        {
            if (articulo.Stock >= cantidad) return true;
            MessageBox.Show("NO TIENE STOCK SUFICIENTE PARA VENDER");
            return false;
        }

        private bool ValidarRestriccionCantidad(ArticuloVentaDto articulo, decimal cantidad)
        {
            if (!articulo.ActivarLimiteVenta || articulo.LimiteVenta >= cantidad) return true;
            MessageBox.Show($"SOLO SE PERMITEN {articulo.LimiteVenta} DE {articulo.DescripcionArticulo} POR CADA COMPRA");
            return false;
        }

        private void nudPorcentajeDescuento_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotalizadores();
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) return;
            if (_itemSeleccionado == null) return;

            decimal cantidad = _itemSeleccionado.Cantidad;

            var fCantidadNueva = new CambioCantidad(cantidad);
            fCantidadNueva.ShowDialog();
            var articulo = _articuloServicio.GetByCode(_itemSeleccionado.CodigoBarraArticulo, _itemSeleccionado.ListaPrecioId);
            if (fCantidadNueva.NuevaCantidad == cantidad)
                cantidad = 0;
            else
                cantidad = fCantidadNueva.NuevaCantidad - cantidad ;
                                 
            AgregarItem(articulo, cantidad, _itemSeleccionado.ListaPrecioId);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _itemSeleccionado = (ItemsView)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _itemSeleccionado = null;
            }
        }

        private void btnCancelarLinea_Click(object sender, EventArgs e)
        {
            if (_itemSeleccionado != null)
            {
                if (MessageBox.Show("ESTÁ SEGURO DE ELIMINAR ESTE ITEM DE LA LISTA?",
                    "ADVERTENCIA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    _factura.Items.Remove(_itemSeleccionado);
                    _itemSeleccionado = null;
                    ActualizarItems();
                    ActualizarTotalizadores();

                }
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            if (MostrarLookUpArticulo((long)cmbListaPrecio.SelectedValue))
            {
                ActualizarItems();
                ActualizarTotalizadores();
            }
        }

        private void cmbListaPrecio_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbCondicionIva_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCondicionIva.Items.Count > 0)
            {
                MostrarTipoFactura((long)cmbCondicionIva.SelectedValue);
            }
        }

        private void dgvGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_factura.Items.Count > 0)
            {
                if (MessageBox.Show("SEGURO QUE DESEA CANCELAR LA COMPRA?",
                    "ADVERTENCIA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _factura.Items.RemoveAll(x => x.Cantidad != 0);
                    InicializarDatosCabecera();
                    ActualizarItems();
                    ActualizarTotalizadores();
                }
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (_factura.Items.Count > 0)
            {

                _facturaServicio.Grabar(new Servicio.Interfaces.Comprobante.DTOs.FacturaDto
                {
                    EmpleadoId = _factura.VendedorId,
                    UsuarioId = _factura.UsuarioId,
                    Fecha = _factura.Fecha,
                    Numero = _factura.Numerofactura,
                    SubTotal = _factura.Subtotal,
                    Descuento = _factura.MontoDescuento,
                    Total = _factura.Total,
                    TipoComprobante = _factura.TipoComprobante,
                    EstadoComprobante = EstadoComprobante.Pendiente,
                    
                    Iva105 = _factura.Iva105,
                    Iva21 = _factura.Iva21,

                    ClienteFacturaId = _factura.ClienteId,
                    Items = CargarItemsView()

                });
                _contadorServicio.Grabar(new Servicio.Interfaces.Contador.DTOs.ContadorDto
                {
                    TipoComprobante = _factura.TipoComprobante,
                    Valor = int.Parse(txtNumeroFactura.Text)
                });

                var _fPagar = (FacturaDto)_facturaServicio.Get(typeof(FacturaDto))
                    .FirstOrDefault(x => x.TipoComprobante == _factura.TipoComprobante && x.Numero == _factura.Numerofactura);

                if (!_configuracionServicio.Get().CajaSeparada)
                {
                    var fPago = new Presentacion.Core.FormaPago.FormaPago(_fPagar);
                    fPago.ShowDialog();
                }

                _factura.Items.RemoveAll(x => x.Cantidad != 0);
                InicializarDatosCabecera();
                ActualizarItems();
                ActualizarTotalizadores();

                MessageBox.Show("OPERACION COMPLETADA", "ADVERTENCIA");
            }
        }

        private List<DetalleComprobanteDto> CargarItemsView()
        {
            var _items = new List<DetalleComprobanteDto>();
            foreach (var i in _factura.Items)
            {
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

        private void _00121_Ventas_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.F5:
                    {
                        btnCantidad.PerformClick();
                        break;
                    }
                case (char)Keys.F6:
                    {
                        btnCancelarLinea.PerformClick();
                        break;
                    }
                case (char)Keys.F7:
                    {
                        btnCancelar.PerformClick();
                        break;
                    }
                case (char)Keys.F10:
                    {
                        btnFacturar.PerformClick();
                        break;
                    }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SEGURO QUE DESEA CANCELAR LA FACTURACIÓN?",
                "ADVERTENCIA",
                MessageBoxButtons.YesNo,                
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }
    }
}