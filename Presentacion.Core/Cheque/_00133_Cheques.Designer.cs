namespace Presentacion.Core.Cheque
{
    partial class _00133_Cheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00133_Cheques));
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnDepositar = new System.Windows.Forms.ToolStripButton();
            this.btnRechazado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgLupa = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCheques = new System.Windows.Forms.TabPage();
            this.dgvCheques = new System.Windows.Forms.DataGridView();
            this.tabPageRechazados = new System.Windows.Forms.TabPage();
            this.dgvRechazados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLupa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageCheques.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).BeginInit();
            this.tabPageRechazados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 52);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(784, 6);
            this.pnlLineaMenu.TabIndex = 4;
            // 
            // MenuConsulta
            // 
            this.MenuConsulta.BackColor = System.Drawing.Color.SteelBlue;
            this.MenuConsulta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuConsulta.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.MenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDepositar,
            this.btnRechazado,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnSalir});
            this.MenuConsulta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.MenuConsulta.Name = "MenuConsulta";
            this.MenuConsulta.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.MenuConsulta.Size = new System.Drawing.Size(784, 52);
            this.MenuConsulta.TabIndex = 3;
            // 
            // btnDepositar
            // 
            this.btnDepositar.ForeColor = System.Drawing.Color.White;
            this.btnDepositar.Image = ((System.Drawing.Image)(resources.GetObject("btnDepositar.Image")));
            this.btnDepositar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(61, 49);
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnRechazado
            // 
            this.btnRechazado.ForeColor = System.Drawing.Color.White;
            this.btnRechazado.Image = ((System.Drawing.Image)(resources.GetObject("btnRechazado.Image")));
            this.btnRechazado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRechazado.Name = "btnRechazado";
            this.btnRechazado.Size = new System.Drawing.Size(68, 49);
            this.btnRechazado.Text = "Rechazado";
            this.btnRechazado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRechazado.Click += new System.EventHandler(this.btnRechazado_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 49);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.imgLupa);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 43);
            this.panel2.TabIndex = 9;
            // 
            // imgLupa
            // 
            this.imgLupa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLupa.Location = new System.Drawing.Point(218, 3);
            this.imgLupa.Name = "imgLupa";
            this.imgLupa.Size = new System.Drawing.Size(37, 37);
            this.imgLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLupa.TabIndex = 5;
            this.imgLupa.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(666, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha hasta";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha desde";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(543, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(335, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCheques);
            this.tabControl1.Controls.Add(this.tabPageRechazados);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 438);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPageCheques
            // 
            this.tabPageCheques.Controls.Add(this.dgvCheques);
            this.tabPageCheques.Location = new System.Drawing.Point(4, 22);
            this.tabPageCheques.Name = "tabPageCheques";
            this.tabPageCheques.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheques.Size = new System.Drawing.Size(776, 412);
            this.tabPageCheques.TabIndex = 0;
            this.tabPageCheques.Text = "Cheques en cartera";
            this.tabPageCheques.UseVisualStyleBackColor = true;
            // 
            // dgvCheques
            // 
            this.dgvCheques.AllowUserToAddRows = false;
            this.dgvCheques.AllowUserToDeleteRows = false;
            this.dgvCheques.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheques.Location = new System.Drawing.Point(3, 3);
            this.dgvCheques.Name = "dgvCheques";
            this.dgvCheques.ReadOnly = true;
            this.dgvCheques.RowHeadersVisible = false;
            this.dgvCheques.RowHeadersWidth = 62;
            this.dgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheques.Size = new System.Drawing.Size(770, 406);
            this.dgvCheques.TabIndex = 5;
            this.dgvCheques.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheques_RowEnter);
            // 
            // tabPageRechazados
            // 
            this.tabPageRechazados.Controls.Add(this.dgvRechazados);
            this.tabPageRechazados.Location = new System.Drawing.Point(4, 22);
            this.tabPageRechazados.Name = "tabPageRechazados";
            this.tabPageRechazados.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRechazados.Size = new System.Drawing.Size(776, 412);
            this.tabPageRechazados.TabIndex = 1;
            this.tabPageRechazados.Text = "Rechazados";
            this.tabPageRechazados.UseVisualStyleBackColor = true;
            // 
            // dgvRechazados
            // 
            this.dgvRechazados.AllowUserToAddRows = false;
            this.dgvRechazados.AllowUserToDeleteRows = false;
            this.dgvRechazados.BackgroundColor = System.Drawing.Color.White;
            this.dgvRechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRechazados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRechazados.Location = new System.Drawing.Point(3, 3);
            this.dgvRechazados.Name = "dgvRechazados";
            this.dgvRechazados.ReadOnly = true;
            this.dgvRechazados.RowHeadersVisible = false;
            this.dgvRechazados.RowHeadersWidth = 62;
            this.dgvRechazados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRechazados.Size = new System.Drawing.Size(770, 406);
            this.dgvRechazados.TabIndex = 5;
            // 
            // _00133_Cheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(798, 486);
            this.Name = "_00133_Cheques";
            this.Text = "Cheques";
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLupa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCheques.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheques)).EndInit();
            this.tabPageRechazados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRechazados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        private System.Windows.Forms.ToolStripButton btnDepositar;
        private System.Windows.Forms.ToolStripButton btnRechazado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox imgLupa;
        public System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCheques;
        private System.Windows.Forms.TabPage tabPageRechazados;
        public System.Windows.Forms.DataGridView dgvCheques;
        public System.Windows.Forms.DataGridView dgvRechazados;
    }
}