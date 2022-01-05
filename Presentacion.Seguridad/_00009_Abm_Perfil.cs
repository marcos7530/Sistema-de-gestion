namespace Presentacion.Seguridad
{
    using FormularioBase;
    using System.Windows.Forms;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.Perfil.DTOs;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00009_Abm_Perfil : FormularioAbm
    {
        private readonly IPerfilServicio _perfilServicio;

        public _00009_Abm_Perfil(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _perfilServicio = ObjectFactory.GetInstance<IPerfilServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
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
                var perfil = _perfilServicio.GetById(entidadId.Value);

                txtDescripcion.Text = perfil.Descripcion;

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
            _perfilServicio.Add(new PerfilDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _perfilServicio.Update(new PerfilDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _perfilServicio.Delete(entidadId.Value);
        }
    }
}
