namespace Presentacion.Seguridad
{
    using System;
    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Clases;
    using Servicio.Interfaces.Usuario;
    using System.Collections.Generic;
    using System.Linq;
    using Servicio.Interfaces.Usuario.DTOs;

    public partial class _00007_Usuario : Formulario
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public _00007_Usuario(IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();
            ConfigurarMenu();

            _usuarioServicio = usuarioServicio;

            AsignarEvento_EnterLeave(this);
        }

        private void ConfigurarMenu()
        {
            // Imagenes de los Botones
            btnCrear.Image = Imagen.Usuarios;
            btnActualizar.Image = Imagen.Actualizar;
            btnBloquearDesbloquear.Image = Imagen.BloquearDesbloquear;
            btnResetPassword.Image = Imagen.Password;
            btnSalir.Image = Imagen.Salir;
            imgLupa.Image = Imagen.Buscar;

            // Color del Menu
            MenuConsulta.BackColor = Color.FondoMenu;

            btnCrear.ForeColor = Color.LetraMenu;
            btnActualizar.ForeColor = Color.LetraMenu;
            btnBloquearDesbloquear.ForeColor = Color.LetraMenu;
            btnActualizar.ForeColor = Color.LetraMenu;
            btnResetPassword.ForeColor = Color.LetraMenu;
            btnSalir.ForeColor = Color.LetraMenu;
        }

        private void _00007_Usuario_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            var usuarios = _usuarioServicio.Get(cadenaBuscar);

            dgvGrilla.DataSource = usuarios;

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].Frozen = true;
            dgv.Columns["Item"].Width = 40;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Nombre"].HeaderText = "Usuario";
            dgv.Columns["Nombre"].Width = 150;

            dgv.Columns["Bloqueado"].Visible = true;
            dgv.Columns["Bloqueado"].HeaderText = "Bloqueado";
            dgv.Columns["Bloqueado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Bloqueado"].Width = 70;

            dgv.Columns["Eliminado"].Visible = true;
            dgv.Columns["Eliminado"].HeaderText = "Eliminado";
            dgv.Columns["Eliminado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Eliminado"].Width = 70;

            CentrarCabecerasGrilla(dgv);
        }
        
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBusqueda.Text);
        }

        private void TxtBusqueda_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                ActualizarDatos(txtBusqueda.Text);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGrilla.DataSource != null)
                {
                    var usuarios = (List<UsuarioDto>)dgvGrilla.DataSource;

                    if (usuarios.Any(x => x.Item))
                    {
                        _usuarioServicio.Add(usuarios.Where(x => x.Item && x.Nombre == "NO REGISTRADO").ToList());

                        ActualizarDatos(string.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un Empleado");
                    }
                }
                else
                {
                    MessageBox.Show("No hay Empleados para crear Usuarios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK);
            }
        }

        private void DgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(((DataGridView)sender).RowCount <= 0) return;

            if (e.RowIndex >= 0)
            {
                ((DataGridView) sender).EndEdit();
            }
        }

        private void BtnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = true;
            }
        }

        private void BtnQuitarTodo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGrilla.RowCount; i++)
            {
                dgvGrilla["Item", i].Value = false;
            }
        }

        private void BtnBloquearDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGrilla.DataSource != null)
                {
                    var usuarios = (List<UsuarioDto>)dgvGrilla.DataSource;

                    if (usuarios.Any(x => x.Item))
                    {
                        _usuarioServicio.BloquearDesbloquear(usuarios.Where(x => x.Item && x.Nombre != "NO ASIGNADO").ToList());

                        ActualizarDatos(string.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un Usuario");
                    }
                }
                else
                {
                    MessageBox.Show("No hay Usuarios para Bloquear/Desbloquear");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK);
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGrilla.DataSource != null)
                {
                    var usuarios = (List<UsuarioDto>)dgvGrilla.DataSource;

                    if (usuarios.Any(x => x.Item))
                    {
                        _usuarioServicio.ResetearPassword(usuarios.Where(x => x.Item && x.Nombre != "NO ASIGNADO").ToList());

                        ActualizarDatos(string.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un Usuario");
                    }
                }
                else
                {
                    MessageBox.Show("No hay usuarios para Resetear Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK);
            }
        }
    }
}
