namespace Presentacion.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.PerfilUsuario.DTOs;
    using Servicio.Interfaces.Seguridad;
    using FormularioBase;
    using System.Windows.Forms;
    using Servicio.Interfaces.PerfilUsuario;

    public partial class _00010_UsuarioPerfil : Formulario
    {
        private readonly IPerfilUsuarioServicio _perfilUsuarioServicio;
        private readonly IPerfilServicio _perfilServicio;
        private readonly ISeguridadServicio _seguridadServicio;

        public _00010_UsuarioPerfil(IPerfilUsuarioServicio perfilUsuarioServicio, 
            IPerfilServicio perfilServicio,
            ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            AsignarEvento_EnterLeave(this);

            _perfilUsuarioServicio = perfilUsuarioServicio;
            _perfilServicio = perfilServicio;
            _seguridadServicio = seguridadServicio;

            imgBuscarAsignado.Image = Imagen.Buscar;
            imgBuscarNoAsignado.Image = Imagen.Buscar;
        }

        private void _00010_UsuarioPerfil_Load(object sender, System.EventArgs e)
        {
            Poblar_ComboBox(cmbPerfil, _perfilServicio.Get(string.Empty), "Descripcion", "Id");
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            ActualizarDatosUsuariosAsignados(txtBuscarAsignado.Text);
            ActualizarDatosUsuariosNoAsignados(txtBuscarNoAsignado.Text);
        }

        private void ActualizarDatosUsuariosNoAsignados(string cadenaBuscar)
        {
            dgvGrillaNoAsignado.DataSource =
                _perfilUsuarioServicio.ObtenerUsuariosNoAsignados((long) cmbPerfil.SelectedValue, cadenaBuscar);

            FormatearGrilla(dgvGrillaNoAsignado);
        }

        private void ActualizarDatosUsuariosAsignados(string cadenaBuscar)
        {
            dgvGrillaAsignado.DataSource =
                _perfilUsuarioServicio.ObtenerUsuariosAsignados((long)cmbPerfil.SelectedValue, cadenaBuscar);

            FormatearGrilla(dgvGrillaAsignado);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].Width = 40;
            dgv.Columns["Item"].HeaderText = "Item";

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
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
                var usuarios = (List<PerfilUsuarioDto>)dgvGrillaNoAsignado.DataSource;

                if (usuarios.Any(x => x.Item))
                {
                    _perfilUsuarioServicio.AsignarUsuario((long)cmbPerfil.SelectedValue, usuarios.Where(x => x.Item).ToList());

                    ActualizarDatos();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Usuario.");
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
                var usuarios = (List<PerfilUsuarioDto>)dgvGrillaAsignado.DataSource;

                if (usuarios.Any(x => x.Item))
                {
                    _perfilUsuarioServicio.QuitarUsuario((long)cmbPerfil.SelectedValue, usuarios.Where(x => x.Item).ToList());

                    ActualizarDatos();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Usuario.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnBuscarNoAsignado_Click(object sender, EventArgs e)
        {
            ActualizarDatosUsuariosNoAsignados(txtBuscarNoAsignado.Text);
        }

        private void BtnBuscarAsignado_Click(object sender, EventArgs e)
        {
            ActualizarDatosUsuariosAsignados(txtBuscarAsignado.Text);
        }

        private void TxtBuscarNoAsignado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                ActualizarDatosUsuariosNoAsignados(txtBuscarNoAsignado.Text);
            }
        }

        private void TxtBuscarAsignado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                ActualizarDatosUsuariosAsignados(txtBuscarAsignado.Text);
            }
        }

        private void DgvGrillaNoAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount > 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        private void DgvGrillaAsignado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView) sender).RowCount > 0)
            {
                ((DataGridView) sender).EndEdit();
            }
        }

        private void CmbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPerfil.Items.Count > 0)
            {
                ActualizarDatos();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BtnMarcarAsignados_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrillaAsignado.RowCount; i++)
            {
                dgvGrillaAsignado["Item", i].Value = true;
            }
        }

        private void BtnDesmarcarAsignados_Click(object sender, EventArgs e)
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
    }
}
