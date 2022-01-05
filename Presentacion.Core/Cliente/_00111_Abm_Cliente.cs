namespace Presentacion.Core.Cliente
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.CondicionIva;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Provincia;
    using StructureMap;
    using System.Drawing;

    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using Presentacion.Seguridad;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00111_Abm_Cliente : FormularioAbm
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00111_Abm_Cliente(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            AsignarEvento_EnterLeave(this);

            txtApellido.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };

            txtNombre.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };

            txtDni.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtCUIL.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtCelular.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(this.txtApellido, "Apellido");
            AgregarControlesObligatorios(this.txtDireccion, "Dirección");
            AgregarControlesObligatorios(this.cmbProvincia, "Provincia");
            AgregarControlesObligatorios(this.cmbLocalidad, "Localidad");
            AgregarControlesObligatorios(this.cmbCondicionIva, "Condición de Iva");
        }

        public override void CargarDatos(long? entidadId)
        {
            imgFoto.Image = Imagen.Camara;

            var provincias = _provinciaServicio.Get(string.Empty);
            var condicionesDeIvas = _condicionIvaServicio.Get(string.Empty);

            Poblar_ComboBox(this.cmbProvincia, provincias, "Descripcion", "Id");

            Poblar_ComboBox(this.cmbCondicionIva, condicionesDeIvas, "Descripcion", "Id");

            if (entidadId.HasValue && entidadId.Value != 0)
            {
                var entidad = (ClienteDto)_clienteServicio.GetById(typeof(ClienteDto), entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocurrio un error al Obtener los Datos");
                }

                txtApellido.Text = entidad.Apellido;
                txtCUIL.Text = entidad.Cuil;
                txtCelular.Text = entidad.Celular;
                txtDireccion.Text = entidad.Direccion;
                txtDni.Text = entidad.Dni;
                txtEmail.Text = entidad.Email;
                txtNombre.Text = entidad.Nombre;
                txtTelefono.Text = entidad.Telefono;
                dtpFechaNacimiento.Value = entidad.FechaNacimiento;
                imgFoto.Image = Imagen.Convertir(entidad.Foto);
                cmbProvincia.SelectedValue = entidad.ProvinciaId;
                chkActivarCtaCte.Checked = entidad.ActivarCtaCte;
                chkLimiteCompra.Checked = entidad.TieneLimiteCompra;
                nudMontoMaximoCompra.Value = entidad.Monto;
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

        private void BtnNuevaProvincia_Click(object sender, EventArgs e)
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

        private void BtnNuevaLocalidad_Click(object sender, EventArgs e)
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
                MessageBox.Show("DEBE DAR DE ALTA UNA PROVINCIA ANTES DE AGREGAR UNA LOCALIDAD");
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _clienteServicio.Add(AsignarDatosClienteDto());
            imgFoto.Image = Imagen.Camara;
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _clienteServicio.Update(AsignarDatosClienteDto(entidadId));
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _clienteServicio.Delete(AsignarDatosClienteDto(entidadId));
        }

        private ClienteDto AsignarDatosClienteDto(long? entidadId = null)
        {
            return new ClienteDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                Apellido = txtApellido.Text,
                Celular = txtCelular.Text,
                Cuil = txtCUIL.Text,
                Dni = txtDni.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                EstaEliminado = false,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Foto = Imagen.Convertir(this.imgFoto.Image),
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                ActivarCtaCte = chkActivarCtaCte.Checked,
                TieneLimiteCompra = chkLimiteCompra.Checked,
                Monto = nudMontoMaximoCompra.Value,
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

        private void BtnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgFoto.Image = !string.IsNullOrEmpty(openFile.FileName)
                    ? Image.FromFile(openFile.FileName)
                    : Imagen.Camara;
            }
        }

        private void ChkLimiteCompra_CheckedChanged(object sender, EventArgs e)
        {
            nudMontoMaximoCompra.Enabled = chkLimiteCompra.Checked;
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
