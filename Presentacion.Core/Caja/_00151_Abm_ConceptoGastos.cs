using System.Windows.Forms;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.ConceptoGasto;
using Servicio.Interfaces.ConceptoGasto.DTOs;
using StructureMap;

namespace Presentacion.Core.Caja
{
    using FormularioBase;
    using System;

    public partial class _00151_Abm_ConceptoGastos : FormularioAbm
    {

        private readonly IConceptoGastoServicio _conceptoGasto;


        public _00151_Abm_ConceptoGastos(TipoOperacion tipoOperacion, long? entidadId = null)
        :base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _conceptoGasto = ObjectFactory.GetInstance<IConceptoGastoServicio>();
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
                var entidad = _conceptoGasto.GetById(entidadId.Value);
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

        }


        public override void EjecutarComandoNuevo()
        {
            _conceptoGasto.Add(new ConceptoGastoDto()
            {
                /*============================================*/
                Descripcion = txtDescripcion.Text,
                /*===========================================*/
                EstaEliminado = false
            });
        }


        public override void EjecutarComandoModificar(long? entidadId)
        {
            _conceptoGasto.Update(new ConceptoGastoDto()
            {
                Id = entidadId.Value,
                /*=================================*/
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _conceptoGasto.Delete(entidadId.Value);
        }

       
    }


}
