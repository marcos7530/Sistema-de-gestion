namespace Presentacion.Seguridad
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Persona.DTOs;
    using Servicio.Interfaces.Provincia;
    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using FormularioBase.Helpers;
    using Servicio.Interfaces.Persona;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00002_Abm_Empleado : FormularioAbm
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly ILocalidadServicio _localidadServicio;

        public _00002_Abm_Empleado(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _empleadoServicio = ObjectFactory.GetInstance<IEmpleadoServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();

            AsignarEvento_EnterLeave(this);

            txtApellido.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoNumeros(sender, args);
                NoSimbolos(sender, args);
            };

            txtNombre.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoNumeros(sender, args);
                NoSimbolos(sender, args);
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
            AgregarControlesObligatorios(this.nudLegajo, "Legajo");
            AgregarControlesObligatorios(this.txtApellido, "Apellido");
            AgregarControlesObligatorios(this.txtNombre, "Nombre");
            AgregarControlesObligatorios(this.txtDni, "DNI");
            AgregarControlesObligatorios(this.txtDireccion, "Dirección");
            AgregarControlesObligatorios(this.cmbProvincia, "Provincia");
            AgregarControlesObligatorios(this.cmbLocalidad, "Localidad");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            imgFoto.Image = Imagen.Camara;

            var provincias = _provinciaServicio.Get(string.Empty);

            Poblar_ComboBox(this.cmbProvincia, provincias, "Descripcion", "Id");

            if (entidadId.HasValue && entidadId.Value != 0)
            {
                var entidad = (EmpleadoDto) _empleadoServicio.GetById(typeof(EmpleadoDto), entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocurrio un error al Obtener los Datos");
                }

                nudLegajo.Value = entidad.Legajo;
                txtApellido.Text = entidad.Apellido;
                txtCUIL.Text = entidad.Cuil;
                txtCelular.Text = entidad.Celular;
                txtDireccion.Text = entidad.Direccion;
                txtDni.Text = entidad.Dni;
                txtEmail.Text = entidad.Email;
                txtNombre.Text = entidad.Nombre;
                txtTelefono.Text = entidad.Telefono;
                dtpFechaIngreso.Value = entidad.FechaIngreso;
                dtpFechaNacimiento.Value = entidad.FechaNacimiento;
                imgFoto.Image = Imagen.Convertir(entidad.Foto);
                cmbProvincia.SelectedValue = entidad.ProvinciaId;
               _rowVersion = entidad.RowVersion;

                Poblar_ComboBox(this.cmbLocalidad,
                    _localidadServicio.Get(entidad.ProvinciaId), "Descripcion", "Id");

                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }
            }
            else
            {
                LimpiarControles(this);

                if (provincias != null && provincias.Any())
                {
                    Poblar_ComboBox(this.cmbLocalidad,
                        _localidadServicio.Get(provincias.FirstOrDefault().Id), "Descripcion", "Id");
                }

                nudLegajo.Value = _empleadoServicio.ObtenerSiguienteNumeroLegajo();
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
                var _provinciaId = (long) cmbProvincia.SelectedValue;

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
                MessageBox.Show("Por favor cargue una provincia antes de dar de Alta una Localidad Nueva");
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _empleadoServicio.Add(AsignarDatosEmpleadoDto());
            imgFoto.Image = Imagen.Camara;
        }
        
        public override void EjecutarComandoPostLimpieza()
        {
            nudLegajo.Value = _empleadoServicio.ObtenerSiguienteNumeroLegajo();
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _empleadoServicio.Update(AsignarDatosEmpleadoDto(entidadId));
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _empleadoServicio.Delete(AsignarDatosEmpleadoDto(entidadId));
        }

        private EmpleadoDto AsignarDatosEmpleadoDto(long? entidadId = null)
        {
            return new EmpleadoDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                Apellido = txtApellido.Text,
                Celular = txtCelular.Text,
                Cuil = txtCUIL.Text,
                Dni = txtDni.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                EstaEliminado = false,
                FechaIngreso = dtpFechaIngreso.Value,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Foto = Imagen.Convertir(this.imgFoto.Image),
                Legajo = (int)nudLegajo.Value,
                LocalidadId = (long)cmbLocalidad.SelectedValue,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                RowVersion = _rowVersion
            };
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
