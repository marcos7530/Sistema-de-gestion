namespace Presentacion.FormularioBase
{
    using System;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using Helpers;

    public partial class FormularioAbm : Formulario
    {
        protected readonly TipoOperacion _tipoOperacion;
        protected long? _entidadId;
        protected long? _entidadFiltroId;
        protected byte[] _rowVersion;

        private bool _realizoAlgunaOperacion;

        public bool RelizoAlgunaOperacion => _realizoAlgunaOperacion;

        public FormularioAbm()
        {
            InitializeComponent();
            ConfigurarMenu();

            _realizoAlgunaOperacion = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipoOperacion">Operacion que va a realizar (Nuevo, Modificar o Eliminar)</param>
        /// <param name="entidadId">Id de la Entidad a Modificar o Eliminar</param>
        public FormularioAbm(TipoOperacion tipoOperacion, long? entidadId = null)
            : this()
        {
            _tipoOperacion = tipoOperacion;
            _entidadId = entidadId;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tipoOperacion">Operacion que va a realizar (Nuevo, Modificar o Eliminar)</param>
        /// <param name="entidadId">Id de la Entidad a Modificar o Eliminar</param>
        /// <param name="entidadFiltroId">Id de la Entidad para filtro</param>
        public FormularioAbm(TipoOperacion tipoOperacion, long? entidadId = null, long? entidadFiltroId = null)
            : this()
        {
            _tipoOperacion = tipoOperacion;
            _entidadId = entidadId;
            _entidadFiltroId = entidadFiltroId;
        }

        public virtual void ConfigurarMenu()
        {
            // Imagenes de los Botones
            btnEjecutar.Image = Imagen.Guardar;
            btnLimpiar.Image = Imagen.Limpiar;
            btnSalir.Image = Imagen.Salir;

            // Color del Menu
            MenuConsulta.BackColor = Color.FondoMenu;

            btnEjecutar.ForeColor = Color.LetraMenu;
            btnLimpiar.ForeColor = Color.LetraMenu;
            btnSalir.ForeColor = Color.LetraMenu;
        }

        public virtual void CargarDatos(long? entidadId = null)
        {

        }

        public virtual void CargarDatos(long? entidadId = null, long? entidadFiltroId = null)
        {

        }

        public virtual void BtnLimpiar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de limpiar los Datos cargados.",
                    "Atención",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                LimpiarControles(this, _entidadFiltroId.HasValue);
            }
        }

        public virtual void BtnEjecutar_Click(object sender, System.EventArgs e)
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            try
            {
                switch (_tipoOperacion)
                {
                    case TipoOperacion.Nuevo:
                        if (!VerificarSiExiste())
                        {
                            try
                            {
                                EjecutarComandoNuevo();
                                MessageBox.Show("Los datos se grabaron Correctamente");
                                _realizoAlgunaOperacion = true;
                                LimpiarControles(this, _entidadFiltroId.HasValue);
                                EjecutarComandoPostLimpieza();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                          
                        }
                        break;
                    case TipoOperacion.Eliminar:
                        try
                        {
                            EjecutarComandoEliminar(_entidadId);
                            MessageBox.Show("Los datos se Eliminaron Correctamente");
                            _realizoAlgunaOperacion = true;
                            this.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                      
                        break;
                    case TipoOperacion.Modificar:
                        if (!VerificarSiExiste(_entidadId))
                        {
                            try
                            {
                                EjecutarComandoModificar(_entidadId);
                                MessageBox.Show("Los datos se Modificaron Correctamente");
                                _realizoAlgunaOperacion = true;
                                this.Close();
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                          
                        }
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public virtual void EjecutarComandoPostLimpieza()
        {
        }

        public virtual void EjecutarComandoNuevo()
        {
        }

        public virtual void EjecutarComandoModificar(long? entidadId)
        {
        }

        public virtual void EjecutarComandoEliminar(long? entidadId)
        {
        }

        public virtual bool VerificarSiExiste()
        {
            return false;
        }

        public virtual bool VerificarSiExiste(long? entidadId)
        {
            return false;
        }

        public virtual void FormularioAbm_Load(object sender, System.EventArgs e)
        {
            if (!_entidadFiltroId.HasValue)
            {
                CargarDatos(_entidadId);
            }
            else
            {
                CargarDatos(_entidadId,_entidadFiltroId);
            }
        }

        public virtual void BtnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
