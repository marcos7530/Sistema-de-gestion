namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.ListaPrecio;
    using StructureMap;

    public partial class _00155_ListaPrecio : FormularioConsulta
    {
        private readonly IListaPrecioServicio _listaPrecioServicio;
        public _00155_ListaPrecio()
        {
            InitializeComponent();
            _listaPrecioServicio = ObjectFactory.GetInstance<IListaPrecioServicio>();
            AsignarEvento_EnterLeave(this);
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _listaPrecioServicio.Get(!string.IsNullOrEmpty(cadenaBuscar)
                                                    ? cadenaBuscar
                                                    : string.Empty);
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["PorcentajeGanancia"].Visible = true;
            dgv.Columns["NecesitaAutorizacionStr"].Visible = true;

            dgv.Columns["PorcentajeGanancia"].HeaderText = "Ganancia";
            dgv.Columns["NecesitaAutorizacionStr"].HeaderText = "Autorizar";

            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CentrarCabecerasGrilla(dgv);
        }

        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var fNuevo = new _00156_Abm_ListaPrecio(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();

                return fNuevo.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00156_Abm_ListaPrecio(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR. {e.Message}");
                return false;
            }
        }

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var fEliminar = new _00156_Abm_ListaPrecio(TipoOperacion.Eliminar, _entidadId);
                fEliminar.ShowDialog();

                return fEliminar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"HUBO UN ERROR. {e.Message}");
                return false;
            }
        }
    }
}
