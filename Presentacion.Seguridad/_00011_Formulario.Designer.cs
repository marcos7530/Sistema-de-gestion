namespace Presentacion.Seguridad
{
    partial class _00011_Formulario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00011_Formulario));
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.imgLupa = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnCrear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLupa)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.Silver;
            this.pnlBusqueda.Controls.Add(this.imgLupa);
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBusqueda);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 71);
            this.pnlBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(1167, 74);
            this.pnlBusqueda.TabIndex = 13;
            // 
            // imgLupa
            // 
            this.imgLupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLupa.Location = new System.Drawing.Point(571, 9);
            this.imgLupa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgLupa.Name = "imgLupa";
            this.imgLupa.Size = new System.Drawing.Size(56, 57);
            this.imgLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLupa.TabIndex = 3;
            this.imgLupa.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(996, 14);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(159, 43);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(635, 18);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(350, 30);
            this.txtBusqueda.TabIndex = 1;
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 64);
            this.pnlLineaMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(1167, 7);
            this.pnlLineaMenu.TabIndex = 12;
            // 
            // MenuConsulta
            // 
            this.MenuConsulta.BackColor = System.Drawing.Color.SteelBlue;
            this.MenuConsulta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuConsulta.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.MenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCrear,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnSalir});
            this.MenuConsulta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.MenuConsulta.Name = "MenuConsulta";
            this.MenuConsulta.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.MenuConsulta.Size = new System.Drawing.Size(1167, 64);
            this.MenuConsulta.TabIndex = 11;
            // 
            // btnCrear
            // 
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(57, 59);
            this.btnCrear.Text = "Crear";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 64);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(92, 59);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 145);
            this.dgvGrilla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.RowHeadersWidth = 62;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(1167, 670);
            this.dgvGrilla.TabIndex = 14;
            // 
            // _00011_Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 837);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximumSize = new System.Drawing.Size(1189, 893);
            this.MinimumSize = new System.Drawing.Size(1189, 893);
            this.Name = "_00011_Formulario";
            this.Text = "Formularios";
            this.Load += new System.EventHandler(this._00011_Formulario_Load);
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.pnlBusqueda, 0);
            this.Controls.SetChildIndex(this.dgvGrilla, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLupa)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.PictureBox imgLupa;
        public System.Windows.Forms.Button btnBuscar;
        public System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        private System.Windows.Forms.ToolStripButton btnCrear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        public System.Windows.Forms.DataGridView dgvGrilla;
    }
}