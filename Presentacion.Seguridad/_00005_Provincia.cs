namespace Presentacion.Seguridad
{
    using FormularioBase;
    using System.Windows.Forms;
    using FormularioBase.Helpers;
    using Servicio.Interfaces.Provincia;

    public partial class _00005_Provincia : FormularioConsulta
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public _00005_Provincia(IProvinciaServicio provinciaServicio)
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
            dgv.Columns["Descripcion"].HeaderText = "Provincias";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }
        
        public override bool EjecutarComandoNuevo()
        {
            var fNuevo = new _00006_Abm_Provincia(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();

            return fNuevo.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var fModificar = new _00006_Abm_Provincia(TipoOperacion.Modificar, _entidadId);
            fModificar.ShowDialog();

            return fModificar.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var fEliminar = new _00006_Abm_Provincia(TipoOperacion.Eliminar, _entidadId);
            fEliminar.ShowDialog();

            return fEliminar.RelizoAlgunaOperacion;
        }
    }
}
