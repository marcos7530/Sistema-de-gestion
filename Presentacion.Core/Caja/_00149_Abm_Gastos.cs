using System.Windows.Forms;
using Dominio.Entidades.MetaData;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.ConceptoGasto;
using Servicio.Interfaces.Gastos;
using Servicio.Interfaces.Gastos.DTOs;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Caja
{
    using FormularioBase;
    using System;

    public partial class _00149_Abm_Gastos : FormularioAbm
    {
        private readonly IGastoServicio _gastoServicio;
        private readonly IConceptoGastoServicio _conceptoGastoServicio;

        public _00149_Abm_Gastos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _gastoServicio = ObjectFactory.GetInstance<IGastoServicio>();
            _conceptoGastoServicio = ObjectFactory.GetInstance<IConceptoGastoServicio>();


            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            AsignarEvento_EnterLeave(this);

            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
        }


        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text)) return false;
            if (cmbConcepto.Items.Count <= 0) return false;
            if (nudMontoPagar.Value <= 0) return false;
            return true;
        }


        public override void CargarDatos(long? entidadId = null)
        {
            base.CargarDatos(entidadId);
            if (entidadId.HasValue&&entidadId>0)
            {
                var entidad = _gastoServicio.GetById(entidadId.Value);
                Poblar_ComboBox(cmbConcepto, _conceptoGastoServicio.Get(string.Empty), "Descripcion", "Id");
                cmbConcepto.SelectedValue = entidad.ConceptoGastoId;
                txtDescripcion.Text = entidad.Descripcion;
                nudMontoPagar.Value = entidad.Monto;
                dtpFecha.Value = entidad.Fecha;

                if (_tipoOperacion==TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }

            }
            else
            {
                Poblar_ComboBox(cmbConcepto, _conceptoGastoServicio.Get(string.Empty), "Descripcion", "Id");
                txtDescripcion.Clear();
                nudMontoPagar.Value = 0m;
                dtpFecha.Value = DateTime.Today;

            }

        }


        public override void EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            _gastoServicio.Add(new GastoDto()
            {
                ConceptoGastoId = (long)cmbConcepto.SelectedValue,
                Fecha = dtpFecha.Value,
                Descripcion = txtDescripcion.Text,
                Monto = nudMontoPagar.Value,
                /*============================================================*/
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            _gastoServicio.Update(new GastoDto
            {
                Id = entidadId.Value,
                /*===========================================================*/
                ConceptoGastoId = (long)cmbConcepto.SelectedValue,
                Fecha = dtpFecha.Value,
                Descripcion = txtDescripcion.Text,
                Monto = nudMontoPagar.Value,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _gastoServicio.Delete(entidadId.Value);
        }


        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            new _00151_Abm_ConceptoGastos(TipoOperacion.Nuevo).ShowDialog();
            Poblar_ComboBox(cmbConcepto, _conceptoGastoServicio.Get(string.Empty), "Descripcion", "Id");
        }
    }
}
