namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.Iva.DTOs;
    using StructureMap;

    public partial class _00123_Abm_Iva : FormularioAbm
    {
        private readonly IIvaServicio _ivaServicio;
        public _00123_Abm_Iva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();
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
                var entidad = _ivaServicio.GetById(entidadId.Value);
                if (entidad == null)
                {
                    MessageBox.Show("NO SE PUDO OBTENERR LOS DATOS");
                }

                txtDescripcion.Text = entidad.Descripcion;
                nudAlicuota.Value = entidad.Porcentaje;
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
            _ivaServicio.Add(new IvaDto
            {
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudAlicuota.Value,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _ivaServicio.Update(new IvaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudAlicuota.Value,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _ivaServicio.Delete(entidadId.Value);
        }
        private void _00123_Abm_Iva_Load(object sender, System.EventArgs e)
        {

        }
    }
}
