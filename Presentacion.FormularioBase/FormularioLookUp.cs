using System;
using Aplicacion.Constantes.Imagenes;

namespace Presentacion.FormularioBase
{
    public partial class FormularioLookUp : Formulario
    {
        private object _entidad;
        public object EntidadSeleccionada => _entidad;
        public FormularioLookUp()
        {
            InitializeComponent();
            _entidad = null;
        }

        private void FormularioLookUp_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        public virtual void ActualizarDatos(string cadenaBuscar)
        {
            FormatearGrilla(dgvGrilla);
        }

        private void dgvGrilla_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //propiedad Selection Mode = FullRowSelect
            _entidad = dgvGrilla.RowCount > 0
                ? _entidad = dgvGrilla.Rows[e.RowIndex].DataBoundItem
                : _entidad = null;            
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (_entidad != null)
                Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusqueda.Text))
                ActualizarDatos(txtBusqueda.Text);
        }
    }
}
