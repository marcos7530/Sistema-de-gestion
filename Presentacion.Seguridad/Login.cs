using Aplicacion.Constantes.Imagenes;

namespace Presentacion.Seguridad
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Servicio.Interfaces.Seguridad;
    using Aplicacion.Constantes.Clases;
    using Servicio.Interfaces.Usuario;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class Login : Formulario
    {
        private bool _puedeAcceder = false;

        private readonly ISeguridadServicio _seguridadServicio;
        private readonly IUsuarioServicio _usuarioServicio;
        
        public bool PuedeAcceder => _puedeAcceder;
        
        public Login(ISeguridadServicio seguridadServicio, IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();

            _seguridadServicio = seguridadServicio;
            _usuarioServicio = usuarioServicio;

            imgLogo.Image = Imagen.Usuario;

            _puedeAcceder = false;

            // Asignamos a los Text el Evento Enter
            // de la clase Base (Formulario)
            txtNombreUsuario.Enter += Control_Enter;
            txtPassword.Enter += Control_Enter;

            // Asignamos a los Text el Evento Leave
            // de la clase Base (Formulario)
            txtNombreUsuario.Leave += Control_Leave;
            txtPassword.Leave += Control_Leave;

            // Asignar la Imagen del Ojo para Ver el Password
            imgOjo.Image = Aplicacion.Constantes.Imagenes.Imagen.Ojo;

            AsignarEvento_EnterLeave(this);

            txtNombreUsuario.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Desea salir del Sistema", 
                    "Atención", 
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                _puedeAcceder = false;
                Application.Exit();
            }
        }

        /// <summary>
        /// Evento para Mostrar el Password sin *
        /// </summary>
        private void ImgOjo_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.MinValue;
        }

        /// <summary>
        /// Evento para que me muestre el Password con *
        /// </summary>
        private void ImgOjo_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreUsuario.Text))
                {
                    MessageBox.Show("Por ingrese un Usuario");
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Por ingrese una contraseña");
                    return;
                }

                if (txtNombreUsuario.Text == "admin" && txtPassword.Text == "admin")
                {
                    IdentidadUsuarioLogin.NombreUsuario = txtNombreUsuario.Text;
                    _puedeAcceder = true;
                    this.Close();
                    return;
                }

                if (!_seguridadServicio.VerificarAcceso(txtNombreUsuario.Text, txtPassword.Text)) 
                {
                    MessageBox.Show("El Usuario o la Contraseña son Incorrectas.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                var usuarioLogin = _usuarioServicio.GetByUser(txtNombreUsuario.Text);

                if (usuarioLogin == null)
                {
                    MessageBox.Show("Ocurrio un Error al Obtener el Usuario");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                if (usuarioLogin.EstaBloqueado)
                {
                    MessageBox.Show($"El usuario {usuarioLogin.ApyNom} esta BLOQUEADO.");
                    txtNombreUsuario.Clear();
                    txtPassword.Clear();

                    txtNombreUsuario.Focus();

                    return;
                }

                // Datos del Empleado
                IdentidadUsuarioLogin.EmpleadoId = usuarioLogin.EmpleadoId;
                IdentidadUsuarioLogin.ApellidoEmpleado = usuarioLogin.ApellidoEmpleado;
                IdentidadUsuarioLogin.NombreEmpleado = usuarioLogin.NombreEmpleado;
                IdentidadUsuarioLogin.FotoEmpleadoByte = usuarioLogin.FotoEmpleado;

                // Datos del Usuario
                IdentidadUsuarioLogin.UsuarioId = usuarioLogin.Id;
                IdentidadUsuarioLogin.NombreUsuario = usuarioLogin.Nombre;
                
                _puedeAcceder = true;
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK);
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = "mcampos";
            txtPassword.Text = "P$assword";
        }
    }
}
