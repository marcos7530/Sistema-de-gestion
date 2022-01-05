namespace Presentacion.Core.FormaPago
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Banco;
    using Servicio.Interfaces.Banco.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00129_Abm_Banco : FormularioAbm
    {
        private readonly IBancoServicio _bancoServicio;
        public _00129_Abm_Banco(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _bancoServicio = ObjectFactory.GetInstance<IBancoServicio>();
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
                var entidad = _bancoServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("NO SE PUDO OBTENER LOS DATOS");
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
        }//fim CargarDatos

        public override void EjecutarComandoNuevo()
        {
            _bancoServicio.Add(new BancoDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _bancoServicio.Update(new BancoDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _bancoServicio.Delete(entidadId.Value);
        }
    }
}
