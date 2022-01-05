using System.Windows.Forms;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.Localidad;

namespace Presentacion.Seguridad
{
    using FormularioBase;

    public partial class _00003_Localidad : FormularioConsulta
    {
        private readonly ILocalidadServicio _provinciaServicio;

        public _00003_Localidad(ILocalidadServicio provinciaServicio)
        {
            InitializeComponent();

            _provinciaServicio = provinciaServicio;

            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _provinciaServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Localidad";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Provincia"].Visible = true;
            dgv.Columns["Provincia"].HeaderText = "Provincia";
            dgv.Columns["Provincia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }

        public override bool EjecutarComandoNuevo()
        {
            var fNuevo = new _00004_Abm_Localidad(TipoOperacion.Nuevo, null);
            fNuevo.ShowDialog();

            return fNuevo.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var fModificar = new _00004_Abm_Localidad(TipoOperacion.Modificar, _entidadId);
            fModificar.ShowDialog();

            return fModificar.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var fEliminar = new _00004_Abm_Localidad(TipoOperacion.Eliminar, _entidadId);
            fEliminar.ShowDialog();

            return fEliminar.RelizoAlgunaOperacion;
        }
    }
}
