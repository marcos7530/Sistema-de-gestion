namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Marca.DTOs;
    using StructureMap;

    public partial class _00103_Abm_Marca : FormularioAbm
    {
        private readonly IMarcaServicio _marcaServicio;
        public _00103_Abm_Marca(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
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
                var entidad = _marcaServicio.GetById(entidadId.Value);
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
                this.txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _marcaServicio.Add(new MarcaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _marcaServicio.Update(new MarcaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _marcaServicio.Delete(entidadId.Value);
        }
    }
}
