namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using StructureMap;

    public partial class _00100_Articulo : FormularioConsulta
    {
        private readonly IArticuloServicio _articuloServicio;
        public _00100_Articulo()
        {
            InitializeComponent();
            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _articuloServicio.Get( !string.IsNullOrEmpty(cadenaBuscar) 
                                                    ? cadenaBuscar 
                                                    : string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Marca"].Visible = true;
            dgv.Columns["Rubro"].Visible = true;
            dgv.Columns["Iva"].Visible = true;
            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Detalle"].Visible = true;
            dgv.Columns["PrecioPublico"].Visible = true;

            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CentrarCabecerasGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00101_Abm_Articulo(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Hubo un error {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00101_Abm_Articulo(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Hubo un error {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00101_Abm_Articulo(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Hubo un error {e.Message}");
                return false;
            }
        }
        private void _00100_Articulo_Load(object sender, System.EventArgs e)
        {

        }
    }
}
