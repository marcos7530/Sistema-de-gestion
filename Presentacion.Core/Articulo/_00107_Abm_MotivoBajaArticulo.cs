namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.MotivoBaja;
    using Servicio.Interfaces.MotivoBaja.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00107_Abm_MotivoBajaArticulo : FormularioAbm
    {
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        public _00107_Abm_MotivoBajaArticulo(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _motivoBajaServicio = ObjectFactory.GetInstance<IMotivoBajaServicio>();
            AsignarEvento_EnterLeave(this);
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var entidad = _motivoBajaServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("NO SE PUDIERON OBTENER LOS DATOS");
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
        }

        public override void EjecutarComandoNuevo()
        {
            _motivoBajaServicio.Add(new MotivoBajaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _motivoBajaServicio.Update(new MotivoBajaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _motivoBajaServicio.Delete(entidadId.Value);
        }
    }
}
