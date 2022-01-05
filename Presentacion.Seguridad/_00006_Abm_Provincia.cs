namespace Presentacion.Seguridad
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Provincia;
    using Servicio.Interfaces.Provincia.DTOs;
    using System.Windows.Forms;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00006_Abm_Provincia : FormularioAbm
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public _00006_Abm_Provincia(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            AgregarControlesObligatorios(this.txtDescripcion, "Descripción");
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var provincia = _provinciaServicio.GetById(entidadId.Value);

                txtDescripcion.Text = provincia.Descripcion;

                if (_tipoOperacion != TipoOperacion.Eliminar) return;

                DesactivarControles(this);
                btnLimpiar.Visible = false;
            }
            else
            {
                LimpiarControles(this);
                this.txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _provinciaServicio.AddProvincia(new ProvinciaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _provinciaServicio.UpdateProvincia(new ProvinciaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            if (entidadId.HasValue && entidadId > 0)
            {
                _provinciaServicio.DeleteProvincia(entidadId.Value);
            }
        }
    }
}
