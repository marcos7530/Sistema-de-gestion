using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.CondicionIva;
using Servicio.Interfaces.CondicionIva.DTOs;
using StructureMap;

namespace Presentacion.Core.Cliente
{
    using Aplicacion.Constantes.Clases;
    using FormularioBase;
    using System;
    using System.Windows.Forms;

    public partial class _00126_Abm_CondicionIva : FormularioAbm
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00126_Abm_CondicionIva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            AgregarControlesObligatorios(this.txtDescripcion, "Descripción");
        }

        public override void CargarDatos(long? entidadId)
        {
            Poblar_ComboBox(cmbTipoComprobante, Enum.GetValues(typeof(TipoComprobante)));
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var condicionIva = _condicionIvaServicio.GetById(entidadId.Value);
                if (condicionIva == null)
                    MessageBox.Show("HUBO UN ERROR AL OBTENER LOS DATOS");

                txtDescripcion.Text = condicionIva.Descripcion;
                cmbTipoComprobante.SelectedItem = condicionIva.TipoComprobante;

                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Enabled = false;
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
            _condicionIvaServicio.Add(new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text,
                TipoComprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _condicionIvaServicio.Update(new CondicionIvaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                TipoComprobante = (TipoComprobante)cmbTipoComprobante.SelectedItem,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _condicionIvaServicio.Delete(entidadId.Value);
        }
    }
}
