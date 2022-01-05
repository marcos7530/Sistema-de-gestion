namespace Presentacion.Core.LookUp
{
    partial class LookUpFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.chkActivarFecha = new System.Windows.Forms.CheckBox();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(429, 13);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.chkActivarFecha);
            this.pnlBusqueda.Controls.Add(this.dtpFechaBusqueda);
            this.pnlBusqueda.Controls.SetChildIndex(this.txtBusqueda, 0);
            this.pnlBusqueda.Controls.SetChildIndex(this.btnBuscar, 0);
            this.pnlBusqueda.Controls.SetChildIndex(this.dtpFechaBusqueda, 0);
            this.pnlBusqueda.Controls.SetChildIndex(this.chkActivarFecha, 0);
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Enabled = false;
            this.dtpFechaBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(73, 13);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(113, 20);
            this.dtpFechaBusqueda.TabIndex = 4;
            // 
            // chkActivarFecha
            // 
            this.chkActivarFecha.AutoSize = true;
            this.chkActivarFecha.Location = new System.Drawing.Point(11, 16);
            this.chkActivarFecha.Name = "chkActivarFecha";
            this.chkActivarFecha.Size = new System.Drawing.Size(56, 17);
            this.chkActivarFecha.TabIndex = 5;
            this.chkActivarFecha.Text = "Fecha";
            this.chkActivarFecha.UseVisualStyleBackColor = true;
            // 
            // LookUpFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "LookUpFacturas";
            this.Text = "Lista de Facturas";
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActivarFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaBusqueda;
    }
}