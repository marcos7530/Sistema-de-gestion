namespace Presentacion.Core.Caja
{
    partial class _00149_Abm_Gastos
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
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevoConcepto = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMontoPagar = new System.Windows.Forms.NumericUpDown();
            this.lblDescuento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(80, 115);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(301, 21);
            this.cmbConcepto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Concepto";
            // 
            // btnNuevoConcepto
            // 
            this.btnNuevoConcepto.Location = new System.Drawing.Point(387, 114);
            this.btnNuevoConcepto.Name = "btnNuevoConcepto";
            this.btnNuevoConcepto.Size = new System.Drawing.Size(42, 23);
            this.btnNuevoConcepto.TabIndex = 7;
            this.btnNuevoConcepto.Text = "...";
            this.btnNuevoConcepto.UseVisualStyleBackColor = true;
            this.btnNuevoConcepto.Click += new System.EventHandler(this.btnNuevoConcepto_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(80, 89);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(122, 20);
            this.dtpFecha.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(80, 142);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(349, 20);
            this.txtDescripcion.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descripción";
            // 
            // nudMontoPagar
            // 
            this.nudMontoPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudMontoPagar.Location = new System.Drawing.Point(80, 168);
            this.nudMontoPagar.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMontoPagar.Name = "nudMontoPagar";
            this.nudMontoPagar.Size = new System.Drawing.Size(177, 26);
            this.nudMontoPagar.TabIndex = 13;
            this.nudMontoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoPagar.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDescuento.Location = new System.Drawing.Point(12, 170);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(64, 20);
            this.lblDescuento.TabIndex = 12;
            this.lblDescuento.Text = "Importe";
            // 
            // _00149_Abm_Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 256);
            this.Controls.Add(this.nudMontoPagar);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnNuevoConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbConcepto);
            this.MaximumSize = new System.Drawing.Size(481, 295);
            this.MinimumSize = new System.Drawing.Size(481, 295);
            this.Name = "_00149_Abm_Gastos";
            this.Text = "Gastos (Alta Baja y Modificación)";
            this.Controls.SetChildIndex(this.cmbConcepto, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnNuevoConcepto, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblDescuento, 0);
            this.Controls.SetChildIndex(this.nudMontoPagar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevoConcepto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMontoPagar;
        private System.Windows.Forms.Label lblDescuento;
    }
}