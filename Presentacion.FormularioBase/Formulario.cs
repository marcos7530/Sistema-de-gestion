namespace Presentacion.FormularioBase
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Aplicacion.Constantes.Clases;

    public partial class Formulario : Form
    {
        private readonly List<Helpers.Control> _listaDeControlesObligatorios;

        public string UsuarioLogin
        {
            set
            {
                lblUsuario.Text = !string.IsNullOrEmpty(value)
                    ? $"Usuario: {value}"
                    : string.Empty;
            }
        }

        public Formulario()
        {
            InitializeComponent();

            _listaDeControlesObligatorios = new List<Helpers.Control>();
        }
        
        protected void Control_Leave(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TextBox box:
                    box.BackColor = Color.ControlSinFoco;
                    break;
                case NumericUpDown down:
                    down.BackColor = Color.ControlSinFoco;
                    break;
            }
        }

        protected void Control_Enter(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TextBox box:
                    box.BackColor = Color.ControlConFoco;
                    break;
                case NumericUpDown down:
                    down.BackColor = Color.ControlConFoco;
                    break;
            }
        }

        protected void DesactivarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form) obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox) controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is ComboBox)
                    {
                        ((ComboBox) controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown) controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Button)
                    {
                        ((Button) controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker) controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is CheckBox)
                    {
                        ((CheckBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        DesactivarControles(controlForm);
                        continue;
                    }

                    if (controlForm is GroupBox)
                    {
                        DesactivarControles(controlForm);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var ControlPanel in ((Panel) obj).Controls)
                {
                    if (ControlPanel is TextBox)
                    {
                        ((TextBox) ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is ComboBox)
                    {
                        ((ComboBox) ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is NumericUpDown)
                    {
                        ((NumericUpDown) ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Button)
                    {
                        ((Button) ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is DateTimePicker)
                    {
                        ((DateTimePicker) ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is CheckBox)
                    {
                        ((CheckBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Panel)
                    {
                        DesactivarControles(ControlPanel);
                        continue;
                    }

                    if (ControlPanel is GroupBox)
                    {
                        DesactivarControles(ControlPanel);
                    }
                }
            }
            else if (obj is GroupBox)
            {
                foreach (var ControlGroupBox in ((GroupBox)obj).Controls)
                {
                    if (ControlGroupBox is TextBox)
                    {
                        ((TextBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is ComboBox)
                    {
                        ((ComboBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is NumericUpDown)
                    {
                        ((NumericUpDown)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Button)
                    {
                        ((Button)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is DateTimePicker)
                    {
                        ((DateTimePicker)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is CheckBox)
                    {
                        ((CheckBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Panel)
                    {
                        DesactivarControles(ControlGroupBox);
                        continue;
                    }

                    if (ControlGroupBox is GroupBox)
                    {
                        DesactivarControles(ControlGroupBox);
                    }
                }
            }
        }

        protected void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Clear();
                        continue;
                    }
                    
                    if (controlForm is ComboBox)
                    {
                        if (((ComboBox)controlForm).Items.Count > 0)
                        {
                            if (!tieneValorAsociado)
                            {
                                ((ComboBox) controlForm).SelectedIndex = 0;
                                continue;
                            }
                        }
                    }
                    
                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Value = DateTime.Now;
                        continue;
                    }
                    
                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Value = ((NumericUpDown)controlForm).Minimum;
                        continue;
                    }
                    
                    if (controlForm is RichTextBox)
                    {
                        ((RichTextBox)controlForm).Clear();
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        LimpiarControles(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Clear();
                            continue;
                        }

                        if (ControlPanel is ComboBox)
                        {
                            if (((ComboBox)ControlPanel).Items.Count > 0)
                            {
                                ((ComboBox)ControlPanel).SelectedIndex = 0; 
                                continue;
                            }

                        }

                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Value = ((NumericUpDown)ControlPanel).Minimum;
                            continue;
                        }

                        if (ControlPanel is DateTimePicker)
                        {
                            ((DateTimePicker)ControlPanel).Value = DateTime.Now;
                            continue;
                        }

                        if (ControlPanel is RichTextBox)
                        {
                            ((RichTextBox)ControlPanel).Clear();
                            continue;
                        }
                        
                        if (ControlPanel is Panel)
                        {
                            LimpiarControles(ControlPanel);
                        }
                    }
                }
            }
        }

        protected void AsignarEvento_EnterLeave(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enter += Control_Enter;
                        ((TextBox)controlForm).Leave += Control_Leave;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enter += Control_Enter;
                        ((NumericUpDown)controlForm).Leave += Control_Leave;
                        continue;
                    }
                    
                    if (controlForm is Panel)
                    {
                        AsignarEvento_EnterLeave(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Enter += Control_Enter;
                            ((TextBox)ControlPanel).Leave += Control_Leave;
                            continue;
                        }

                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Enter += Control_Enter;
                            ((NumericUpDown)ControlPanel).Leave += Control_Leave;
                            continue;
                        }
                        
                        if (ControlPanel is Panel)
                        {
                            AsignarEvento_EnterLeave(ControlPanel);
                        }
                    }
                }
            }
        }

        public virtual void Poblar_ComboBox(ComboBox cmb, 
            object datos, 
            string PropiedadMostrar,
            string propiedadDevolver)
        {
            cmb.DataSource = datos;
            cmb.DisplayMember = PropiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }
        public virtual void Poblar_ComboBox(ComboBox cmb, object datos)
        {
            cmb.DataSource = datos;
        }

        public virtual void AgregarControlesObligatorios(object control, string nombreControl)
        {
            _listaDeControlesObligatorios.Add(new Helpers.Control
            {
                Objeto = control,
                Nombre = nombreControl
            });

            AsignarErrorProvider(control);
        }

        public virtual void AsignarErrorProvider(object control)
        {
            if (control is TextBox)
            {
                ((TextBox)control).Validated += Control_Validated;
                return;
            }

            if (control is RichTextBox)
            {
                ((RichTextBox)control).Validated += Control_Validated;
                return;
            }

            if (control is ComboBox)
            {
                ((ComboBox)control).Validated += Control_Validated;
                return;
            }

            if (control is NumericUpDown)
            {
                ((NumericUpDown)control).Validated += Control_Validated;
                return;
            }

            if (control is DateTimePicker)
            {
                ((DateTimePicker)control).Validated += Control_Validated;
            }
        }

        public virtual void Control_Validated(object sender, System.EventArgs e)
        {
            if (sender is TextBox)
            {
                error.SetError(((TextBox)sender),
                    !string.IsNullOrEmpty(((TextBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");
                return;
            }

            if (sender is RichTextBox)
            {
                error.SetError(((RichTextBox)sender),
                    !string.IsNullOrEmpty(((RichTextBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");

                return;
            }

            if (sender is NumericUpDown)
            {
                error.SetError(((NumericUpDown)sender),
                    !string.IsNullOrEmpty(((NumericUpDown)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");

                return;
            }

            if (sender is ComboBox)
            {
                error.SetError(((ComboBox)sender),
                    !string.IsNullOrEmpty(((ComboBox)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");
                return;
            }

            if (sender is DateTimePicker)
            {
                error.SetError(((DateTimePicker)sender),
                    !string.IsNullOrEmpty(((DateTimePicker)sender).Text)
                        ? string.Empty
                        : $"El campo es Obligatorio.");
            }
        }

        public virtual bool VerificarDatosObligatorios()
        {
            foreach (var ctrol in _listaDeControlesObligatorios)
            {
                switch (ctrol.Objeto)
                {
                    case TextBox tbox:
                        if (string.IsNullOrEmpty(tbox.Text)) return false;
                        break;
                    case RichTextBox rbox:
                        if (string.IsNullOrEmpty(rbox.Text)) return false;
                        break;
                    case NumericUpDown down:
                        if (string.IsNullOrEmpty(down.Text)) return false;
                        break;
                    case ComboBox cbox:
                        if (cbox.Items.Count <= 0) return false;
                        break;
                    case DateTimePicker dPicker:
                        if (string.IsNullOrEmpty(dPicker.Text)) return false;
                        break;
                }
            }

            return true;
        }

        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            }
        }

        public virtual void CentrarCabecerasGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
