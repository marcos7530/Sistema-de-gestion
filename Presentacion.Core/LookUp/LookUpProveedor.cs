using System;
using System.Linq;
using System.Windows.Forms;
using Dominio.Entidades.MetaData;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Persona;
using Servicio.Interfaces.Persona.DTOs;
using StructureMap;

namespace Presentacion.Core.LookUp
{
    using FormularioBase;
    
    public partial class LookUpProveedor : FormularioLookUp
    {
        private readonly IProveedorServicio _proveedorServicio;

        public LookUpProveedor()
        {
            InitializeComponent();
          
            _proveedorServicio =ObjectFactory.GetInstance<IProveedorServicio>();
        }

        public override void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _proveedorServicio.Get(typeof(ProveedorDto), string.Empty)
                 .Where(x => !x.EstaEliminado).ToList();

           FormatearGrilla(dgvGrilla);
        }

        public void FormatearGrilla(DataGridView dgv)
        {
            //dgv.Columns["RazonSocial"].Visible = true;
            //dgv.Columns["RazonSocial"].HeaderText = "Razon Social";
            //dgv.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgv.Columns["CUIT"].Visible = true;
            //dgv.Columns["CUIT"].HeaderText = "CUIT";
            //dgv.Columns["CUIT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            //dgv.Columns["Telefono"].Visible = true;
            //dgv.Columns["Telefono"].HeaderText = "Telefono";
            //dgv.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgv.Columns["Direccion"].Visible = true;
            //dgv.Columns["Direccion"].HeaderText = "Direccion";
            //dgv.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["ProvinciaId"].Visible = false;
            dgv.Columns["LocalidadId"].Visible = false;
            dgv.Columns["RowVersion"].Visible = false;
            dgv.Columns["EstaEliminado"].Visible = false;

            dgv.Columns["EstaEliminadoStr"].Visible = true;
            dgv.Columns["EstaEliminadoStr"].Width = 60;
            dgv.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CentrarCabecerasGrilla(dgv);
        }

    }
}
