namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.UnidadMedida;
    using Servicio.Interfaces.UnidadMedida.DTOs;
    using StructureMap;

    public partial class _00159_Abm_UnidadMedida : FormularioAbm
    {
        private readonly IUnidadMedidaServicio _unidadMedidaServicio;
        public _00159_Abm_UnidadMedida(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _unidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();
            AsignarEvento_EnterLeave(this);

            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var entidad = _unidadMedidaServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("NO SE PUEDE OBTENER LOS DATOS");
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
            _unidadMedidaServicio.Add(new UnidadMedidaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _unidadMedidaServicio.Update(new UnidadMedidaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _unidadMedidaServicio.Delete(entidadId.Value);
        }
    }
}
