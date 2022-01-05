using Servicio.Interfaces.Base;

namespace Presentacion.FormularioBase
{
    using System.Windows.Forms;
    using Aplicacion.Constantes.Imagenes;
    using Aplicacion.Constantes.Clases;
    using System;

    public partial class FormularioConsulta : Formulario
    {
        private bool _puedeEjecutarComando;
        private bool _registroEliminado;
        protected long? _entidadId;

        public FormularioConsulta()
        {
            InitializeComponent();
            ConfigurarMenu();
            AsignarEvento_EnterLeave(this);

            _puedeEjecutarComando = false;
            _registroEliminado = false;
            btnImprimir.Visible = false;
        }

        private void ConfigurarMenu()
        {
            // Imagenes de los Botones
            btnNuevo.Image = Imagen.Nuevo;
            btnModificar.Image = Imagen.Modificar;
            btnEliminar.Image = Imagen.Eliminar;
            btnActualizar.Image = Imagen.Actualizar;
            btnImprimir.Image = Imagen.Imprimir;
            btnSalir.Image = Imagen.Salir;
            imgLupa.Image = Imagen.Buscar;

            // Color del Menu
            MenuConsulta.BackColor = Color.FondoMenu;
            
            btnNuevo.ForeColor = Color.LetraMenu;
            btnModificar.ForeColor = Color.LetraMenu;
            btnEliminar.ForeColor = Color.LetraMenu;
            btnActualizar.ForeColor = Color.LetraMenu;
            btnImprimir.ForeColor = Color.LetraMenu;
            btnSalir.ForeColor = Color.LetraMenu;
        }

        public virtual void BtnNuevo_Click(object sender, System.EventArgs e)
        {
            if (EjecutarComandoNuevo())
            {
                ActualizarDatos(this.dgvGrilla, string.Empty);
            }
        }

        

        public virtual bool EjecutarComandoNuevo()
        {
            return false;
        }

        public virtual void BtnModificar_Click(object sender, System.EventArgs e)
        {
            if (_puedeEjecutarComando)
            {
                if (!_registroEliminado)
                {
                    if (EjecutarComandoModificar())
                    {
                        ActualizarDatos(this.dgvGrilla, string.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("El registro seleccionado se encuentra ELIMINADO.");
                }
            }
            else
            {
                MessageBox.Show("No hay Datos cargados");
            }
        }

        public virtual bool EjecutarComandoModificar()
        {
            return false;
        }

        public virtual void BtnEliminar_Click(object sender, System.EventArgs e)
        {
            if (_puedeEjecutarComando)
            {
                if (EjecutarComandoEliminar())
                {
                    ActualizarDatos(this.dgvGrilla, string.Empty);
                }
            }
            else
            {
                MessageBox.Show("No hay Datos cargados");
            }
        }

        public virtual bool EjecutarComandoEliminar()
        {
            return true;
        }

        public virtual void BtnActualizar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos( this.dgvGrilla, string.Empty);
        }

        public virtual void BtnImprimir_Click(object sender, System.EventArgs e)
        {
            if (_puedeEjecutarComando)
            {
                EjecutarComandoImprimir();
            }
            else
            {
                MessageBox.Show("No hay Datos cargados");
            }
        }

        public virtual void EjecutarComandoImprimir()
        {
            
        }

        public virtual void BtnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public virtual void BtnBuscar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(this.dgvGrilla, txtBusqueda.Text);// este era el original

            //if (string.IsNullOrEmpty(txtBusqueda.Text))
            //{
            //    ActualizarDatos(this.dgvGrilla, txtBusqueda.Text);
            //}
            //else
            //{
            //    ActualizarDatosPorFecha(this.dgvGrilla, thid);
            //}

        }

        public virtual void TxtBusqueda_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                this.btnBuscar.PerformClick();
        }

        public virtual void DgvGrilla_DataSourceChanged(object sender, System.EventArgs e)
        {
            this._puedeEjecutarComando = this.dgvGrilla.RowCount > 0;
        }

        public virtual void DgvGrilla_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            this._entidadId = dgvGrilla.RowCount > 0
                ? (long) dgvGrilla["Id", e.RowIndex].Value
                : (long?) null;

            this._registroEliminado = dgvGrilla.RowCount > 0
                ? (bool) dgvGrilla["EstaEliminado", e.RowIndex].Value
                : false;
        }

        public virtual void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
        }


        public virtual void FormularioConsulta_Load(object sender, EventArgs e)
        {
            ActualizarDatos(this.dgvGrilla, string.Empty);
        }
    }
}
