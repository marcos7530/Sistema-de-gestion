namespace Presentacion.Core.Articulo
{
    using Presentacion.FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00156_Abm_ListaPrecio : FormularioAbm
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public _00156_Abm_ListaPrecio(TipoOperacion tipoOperacion,
                                    long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _listaPrecioServicio = ObjectFactory.GetInstance<IListaPrecioServicio>();
            AsignarEvento_EnterLeave(this);

            AgregarControlesObligatorios(this.txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(this.nudPorcentaje, "Porcentaje");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                var e = _listaPrecioServicio.GetById(entidadId.Value);
                if (e == null)
                {
                    MessageBox.Show("NO SE PUEDE OBTENER LOS DATOS");
                    return;
                }
                txtDescripcion.Text = e.Descripcion;
                nudPorcentaje.Value = e.PorcentajeGanancia;
                chkNecesitaAutorizacion.Checked = e.NecesitaAutorizacion;
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
            _listaPrecioServicio.Add(new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,
                NecesitaAutorizacion = chkNecesitaAutorizacion.Checked,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _listaPrecioServicio.Update(new ListaPrecioDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,
                NecesitaAutorizacion = chkNecesitaAutorizacion.Checked,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            if (entidadId.HasValue)
                _listaPrecioServicio.Delete(entidadId.Value);
        }
    }
}
