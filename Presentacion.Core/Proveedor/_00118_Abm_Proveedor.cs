namespace Presentacion.Core.Proveedor
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using FormularioBase.Helpers;
    using Seguridad;
    using Servicio.Interfaces.CondicionIva;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Provincia;
    using Cliente;
    using StructureMap;

    using FormularioBase;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
    
    public partial class _00118_Abm_Proveedor : FormularioAbm
    {
        private readonly IProveedorServicio _proveedorServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00118_Abm_Proveedor(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _proveedorServicio = ObjectFactory.GetInstance<IProveedorServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            AsignarEvento_EnterLeave(this);

            txtRazonSocial.KeyPress += NoInyeccion;

            txtCUIT.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoLetras(sender,args);
                NoSimbolos(sender, args);
                NoInyeccion(sender, args);
            };

            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoLetras(sender, args);
                NoSimbolos(sender, args);
                NoInyeccion(sender, args);
            };

            txtCelular.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoLetras(sender, args);
                NoSimbolos(sender, args);
                NoInyeccion(sender, args);
            };
            
            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(this.txtRazonSocial, "Apellido");
            AgregarControlesObligatorios(this.txtCUIT, "Nombre");
            AgregarControlesObligatorios(this.txtDireccion, "Dirección");
            AgregarControlesObligatorios(this.cmbProvincia, "Provincia");
            AgregarControlesObligatorios(this.cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(this.cmbCondicionIva, "Condición de Iva");
        }

        public override void CargarDatos(long? entidadId)
        {
            var provincias = _provinciaServicio.Get(string.Empty);
            var condicionesDeIvas = _condicionIvaServicio.Get(string.Empty);

            Poblar_ComboBox(this.cmbProvincia, provincias, "Descripcion", "Id");

            Poblar_ComboBox(this.cmbCondicionIva, condicionesDeIvas, "Descripcion", "Id");

            if (entidadId.HasValue && entidadId.Value != 0)
            {
                var entidad = (ProveedorDto)_proveedorServicio.GetById(typeof(ProveedorDto), entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("NO SE PUEDUDIERON OBTENER LOS DATOS");
                }

                txtRazonSocial.Text = entidad.RazonSocial;
                txtCUIT.Text = entidad.CUIT;
                txtCelular.Text = entidad.Celular;
                txtDireccion.Text = entidad.Direccion;
                txtEmail.Text = entidad.Email;
                txtTelefono.Text = entidad.Telefono;
                cmbProvincia.SelectedValue = entidad.ProvinciaId;
                cmbCondicionIva.SelectedValue = entidad.CondicionIvaId;
                _rowVersion = entidad.RowVersion;

                Poblar_ComboBox(this.cmbLocalidad,
                    _localidadServicio.Get(entidad.ProvinciaId), "Descripcion", "Id");

                if (_tipoOperacion != TipoOperacion.Eliminar) return;

                DesactivarControles(this);
                btnLimpiar.Visible = false;
            }
            else
            {
                LimpiarControles(this);

                if (provincias != null && provincias.Any())
                {
                    Poblar_ComboBox(this.cmbLocalidad,
                        _localidadServicio.Get(provincias.FirstOrDefault().Id), "Descripcion", "Id");
                }
            }
        }

        private async void BtnNuevaProvincia_Click(object sender, EventArgs e)
        {
            var fProvinciaNueva = new _00006_Abm_Provincia(TipoOperacion.Nuevo);
            fProvinciaNueva.ShowDialog();
            if (fProvinciaNueva.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbProvincia,
                    _provinciaServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private async void BtnNuevaLocalidad_Click(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                var _provinciaId = (long)cmbProvincia.SelectedValue;

                var fLocalidad = new _00004_Abm_Localidad(TipoOperacion.Nuevo, null, _provinciaId);
                fLocalidad.ShowDialog();
                if (fLocalidad.RelizoAlgunaOperacion)
                {
                    Poblar_ComboBox(this.cmbLocalidad,
                        _localidadServicio.Get(_provinciaId),
                        "Descripcion",
                        "Id");
                }
            }
            else
            {
                MessageBox.Show("CARGUE PRIMERO UNA PROVINCIA ANTES DE DAR EL ALTA DE UNA LOCALIDAD");
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _proveedorServicio.Add(AsignarDatosProveedorDto());
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _proveedorServicio.Update(AsignarDatosProveedorDto(entidadId));
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _proveedorServicio.Delete(AsignarDatosProveedorDto(entidadId));
        }

        private ProveedorDto AsignarDatosProveedorDto(long? entidadId = null)
        {
            return new ProveedorDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                RazonSocial = txtRazonSocial.Text,
                Celular = txtCelular.Text,
                CUIT = txtCUIT.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                EstaEliminado = false,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Telefono = txtTelefono.Text,
                CondicionIvaId = (long)cmbCondicionIva.SelectedValue,
                RowVersion = _rowVersion
            };
        }

        private void BtnNuevaCondicion_Click(object sender, EventArgs e)
        {
            var fCondicionIvaNueva = new _00126_Abm_CondicionIva(TipoOperacion.Nuevo);
            fCondicionIvaNueva.ShowDialog();
            if (fCondicionIvaNueva.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbCondicionIva,
                    _condicionIvaServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void CmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                Poblar_ComboBox(this.cmbLocalidad,
                    _localidadServicio.Get((long)cmbProvincia.SelectedValue),
                    "Descripcion",
                    "Id");
            }
        }
    }
}
