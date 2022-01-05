using System.Linq;
using System.Windows.Forms;
using Servicio.Interfaces.Banco;
using Servicio.Interfaces.CuentaBancaria;
using StructureMap;

namespace Presentacion.Core.LookUp
{
    using FormularioBase;

    public partial class LookUpCuentaBancaria : FormularioLookUp
    {
        private readonly ICuentaBancariaServicio _cuentaBancariaServicio;
        private readonly IBancoServicio _bancoServicio;


        public LookUpCuentaBancaria(ICuentaBancariaServicio cuentaBancariaServicio)
        {
            InitializeComponent();
            _cuentaBancariaServicio = cuentaBancariaServicio;
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _cuentaBancariaServicio.Get(cadenaBuscar)
                .Where(x => !x.EstaEliminado).ToList();

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["BancoId"].Visible = true;
            dgv.Columns["BancoId"].HeaderText = "BancoId";
            dgv.Columns["BancoId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Banco"].Visible = true;
            dgv.Columns["Banco"].HeaderText = "Banco";
            dgv.Columns["Banco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].HeaderText = "Numero";
            dgv.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Titular"].Visible = true;
            dgv.Columns["Titular"].HeaderText = "Titular";
            dgv.Columns["Titular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(dgv);
        }


    }
}
