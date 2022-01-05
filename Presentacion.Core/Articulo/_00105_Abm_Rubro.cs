namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.Rubro.DTOs;
    using StructureMap;

    public partial class _00105_Abm_Rubro : FormularioAbm
    {
        private readonly IRubroServicio _rubroServicio;
        public _00105_Abm_Rubro(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();
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
                var entidad = _rubroServicio.GetById(entidadId.Value);
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
        }//fim CargarDatos

        public override void EjecutarComandoNuevo()
        {
            _rubroServicio.Add(new RubroDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _rubroServicio.Update(new RubroDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _rubroServicio.Delete(entidadId.Value);
        }

    }
}
