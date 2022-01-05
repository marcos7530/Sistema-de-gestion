namespace Presentacion.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.PerfilFormulario;
    using Servicio.Interfaces.PerfilFormulario;
    using Servicio.Interfaces.PerfilFormulario.DTOs;
    using Servicio.Interfaces.Seguridad;

    using FormularioBase;

    public partial class _00012_FormularioPerfil : Formulario
    {
        private readonly IPerfilFormularioServicio _perfilFormularioServicio;
        private readonly IPerfilServicio _perfilServicio;
        private readonly ISeguridadServicio _seguridadServicio;

        public _00012_FormularioPerfil(IPerfilFormularioServicio perfilFormularioServicio,
            IPerfilServicio perfilServicio,
            ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            AsignarEvento_EnterLeave(this);

            _perfilFormularioServicio = perfilFormularioServicio;
            _perfilServicio = perfilServicio;
            _seguridadServicio = seguridadServicio;

            imgBuscarAsignado.Image = Imagen.Buscar;
            imgBuscarNoAsignado.Image = Imagen.Buscar;
        }

        private void _00010_FormularioPerfil_Load(object sender, System.EventArgs e)
        {
            Poblar_ComboBox(cmbPerfil, _perfilServicio.Get(string.Empty), "Descripcion", "Id");
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            ActualizarDatosFormulariosAsignados(txtBuscarAsignado.Text);
            ActualizarDatosFormulariosNoAsignados(txtBuscarNoAsignado.Text);
        }

        private void ActualizarDatosFormulariosNoAsignados(string cadenaBuscar)
        {
            dgvGrillaNoAsignado.DataSource =
                _perfilFormularioServicio.ObtenerFormulariosNoAsignados((long)cmbPerfil.SelectedValue, cadenaBuscar);

            FormatearGrilla(dgvGrillaNoAsignado);
        }

        private void ActualizarDatosFormulariosAsignados(string cadenaBuscar)
        {
            dgvGrillaAsignado.DataSource =
                _perfilFormularioServicio.ObtenerFormulariosAsignados((long)cmbPerfil.SelectedValue, cadenaBuscar);

            FormatearGrilla(dgvGrillaAsignado);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].Width = 40;
            dgv.Columns["Item"].HeaderText = "Item";

            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Nombre"].HeaderText = "Apellido y Nombre";
        }


        private void BtnNuevoPerfil_Click(object sender, System.EventArgs e)
        {
            var fNuevoperfil = new _00009_Abm_Perfil(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoperfil.Name))
            {
                fNuevoperfil.ShowDialog();

                if (!fNuevoperfil.RelizoAlgunaOperacion) return;

                Poblar_ComboBox(cmbPerfil,
                    _perfilServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");

                ActualizarDatos();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnAgregar_Click(object sender, System.EventArgs e)
        {
            try
            {
                var formularios = (List<PerfilFormularioDto>)dgvGrillaNoAsignado.DataSource;

                if (formularios.Any(x => x.Item))
                {
                    _perfilFormularioServicio.AsignarFormulario((long)cmbPerfil.SelectedValue, formularios.Where(x => x.Item).ToList());

                    ActualizarDatos();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Formulario.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                var formularios = (List<PerfilFormularioDto>)dgvGrillaAsignado.DataSource;

                if (formularios.Any(x => x.Item))
                {
                    _perfilFormularioServicio.QuitarFormulario((long)cmbPerfil.SelectedValue, formularios.Where(x => x.Item).ToList());

                    ActualizarDatos();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Formulario.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnBuscarNoAsignado_Click(object sender, EventArgs e)
        {
            ActualizarDatosFormulariosNoAsignados(txtBuscarNoAsignado.Text);
        }

        private void BtnBuscarAsignado_Click(object sender, EventArgs e)
        {
            ActualizarDatosFormulariosAsignados(txtBuscarAsignado.Text);
        }

        private void TxtBuscarNoAsignado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatosFormulariosNoAsignados(txtBuscarNoAsignado.Text);
            }
        }

        private void TxtBuscarAsignado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatosFormulariosAsignados(txtBuscarAsignado.Text);
            }
        }

        private void DgvGrillaNoAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView) sender).RowCount > 0)
            {
                ((DataGridView) sender).EndEdit();
            }
        }

        private void DgvGrillaAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount > 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        private void CmbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPerfil.Items.Count > 0)
            {
                ActualizarDatos();
            }
        }

        private void BtnMarcarNoAsignado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrillaNoAsignado.RowCount; i++)
            {
                dgvGrillaNoAsignado["Item", i].Value = true;
            }
        }

        private void BtnDesmarcarNoAsignado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrillaNoAsignado.RowCount; i++)
            {
                dgvGrillaNoAsignado["Item", i].Value = false;
            }
        }

        private void BtnMarcarAsignado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrillaAsignado.RowCount; i++)
            {
                dgvGrillaAsignado["Item", i].Value = true;
            }
        }

        private void BtnDesmarcarAsignado_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrillaAsignado.RowCount; i++)
            {
                dgvGrillaAsignado["Item", i].Value = false;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
