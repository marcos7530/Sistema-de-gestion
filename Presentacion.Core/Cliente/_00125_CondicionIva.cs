namespace Presentacion.Core.Cliente
{
    using FormularioBase;
    using System.Windows.Forms;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.CondicionIva;

    public partial class _00125_CondicionIva : FormularioConsulta
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;
        public _00125_CondicionIva(ICondicionIvaServicio condicionIvaServicio)
        {
            InitializeComponent();

            _condicionIvaServicio = condicionIvaServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _condicionIvaServicio.Get(!string.IsNullOrEmpty(cadenaBuscar) ? cadenaBuscar : string.Empty);

            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "CondicionIvas";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dgv.Columns["TipoComprobanteStr"].Visible = true;
            dgv.Columns["TipoComprobanteStr"].HeaderText = "Factura";
            dgv.Columns["TipoComprobanteStr"].Width = 100;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }

        public override bool EjecutarComandoNuevo()
        {
            var fNuevo = new _00126_Abm_CondicionIva(TipoOperacion.Nuevo);
            fNuevo.ShowDialog();

            return fNuevo.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoModificar()
        {
            var fModificar = new _00126_Abm_CondicionIva(TipoOperacion.Modificar, _entidadId);
            fModificar.ShowDialog();

            return fModificar.RelizoAlgunaOperacion;
        }

        public override bool EjecutarComandoEliminar()
        {
            var fEliminar = new _00126_Abm_CondicionIva(TipoOperacion.Eliminar, _entidadId);
            fEliminar.ShowDialog();

            return fEliminar.RelizoAlgunaOperacion;
        }
    }
}
