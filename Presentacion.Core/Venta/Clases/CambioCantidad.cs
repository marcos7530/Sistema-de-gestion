using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Venta.Clases
{
    public partial class CambioCantidad : Form
    {
        private decimal _cantidad;
        public decimal NuevaCantidad { get; set; }
        public CambioCantidad(decimal cantidadCambiar)
        {
            InitializeComponent();
            _cantidad = cantidadCambiar;
        }

        private void CambioCantidad_Load(object sender, EventArgs e)
        {
            nudCantidad.Value = _cantidad;
        }

        private void CambioCantidad_Activated(object sender, EventArgs e)
        {
            nudCantidad.Focus();
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (nudCantidad.Value < 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0 (cero)");
                    nudCantidad.Focus();
                    return;
                }
                NuevaCantidad = nudCantidad.Value;
                Close();
            }
            
        }
    }
}
