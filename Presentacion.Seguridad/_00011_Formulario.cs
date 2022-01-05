using System.Linq;
using Servicio.Interfaces.Formulario.DTOs;

namespace Presentacion.Seguridad
{
    using System;
    using System.Windows.Forms;
    using StructureMap;
    using FormularioBase;
    using System.Collections.Generic;
    using System.Reflection;
    using Aplicacion.Constantes.Clases;
    using Aplicacion.Constantes.Imagenes;
    using Servicio.Interfaces.Formulario;

    public partial class _00011_Formulario : Formulario
    {
        private readonly IFormularioServicio _formularioServicio;

        public List<Type> TypesAssemblies { get; set; }

        public _00011_Formulario(IFormularioServicio formularioServicio)
        {
            InitializeComponent();

            _formularioServicio = formularioServicio;
            if (TypesAssemblies == null) 
                TypesAssemblies = new List<Type>();

            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            // Imagenes de los Botones
            btnCrear.Image = Imagen.Usuarios;
            btnActualizar.Image = Imagen.Actualizar;
            btnSalir.Image = Imagen.Salir;
            imgLupa.Image = Imagen.Buscar;

            // Color del Menu
            MenuConsulta.BackColor = Color.FondoMenu;

            btnCrear.ForeColor = Color.LetraMenu;
            btnActualizar.ForeColor = Color.LetraMenu;
            btnActualizar.ForeColor = Color.LetraMenu;
            btnSalir.ForeColor = Color.LetraMenu;
        }

        private void _00011_Formulario_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _formularioServicio.Get(cadenaBuscar, TypesAssemblies);

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].HeaderText = "Código";
            dgv.Columns["Codigo"].Width = 50;

            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Nombre"].HeaderText = "Nombre";
            dgv.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["NombreCompleto"].Visible = true;
            dgv.Columns["NombreCompleto"].HeaderText = "Nombre";
            dgv.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["ExisteBaseDatos"].Visible = true;
            dgv.Columns["ExisteBaseDatos"].HeaderText = "DB";
            dgv.Columns["ExisteBaseDatos"].Width = 50;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                _formularioServicio.Add(((List<FormularioDto>)dgvGrilla.DataSource).Where(x => !x.ExisteBaseDatos)
                    .ToList());

                ActualizarDatos(string.Empty);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}");
            }
        }
    }
}
