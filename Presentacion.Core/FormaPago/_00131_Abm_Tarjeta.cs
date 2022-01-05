namespace Presentacion.Core.FormaPago
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Tarjeta;
    using Servicio.Interfaces.Tarjeta.DTOs;
    using StructureMap;
    using System.Windows.Forms;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00131_Abm_Tarjeta : FormularioAbm
    {
        private readonly ITarjetaServicio _tarjetaServicio;
        public _00131_Abm_Tarjeta(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _tarjetaServicio = ObjectFactory.GetInstance<ITarjetaServicio>();

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };
            AsignarEvento_EnterLeave(this);
            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            base.CargarDatos(entidadId);
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var entidad = _tarjetaServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("No se pudieron obtener los datos.");
                }

                txtDescripcion.Text = entidad.Descripcion;
                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }
            }
            else
            {
                LimpiarControles(this);
                txtDescripcion.Focus();
            }
        }//fin CargarDatos

        public override void EjecutarComandoNuevo()
        {
            _tarjetaServicio.Add(new TarjetaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _tarjetaServicio.Update(new TarjetaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _tarjetaServicio.Delete(entidadId.Value);
        }
    }
}
