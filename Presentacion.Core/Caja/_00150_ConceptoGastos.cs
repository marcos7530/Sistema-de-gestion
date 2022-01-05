using System;
using System.ComponentModel;
using System.Windows.Forms;
using Dominio.Entidades.MetaData;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.ConceptoGasto;

namespace Presentacion.Core.Caja
{
    using FormularioBase;

    public partial class _00150_ConceptoGastos : FormularioConsulta
    {
        private readonly IConceptoGastoServicio _conceptoGastoServicio;

        public _00150_ConceptoGastos(IConceptoGastoServicio conceptoGastoServicio)
        {
            InitializeComponent();
            _conceptoGastoServicio = conceptoGastoServicio;
            AsignarEvento_EnterLeave(this);
        }


        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _conceptoGastoServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CentrarCabecerasGrilla(dgv);
        }


        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00151_Abm_ConceptoGastos(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00151_Abm_ConceptoGastos(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00151_Abm_ConceptoGastos(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ocurrió un Error. {e.Message}");
                return false;
            }
        }


    }
}
