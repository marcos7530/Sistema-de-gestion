namespace Presentacion.Core.FormaPago
{
    partial class _00177_CobroFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00177_CobroFactura));
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnFacturar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlDetalleFactura = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.pnlListaFacturas = new System.Windows.Forms.Panel();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            this.pnlDetalleFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            this.pnlListaFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
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
            this.pnlLineaMenu.Size = new System.Drawing.Size(1176, 7);
            this.pnlLineaMenu.TabIndex = 6;
            // 
            // MenuConsulta
            // 
            this.MenuConsulta.BackColor = System.Drawing.Color.SteelBlue;
            this.MenuConsulta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuConsulta.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.MenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFacturar,
            this.btnSalir});
            this.MenuConsulta.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.MenuConsulta.Name = "MenuConsulta";
            this.MenuConsulta.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.MenuConsulta.Size = new System.Drawing.Size(1176, 64);
            this.MenuConsulta.TabIndex = 5;
            // 
            // btnFacturar
            // 
            this.btnFacturar.ForeColor = System.Drawing.Color.White;
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(78, 59);
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlDetalleFactura
            // 
            this.pnlDetalleFactura.Controls.Add(this.dgvDetalle);
            this.pnlDetalleFactura.Controls.Add(this.nudTotal);
            this.pnlDetalleFactura.Controls.Add(this.pnlSeparador);
            this.pnlDetalleFactura.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetalleFactura.Location = new System.Drawing.Point(691, 71);
            this.pnlDetalleFactura.Name = "pnlDetalleFactura";
            this.pnlDetalleFactura.Size = new System.Drawing.Size(485, 770);
            this.pnlDetalleFactura.TabIndex = 7;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(7, 0);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(478, 717);
            this.dgvDetalle.TabIndex = 15;
            // 
            // nudTotal
            // 
            this.nudTotal.BackColor = System.Drawing.Color.Black;
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.ForeColor = System.Drawing.Color.White;
            this.nudTotal.Location = new System.Drawing.Point(7, 717);
            this.nudTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudTotal.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.ReadOnly = true;
            this.nudTotal.Size = new System.Drawing.Size(478, 53);
            this.nudTotal.TabIndex = 14;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(7, 770);
            this.pnlSeparador.TabIndex = 8;
            // 
            // pnlListaFacturas
            // 
            this.pnlListaFacturas.Controls.Add(this.dgvFacturas);
            this.pnlListaFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaFacturas.Location = new System.Drawing.Point(0, 71);
            this.pnlListaFacturas.Name = "pnlListaFacturas";
            this.pnlListaFacturas.Size = new System.Drawing.Size(691, 770);
            this.pnlListaFacturas.TabIndex = 8;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.RowHeadersWidth = 62;
            this.dgvFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFacturas.RowTemplate.Height = 28;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(691, 770);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_RowEnter);
            this.dgvFacturas.DoubleClick += new System.EventHandler(this.dgvFacturas_DoubleClick);
            // 
            // _00177_CobroFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 863);
            this.Controls.Add(this.pnlListaFacturas);
            this.Controls.Add(this.pnlDetalleFactura);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.MaximumSize = new System.Drawing.Size(1198, 919);
            this.MinimumSize = new System.Drawing.Size(1198, 919);
            this.Name = "_00177_CobroFactura";
            this.Text = "Cobro de Factura";
            this.Load += new System.EventHandler(this._00177_CobroFactura_Load);
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.pnlDetalleFactura, 0);
            this.Controls.SetChildIndex(this.pnlListaFacturas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            this.pnlDetalleFactura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            this.pnlListaFacturas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        public System.Windows.Forms.ToolStripButton btnFacturar;
        public System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlDetalleFactura;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Panel pnlListaFacturas;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.NumericUpDown nudTotal;
    }
}