namespace Presentacion.FormularioBase
{
    partial class FormularioAbm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioAbm));
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 64);
            this.pnlLineaMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(650, 7);
            this.pnlLineaMenu.TabIndex = 4;
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
            this.MenuConsulta.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.MenuConsulta.Size = new System.Drawing.Size(650, 64);
            this.MenuConsulta.TabIndex = 3;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ForeColor = System.Drawing.Color.White;
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(69, 59);
            this.btnEjecutar.Text = "Grabar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.BtnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(74, 59);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 59);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FormularioAbm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 412);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "FormularioAbm";
            this.Text = "ABM";
            this.Load += new System.EventHandler(this.FormularioAbm_Load);
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        public System.Windows.Forms.ToolStripButton btnEjecutar;
        public System.Windows.Forms.ToolStripButton btnLimpiar;
        public System.Windows.Forms.ToolStripButton btnSalir;
    }
}