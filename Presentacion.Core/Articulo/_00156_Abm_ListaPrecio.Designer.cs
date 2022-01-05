namespace Presentacion.Core.Articulo
{
    partial class _00156_Abm_ListaPrecio
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
            this.nudPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.chkNecesitaAutorizacion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPorcentaje
            // 
            this.nudPorcentaje.DecimalPlaces = 2;
            this.nudPorcentaje.Location = new System.Drawing.Point(143, 131);
            this.nudPorcentaje.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.nudPorcentaje.Name = "nudPorcentaje";
            this.nudPorcentaje.Size = new System.Drawing.Size(123, 20);
            this.nudPorcentaje.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Porcentaje  Ganancia";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(143, 96);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(241, 20);
            this.txtDescripcion.TabIndex = 99;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(77, 98);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 100;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // chkNecesitaAutorizacion
            // 
            this.chkNecesitaAutorizacion.AutoSize = true;
            this.chkNecesitaAutorizacion.Location = new System.Drawing.Point(143, 168);
            this.chkNecesitaAutorizacion.Name = "chkNecesitaAutorizacion";
            this.chkNecesitaAutorizacion.Size = new System.Drawing.Size(129, 17);
            this.chkNecesitaAutorizacion.TabIndex = 103;
            this.chkNecesitaAutorizacion.Text = "Necesita Autorización";
            this.chkNecesitaAutorizacion.UseVisualStyleBackColor = true;
            // 
            // _00156_Abm_ListaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 235);
            this.Controls.Add(this.chkNecesitaAutorizacion);
            this.Controls.Add(this.nudPorcentaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.MaximumSize = new System.Drawing.Size(442, 274);
            this.MinimumSize = new System.Drawing.Size(442, 274);
            this.Name = "_00156_Abm_ListaPrecio";
            this.Text = "Lista de Precio (Alta, Baja y Modificación)";
            this.Controls.SetChildIndex(this.lblDescripcion, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.nudPorcentaje, 0);
            this.Controls.SetChildIndex(this.chkNecesitaAutorizacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPorcentaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.CheckBox chkNecesitaAutorizacion;
    }
}