namespace Presentacion.Core.Articulo
{
    partial class _00109_NuevaBajaDeArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00109_NuevaBajaDeArticulos));
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.txtDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.btnNuevoMotivoBaja = new System.Windows.Forms.Button();
            this.cmbMotivoBaja = new System.Windows.Forms.ComboBox();
            this.lblMotivoDeBaja = new System.Windows.Forms.Label();
            this.nudStockActual = new System.Windows.Forms.NumericUpDown();
            this.nudCantidadBaja = new System.Windows.Forms.NumericUpDown();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.lblCantidadBaja = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.lblFoto = new System.Windows.Forms.Label();
            this.imgFotoArticulo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBaja)).BeginInit();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 52);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(680, 6);
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
            this.MenuConsulta.Size = new System.Drawing.Size(680, 52);
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
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.Enabled = false;
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(100, 81);
            this.txtDescripcionArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.ReadOnly = true;
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(323, 20);
            this.txtDescripcionArticulo.TabIndex = 95;
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(51, 85);
            this.lblArticulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(42, 13);
            this.lblArticulo.TabIndex = 96;
            this.lblArticulo.Text = "Articulo";
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArticulo.Location = new System.Drawing.Point(427, 79);
            this.btnBuscarArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(37, 23);
            this.btnBuscarArticulo.TabIndex = 123;
            this.btnBuscarArticulo.Text = "...";
            this.btnBuscarArticulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // btnNuevoMotivoBaja
            // 
            this.btnNuevoMotivoBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoMotivoBaja.Location = new System.Drawing.Point(427, 130);
            this.btnNuevoMotivoBaja.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevoMotivoBaja.Name = "btnNuevoMotivoBaja";
            this.btnNuevoMotivoBaja.Size = new System.Drawing.Size(37, 23);
            this.btnNuevoMotivoBaja.TabIndex = 135;
            this.btnNuevoMotivoBaja.Text = "...";
            this.btnNuevoMotivoBaja.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevoMotivoBaja.UseVisualStyleBackColor = true;
            this.btnNuevoMotivoBaja.Click += new System.EventHandler(this.btnNuevoMotivoBaja_Click);
            // 
            // cmbMotivoBaja
            // 
            this.cmbMotivoBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivoBaja.Location = new System.Drawing.Point(100, 131);
            this.cmbMotivoBaja.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMotivoBaja.Name = "cmbMotivoBaja";
            this.cmbMotivoBaja.Size = new System.Drawing.Size(323, 21);
            this.cmbMotivoBaja.TabIndex = 134;
            // 
            // lblMotivoDeBaja
            // 
            this.lblMotivoDeBaja.AutoSize = true;
            this.lblMotivoDeBaja.Location = new System.Drawing.Point(15, 135);
            this.lblMotivoDeBaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMotivoDeBaja.Name = "lblMotivoDeBaja";
            this.lblMotivoDeBaja.Size = new System.Drawing.Size(78, 13);
            this.lblMotivoDeBaja.TabIndex = 136;
            this.lblMotivoDeBaja.Text = "Motivo de Baja";
            // 
            // nudStockActual
            // 
            this.nudStockActual.Enabled = false;
            this.nudStockActual.Location = new System.Drawing.Point(100, 106);
            this.nudStockActual.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudStockActual.Name = "nudStockActual";
            this.nudStockActual.ReadOnly = true;
            this.nudStockActual.Size = new System.Drawing.Size(95, 20);
            this.nudStockActual.TabIndex = 137;
            // 
            // nudCantidadBaja
            // 
            this.nudCantidadBaja.Location = new System.Drawing.Point(328, 106);
            this.nudCantidadBaja.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCantidadBaja.Name = "nudCantidadBaja";
            this.nudCantidadBaja.Size = new System.Drawing.Size(95, 20);
            this.nudCantidadBaja.TabIndex = 138;
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Location = new System.Drawing.Point(25, 110);
            this.lblStockActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(68, 13);
            this.lblStockActual.TabIndex = 139;
            this.lblStockActual.Text = "Stock Actual";
            // 
            // lblCantidadBaja
            // 
            this.lblCantidadBaja.AutoSize = true;
            this.lblCantidadBaja.Location = new System.Drawing.Point(226, 109);
            this.lblCantidadBaja.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadBaja.Name = "lblCantidadBaja";
            this.lblCantidadBaja.Size = new System.Drawing.Size(97, 13);
            this.lblCantidadBaja.TabIndex = 140;
            this.lblCantidadBaja.Text = "Cantidad para Baja";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(100, 157);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(323, 135);
            this.txtObservacion.TabIndex = 141;
            this.txtObservacion.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "Observación";
            // 
            // pnlFoto
            // 
            this.pnlFoto.BackColor = System.Drawing.Color.Silver;
            this.pnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFoto.Controls.Add(this.lblFoto);
            this.pnlFoto.Controls.Add(this.imgFotoArticulo);
            this.pnlFoto.Location = new System.Drawing.Point(480, 81);
            this.pnlFoto.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(180, 211);
            this.pnlFoto.TabIndex = 148;
            // 
            // lblFoto
            // 
            this.lblFoto.BackColor = System.Drawing.Color.SteelBlue;
            this.lblFoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.ForeColor = System.Drawing.Color.White;
            this.lblFoto.Location = new System.Drawing.Point(0, 0);
            this.lblFoto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(178, 29);
            this.lblFoto.TabIndex = 84;
            this.lblFoto.Text = "Foto";
            this.lblFoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgFotoArticulo
            // 
            this.imgFotoArticulo.BackColor = System.Drawing.Color.White;
            this.imgFotoArticulo.Location = new System.Drawing.Point(5, 35);
            this.imgFotoArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.imgFotoArticulo.Name = "imgFotoArticulo";
            this.imgFotoArticulo.Size = new System.Drawing.Size(168, 169);
            this.imgFotoArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoArticulo.TabIndex = 0;
            this.imgFotoArticulo.TabStop = false;
            // 
            // _00109_NuevaBajaDeArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 337);
            this.Controls.Add(this.pnlFoto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblCantidadBaja);
            this.Controls.Add(this.lblStockActual);
            this.Controls.Add(this.nudCantidadBaja);
            this.Controls.Add(this.nudStockActual);
            this.Controls.Add(this.btnNuevoMotivoBaja);
            this.Controls.Add(this.cmbMotivoBaja);
            this.Controls.Add(this.lblMotivoDeBaja);
            this.Controls.Add(this.btnBuscarArticulo);
            this.Controls.Add(this.txtDescripcionArticulo);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.MaximumSize = new System.Drawing.Size(696, 376);
            this.MinimumSize = new System.Drawing.Size(696, 376);
            this.Name = "_00109_NuevaBajaDeArticulos";
            this.Text = "Baja de Articulos del Stock";
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.lblArticulo, 0);
            this.Controls.SetChildIndex(this.txtDescripcionArticulo, 0);
            this.Controls.SetChildIndex(this.btnBuscarArticulo, 0);
            this.Controls.SetChildIndex(this.lblMotivoDeBaja, 0);
            this.Controls.SetChildIndex(this.cmbMotivoBaja, 0);
            this.Controls.SetChildIndex(this.btnNuevoMotivoBaja, 0);
            this.Controls.SetChildIndex(this.nudStockActual, 0);
            this.Controls.SetChildIndex(this.nudCantidadBaja, 0);
            this.Controls.SetChildIndex(this.lblStockActual, 0);
            this.Controls.SetChildIndex(this.lblCantidadBaja, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pnlFoto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadBaja)).EndInit();
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.TextBox txtDescripcionArticulo;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.Button btnNuevoMotivoBaja;
        private System.Windows.Forms.ComboBox cmbMotivoBaja;
        private System.Windows.Forms.Label lblMotivoDeBaja;
        private System.Windows.Forms.NumericUpDown nudStockActual;
        private System.Windows.Forms.NumericUpDown nudCantidadBaja;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.Label lblCantidadBaja;
        private System.Windows.Forms.RichTextBox txtObservacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.PictureBox imgFotoArticulo;
    }
}