namespace Presentacion.Core.LookUp
{
    using FormularioBase;
    using Servicio.Interfaces.Articulo;
    using System.Linq;
    using System.Windows.Forms;

    public partial class LookUpArticulo : FormularioLookUp
    {
        private readonly IArticuloServicio _articuloServicio;
        public LookUpArticulo(IArticuloServicio articuloServicio)
        {
            InitializeComponent();
            _articuloServicio = articuloServicio;
        }

        private void LookUpArticulo_Load(object sender, System.EventArgs e)
        {

        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _articuloServicio.Get(cadenaBuscar)
                .Where(x => !x.EstaEliminado).ToList();
            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Marca"].Visible = true;
            dgv.Columns["Marca"].HeaderText = "Marca";
            dgv.Columns["Marca"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Rubro"].Visible = true;
            dgv.Columns["Rubro"].HeaderText = "Rubro";
            dgv.Columns["Rubro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Iva"].Visible = true;
            dgv.Columns["Iva"].HeaderText = "Iva";
            dgv.Columns["Iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].HeaderText = "Codigo";
            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Detalle"].Visible = true;
            dgv.Columns["Detalle"].HeaderText = "Detalle";
            dgv.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["PrecioPublico"].Visible = true;
            dgv.Columns["PrecioPublico"].HeaderText = "PrecioPublico";
            dgv.Columns["PrecioPublico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(dgv);
        }
    }
}
