using Servicio.Interfaces.Precio;

namespace Presentacion.Core.Articulo
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using Dominio.Entidades;
    using FormularioBase;
    using Presentacion.Core.Proveedor;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.UnidadMedida;
    using StructureMap;

    public partial class _00101_Abm_Articulo : FormularioAbm
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IIvaServicio _ivaServicio;
        private readonly IUnidadMedidaServicio _unidadMedidaServicio;
        private readonly IProveedorServicio _proveedorServicio;
        /*=====================================================*/
        private readonly IPrecioServicio _precioServicio;

        public _00101_Abm_Articulo(TipoOperacion tipoOperacion, 
                                    long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();
            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();
            _unidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();
            _proveedorServicio = ObjectFactory.GetInstance<IProveedorServicio>();
            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            /*============================================================*/
            _precioServicio = ObjectFactory.GetInstance<IPrecioServicio>();
            
            AsignarEvento_EnterLeave(this);

            //validaciones

            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(this.txtCodigo, "Codigo");
            AgregarControlesObligatorios(this.txtcodigoBarra, "CodigoBarra");
            AgregarControlesObligatorios(this.Abreviatura, "Abreviatura");
            AgregarControlesObligatorios(this.cmbProveedor, "Proveedor");
            AgregarControlesObligatorios(this.txtUbicacion, "Ubicación");
            AgregarControlesObligatorios(this.cmbMarca, "Marca");
            AgregarControlesObligatorios(this.cmbRubro, "Rubro");
            AgregarControlesObligatorios(this.cmbTipoArticulo, "TipoArticulo");
            AgregarControlesObligatorios(this.cmbUnidad, "Unidad de Medida");
            AgregarControlesObligatorios(this.cmbIva, "IVA");

        }

        public override void CargarDatos(long? entidadId = null)
        {
            imgFoto.Image = Imagen.Camara;

            var marcas = _marcaServicio.Get(string.Empty);
            var rubros = _rubroServicio.Get(string.Empty);
            var unidadMedidas = _unidadMedidaServicio.Get(string.Empty);
            var ivas = _ivaServicio.Get(string.Empty);
            var proveedores = _proveedorServicio.Get(typeof(ProveedorDto), string.Empty);

            Poblar_ComboBox(cmbMarca, marcas!=null? marcas: null, "Descripcion", "Id");
            Poblar_ComboBox(cmbRubro, rubros, "Descripcion", "Id");
            Poblar_ComboBox(cmbUnidad, unidadMedidas, "Descripcion", "Id");
            Poblar_ComboBox(cmbIva, ivas, "Descripcion", "Id");
            Poblar_ComboBox(cmbProveedor, proveedores, "RazonSocial", "Id");
            Poblar_ComboBox(cmbTipoArticulo, Enum.GetValues(typeof(TipoArticulo)));

            if (entidadId.HasValue && entidadId.Value != 0)
            {
                var entidad = _articuloServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("No se pudo Obtener los datos");
                    return;
                }

                txtCodigo.Text = entidad.Codigo.ToString();
                txtcodigoBarra.Text = entidad.CodigoBarra;
                txtDescripcion.Text = entidad.Descripcion;
                txtAbreviatura.Text = entidad.Abreviatura;
                    
                txtDetalle.Text = entidad.Detalle;
                txtUbicacion.Text = entidad.Ubicacion;
                cmbMarca.SelectedValue = entidad.MarcaId;
                cmbRubro.SelectedValue = entidad.RubroId;
                cmbTipoArticulo.SelectedItem = entidad.TipoArticulo;
                cmbUnidad.SelectedValue = entidad.UnidadMedidaId;
                cmbIva.SelectedValue = entidad.IvaId;
                cmbProveedor.SelectedValue = entidad.ProveedorId;
                nudStock.Value = entidad.Stock;
                nudStockMin.Value = entidad.StockMinimo;
                chkDescontarStock.Checked = entidad.DescuentaStock;
                chkPermitirStockNeg.Checked = entidad.PermiteStockNegativo;
                chkActivarHoraVenta.Checked = entidad.ActivarHoraVenta;
                dtpHoraVentaInicio.Value = entidad.HoraLimiteVentaInicio;
                dtpHoraVentaFin.Value = entidad.HoraLimiteVentaFin;
                chkActivarLimite.Checked = entidad.ActivarLimiteVenta;
                nudLimiteVenta.Value = entidad.LimiteVenta;
                nudPrecioCosto.Value = entidad.PrecioCosto;
                imgFoto.Image = Imagen.Convertir(entidad.Foto);

                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }
            }
            else
            {
                LimpiarControles(this);
                txtCodigo.Focus();
            }
        }
        
        public override void EjecutarComandoNuevo()
        {
            long _codigo = -1;

            _articuloServicio.Add(new ArticuloDto
            {
                Codigo = long.TryParse(txtCodigo.Text, out _codigo)
                            ? _codigo 
                            : throw new Exception("Error de tipo de dato para codigo de articulo"),
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,                
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                TipoArticulo = (TipoArticulo)cmbTipoArticulo.SelectedItem,
                UnidadMedidaId = (long)cmbUnidad.SelectedValue,
                IvaId = (long)cmbIva.SelectedValue,
                ProveedorId = (long)cmbProveedor.SelectedValue,
                Stock = nudStock.Value,
                StockMinimo = nudStockMin.Value,
                DescuentaStock = chkDescontarStock.Checked,
                PermiteStockNegativo = chkPermitirStockNeg.Checked,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraLimiteVentaInicio = dtpHoraVentaInicio.Value,
                HoraLimiteVentaFin = dtpHoraVentaFin.Value,
                ActivarLimiteVenta = chkActivarLimite.Checked,
                LimiteVenta = nudLimiteVenta.Value,
                Foto = Imagen.Convertir(imgFoto.Image),
                PrecioCosto = nudPrecioCosto.Value,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            long _codigo = -1;
            _articuloServicio.Update(new ArticuloDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                Codigo = long.TryParse(txtCodigo.Text, out _codigo)
                            ? _codigo
                            : throw new Exception("Error de tipo de dato para codigo de articulo"),
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                ProveedorId = (long)cmbProveedor.SelectedValue,
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                TipoArticulo = (TipoArticulo)cmbTipoArticulo.SelectedItem,
                UnidadMedidaId = (long)cmbUnidad.SelectedValue,
                IvaId = (long)cmbIva.SelectedValue,
                Stock = nudStock.Value,
                StockMinimo = nudStockMin.Value,
                DescuentaStock = chkDescontarStock.Checked,
                PermiteStockNegativo = chkPermitirStockNeg.Checked,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraLimiteVentaInicio = dtpHoraVentaInicio.Value,
                HoraLimiteVentaFin = dtpHoraVentaFin.Value,
                ActivarLimiteVenta = chkActivarLimite.Checked,
                LimiteVenta = nudLimiteVenta.Value,
                Foto = Imagen.Convertir(imgFoto.Image),
                PrecioCosto = nudPrecioCosto.Value,
                RowVersion = _rowVersion
            });
            imgFoto.Image = Imagen.Camara;


            
        }        

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            if (entidadId.HasValue)
                _articuloServicio.Delete(entidadId.Value);
            else
            {
                MessageBox.Show("Pasó algo inesperado, lo siento");
            }
        }

        private void _00101_Abm_Articulo_Load(object sender, System.EventArgs e)
        {

        }

        private void BtnNuevaMarca_Click(object sender, EventArgs e)
        {
            var fNuevaMarca = new _00103_Abm_Marca(TipoOperacion.Nuevo);
            fNuevaMarca.ShowDialog();
            Poblar_ComboBox(this.cmbMarca, _marcaServicio.Get(string.Empty), "Descripcion", "Id");
        }

        private void BtnNuevoRubro_Click(object sender, EventArgs e)
        {
            var fNuevoRubro = new _00105_Abm_Rubro(TipoOperacion.Nuevo);
            fNuevoRubro.ShowDialog();
            Poblar_ComboBox(this.cmbRubro, _rubroServicio.Get(string.Empty), "Descripcion", "Id");
        }

        private void BtnNuevaUnidad_Click(object sender, EventArgs e)
        {
            var fNuevaUnidad = new _00159_Abm_UnidadMedida(TipoOperacion.Nuevo);
            fNuevaUnidad.ShowDialog();
            Poblar_ComboBox(this.cmbUnidad, _unidadMedidaServicio.Get(string.Empty), "Descripcion", "Id");
        }

        private void BtnNuevoIva_Click(object sender, EventArgs e)
        {
            var fNuevoIva = new _00123_Abm_Iva(TipoOperacion.Nuevo);
            fNuevoIva.ShowDialog();
            Poblar_ComboBox(this.cmbIva, _ivaServicio.Get(string.Empty), "Descripcion", "Id");
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            var fNuevoProveedor = new _00118_Abm_Proveedor(TipoOperacion.Nuevo);
            fNuevoProveedor.ShowDialog();
            Poblar_ComboBox(this.cmbProveedor, _proveedorServicio.Get(typeof(ProveedorDto), string.Empty), "RazonSocial", "Id");
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgFoto.Image = !string.IsNullOrEmpty(openFile.FileName)
                    ? Image.FromFile(openFile.FileName)
                    : Imagen.Camara;
            }
        }

        private void chkPermitirStockNeg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPermitirStockNeg.Checked)
            {
                nudStockMin.Minimum = -100;
            }
            else
            {
                nudStockMin.Minimum = 1;
            }
        }

        private void chkActivarHoraVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarHoraVenta.Checked)
            {
                dtpHoraVentaInicio.Enabled = true;
                dtpHoraVentaFin.Enabled = true;
            }
            else
            {
                dtpHoraVentaInicio.Enabled = false;
                dtpHoraVentaFin.Enabled = false;
            }
        }

        private void chkActivarLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarLimite.Checked)
            {
                nudLimiteVenta.Enabled = true;
            }
            else
            {
                nudLimiteVenta.Enabled = false;
            }
        }        
    }
}
