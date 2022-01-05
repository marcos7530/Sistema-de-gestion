namespace Presentacion.Core.Cheque
{
    partial class _00136_DepositarCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00136_DepositarCheque));
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.txtTitularDestino = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroCuentaDestino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoBanco = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBancoDestino = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaVencimiento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBancoOrigen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 52);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(467, 6);
            this.pnlLineaMenu.TabIndex = 6;
            // 
            // MenuConsulta
            // 
            this.MenuConsulta.BackColor = System.Drawing.Color.SteelBlue;
            this.MenuConsulta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuConsulta.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.MenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEjecutar,
            this.btnLimpiar,
            this.btnSalir});
            this.MenuConsulta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.MenuConsulta.Name = "MenuConsulta";
            this.MenuConsulta.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.MenuConsulta.Size = new System.Drawing.Size(467, 52);
            this.MenuConsulta.TabIndex = 5;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ForeColor = System.Drawing.Color.White;
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(46, 49);
            this.btnEjecutar.Text = "Grabar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 49);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 49);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtTitularDestino
            // 
            this.txtTitularDestino.Location = new System.Drawing.Point(117, 300);
            this.txtTitularDestino.Name = "txtTitularDestino";
            this.txtTitularDestino.ReadOnly = true;
            this.txtTitularDestino.Size = new System.Drawing.Size(328, 20);
            this.txtTitularDestino.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Titular";
            // 
            // txtNumeroCuentaDestino
            // 
            this.txtNumeroCuentaDestino.Location = new System.Drawing.Point(117, 274);
            this.txtNumeroCuentaDestino.Name = "txtNumeroCuentaDestino";
            this.txtNumeroCuentaDestino.ReadOnly = true;
            this.txtNumeroCuentaDestino.Size = new System.Drawing.Size(328, 20);
            this.txtNumeroCuentaDestino.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Numero de Cuenta";
            // 
            // btnNuevoBanco
            // 
            this.btnNuevoBanco.Location = new System.Drawing.Point(404, 243);
            this.btnNuevoBanco.Name = "btnNuevoBanco";
            this.btnNuevoBanco.Size = new System.Drawing.Size(41, 23);
            this.btnNuevoBanco.TabIndex = 14;
            this.btnNuevoBanco.Text = "...";
            this.btnNuevoBanco.UseVisualStyleBackColor = true;
            this.btnNuevoBanco.Click += new System.EventHandler(this.btnNuevoBanco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Banco Destino";
            // 
            // txtBancoDestino
            // 
            this.txtBancoDestino.Location = new System.Drawing.Point(117, 247);
            this.txtBancoDestino.Name = "txtBancoDestino";
            this.txtBancoDestino.ReadOnly = true;
            this.txtBancoDestino.Size = new System.Drawing.Size(281, 20);
            this.txtBancoDestino.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(15, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 4);
            this.panel2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Numero Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtNroCheque.Location = new System.Drawing.Point(118, 127);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.ReadOnly = true;
            this.txtNroCheque.Size = new System.Drawing.Size(327, 20);
            this.txtNroCheque.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Banco Origen";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtMonto.Location = new System.Drawing.Point(118, 153);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(327, 20);
            this.txtMonto.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Monto";
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtFechaVencimiento.Location = new System.Drawing.Point(118, 179);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.ReadOnly = true;
            this.txtFechaVencimiento.Size = new System.Drawing.Size(134, 20);
            this.txtFechaVencimiento.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Fecha Vencimiento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Datos del Cheque a Depositar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Datos Cuenta Destino";
            // 
            // txtBancoOrigen
            // 
            this.txtBancoOrigen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBancoOrigen.Location = new System.Drawing.Point(118, 101);
            this.txtBancoOrigen.Name = "txtBancoOrigen";
            this.txtBancoOrigen.ReadOnly = true;
            this.txtBancoOrigen.Size = new System.Drawing.Size(327, 20);
            this.txtBancoOrigen.TabIndex = 46;
            // 
            // _00136_DepositarCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 356);
            this.Controls.Add(this.txtBancoOrigen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFechaVencimiento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNroCheque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtBancoDestino);
            this.Controls.Add(this.txtTitularDestino);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumeroCuentaDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevoBanco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(483, 395);
            this.MinimumSize = new System.Drawing.Size(483, 395);
            this.Name = "_00136_DepositarCheque";
            this.Text = "Depositar Cheque";
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnNuevoBanco, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNumeroCuentaDestino, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTitularDestino, 0);
            this.Controls.SetChildIndex(this.txtBancoDestino, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNroCheque, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtMonto, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtFechaVencimiento, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtBancoOrigen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.TextBox txtTitularDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroCuentaDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevoBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBancoDestino;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroCheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaVencimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBancoOrigen;
    }
}