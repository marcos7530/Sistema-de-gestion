namespace Presentacion.Core.Articulo
{
    partial class _00124_ActualizacionPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00124_ActualizacionPrecios));
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.pnlLineaMenu = new System.Windows.Forms.Panel();
            this.MenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.chkMarca = new System.Windows.Forms.CheckBox();
            this.chkRubro = new System.Windows.Forms.CheckBox();
            this.chkArticulo = new System.Windows.Forms.CheckBox();
            this.txtCodigoDesde = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCodigoHasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbListaPrecio = new System.Windows.Forms.ComboBox();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbPorcentaje = new System.Windows.Forms.RadioButton();
            this.rdbMonto = new System.Windows.Forms.RadioButton();
            this.chkListaPrecioCompleta = new System.Windows.Forms.CheckBox();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.MenuConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRubro
            // 
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.Enabled = false;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(139, 112);
            this.cmbRubro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(337, 21);
            this.cmbRubro.TabIndex = 148;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Enabled = false;
            this.cmbMarca.Location = new System.Drawing.Point(139, 84);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(337, 21);
            this.cmbMarca.TabIndex = 147;
            // 
            // pnlLineaMenu
            // 
            this.pnlLineaMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlLineaMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaMenu.Location = new System.Drawing.Point(0, 52);
            this.pnlLineaMenu.Name = "pnlLineaMenu";
            this.pnlLineaMenu.Size = new System.Drawing.Size(509, 6);
            this.pnlLineaMenu.TabIndex = 154;
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
            this.MenuConsulta.Size = new System.Drawing.Size(509, 52);
            this.MenuConsulta.TabIndex = 153;
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
            // chkMarca
            // 
            this.chkMarca.AutoSize = true;
            this.chkMarca.Location = new System.Drawing.Point(74, 86);
            this.chkMarca.Name = "chkMarca";
            this.chkMarca.Size = new System.Drawing.Size(56, 17);
            this.chkMarca.TabIndex = 155;
            this.chkMarca.Text = "Marca";
            this.chkMarca.UseVisualStyleBackColor = true;
            this.chkMarca.CheckedChanged += new System.EventHandler(this.chkMarca_CheckedChanged);
            // 
            // chkRubro
            // 
            this.chkRubro.AutoSize = true;
            this.chkRubro.Location = new System.Drawing.Point(74, 114);
            this.chkRubro.Name = "chkRubro";
            this.chkRubro.Size = new System.Drawing.Size(55, 17);
            this.chkRubro.TabIndex = 156;
            this.chkRubro.Text = "Rubro";
            this.chkRubro.UseVisualStyleBackColor = true;
            this.chkRubro.CheckedChanged += new System.EventHandler(this.chkRubro_CheckedChanged);
            // 
            // chkArticulo
            // 
            this.chkArticulo.AutoSize = true;
            this.chkArticulo.Location = new System.Drawing.Point(74, 164);
            this.chkArticulo.Name = "chkArticulo";
            this.chkArticulo.Size = new System.Drawing.Size(61, 17);
            this.chkArticulo.TabIndex = 157;
            this.chkArticulo.Text = "Articulo";
            this.chkArticulo.UseVisualStyleBackColor = true;
            this.chkArticulo.CheckedChanged += new System.EventHandler(this.chkArticulo_CheckedChanged);
            // 
            // txtCodigoDesde
            // 
            this.txtCodigoDesde.Enabled = false;
            this.txtCodigoDesde.Location = new System.Drawing.Point(139, 163);
            this.txtCodigoDesde.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoDesde.Name = "txtCodigoDesde";
            this.txtCodigoDesde.Size = new System.Drawing.Size(147, 20);
            this.txtCodigoDesde.TabIndex = 158;
            this.txtCodigoDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDesde_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(176, 146);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 13);
            this.label17.TabIndex = 159;
            this.label17.Text = "Codigo desde";
            // 
            // txtCodigoHasta
            // 
            this.txtCodigoHasta.Enabled = false;
            this.txtCodigoHasta.Location = new System.Drawing.Point(329, 162);
            this.txtCodigoHasta.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoHasta.Name = "txtCodigoHasta";
            this.txtCodigoHasta.Size = new System.Drawing.Size(147, 20);
            this.txtCodigoHasta.TabIndex = 160;
            this.txtCodigoHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDesde_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 161;
            this.label1.Text = "Codigo hasta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(38, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 163;
            this.label10.Text = "Lista de Precio";
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(141, 232);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(337, 24);
            this.cmbListaPrecio.TabIndex = 162;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSeparador.Location = new System.Drawing.Point(27, 195);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(449, 4);
            this.pnlSeparador.TabIndex = 164;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 166;
            this.label2.Text = "Valor";
            // 
            // rdbPorcentaje
            // 
            this.rdbPorcentaje.AutoSize = true;
            this.rdbPorcentaje.Checked = true;
            this.rdbPorcentaje.Location = new System.Drawing.Point(283, 275);
            this.rdbPorcentaje.Name = "rdbPorcentaje";
            this.rdbPorcentaje.Size = new System.Drawing.Size(45, 17);
            this.rdbPorcentaje.TabIndex = 167;
            this.rdbPorcentaje.TabStop = true;
            this.rdbPorcentaje.Text = "[ % ]";
            this.rdbPorcentaje.UseVisualStyleBackColor = true;
            // 
            // rdbMonto
            // 
            this.rdbMonto.AutoSize = true;
            this.rdbMonto.Location = new System.Drawing.Point(334, 275);
            this.rdbMonto.Name = "rdbMonto";
            this.rdbMonto.Size = new System.Drawing.Size(43, 17);
            this.rdbMonto.TabIndex = 168;
            this.rdbMonto.Text = "[ $ ]";
            this.rdbMonto.UseVisualStyleBackColor = true;
            // 
            // chkListaPrecioCompleta
            // 
            this.chkListaPrecioCompleta.AutoSize = true;
            this.chkListaPrecioCompleta.Location = new System.Drawing.Point(74, 205);
            this.chkListaPrecioCompleta.Name = "chkListaPrecioCompleta";
            this.chkListaPrecioCompleta.Size = new System.Drawing.Size(155, 17);
            this.chkListaPrecioCompleta.TabIndex = 169;
            this.chkListaPrecioCompleta.Text = "Todas las Listas de Precios";
            this.chkListaPrecioCompleta.UseVisualStyleBackColor = true;
            this.chkListaPrecioCompleta.CheckedChanged += new System.EventHandler(this.chkListaPrecioCompleta_CheckedChanged);
            // 
            // nudValor
            // 
            this.nudValor.DecimalPlaces = 2;
            this.nudValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValor.Location = new System.Drawing.Point(146, 273);
            this.nudValor.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(120, 22);
            this.nudValor.TabIndex = 165;
            // 
            // _00124_ActualizacionPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 320);
            this.Controls.Add(this.chkListaPrecioCompleta);
            this.Controls.Add(this.rdbMonto);
            this.Controls.Add(this.rdbPorcentaje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudValor);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbListaPrecio);
            this.Controls.Add(this.txtCodigoHasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigoDesde);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.chkArticulo);
            this.Controls.Add(this.chkRubro);
            this.Controls.Add(this.chkMarca);
            this.Controls.Add(this.pnlLineaMenu);
            this.Controls.Add(this.MenuConsulta);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.cmbMarca);
            this.MaximumSize = new System.Drawing.Size(525, 359);
            this.MinimumSize = new System.Drawing.Size(525, 359);
            this.Name = "_00124_ActualizacionPrecios";
            this.Text = "Actualización de Precios";
            this.Controls.SetChildIndex(this.cmbMarca, 0);
            this.Controls.SetChildIndex(this.cmbRubro, 0);
            this.Controls.SetChildIndex(this.MenuConsulta, 0);
            this.Controls.SetChildIndex(this.pnlLineaMenu, 0);
            this.Controls.SetChildIndex(this.chkMarca, 0);
            this.Controls.SetChildIndex(this.chkRubro, 0);
            this.Controls.SetChildIndex(this.chkArticulo, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.txtCodigoDesde, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodigoHasta, 0);
            this.Controls.SetChildIndex(this.cmbListaPrecio, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.pnlSeparador, 0);
            this.Controls.SetChildIndex(this.nudValor, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.rdbPorcentaje, 0);
            this.Controls.SetChildIndex(this.rdbMonto, 0);
            this.Controls.SetChildIndex(this.chkListaPrecioCompleta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.MenuConsulta.ResumeLayout(false);
            this.MenuConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Panel pnlLineaMenu;
        public System.Windows.Forms.ToolStrip MenuConsulta;
        private System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.CheckBox chkMarca;
        private System.Windows.Forms.CheckBox chkRubro;
        private System.Windows.Forms.CheckBox chkArticulo;
        private System.Windows.Forms.TextBox txtCodigoDesde;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCodigoHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbListaPrecio;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbPorcentaje;
        private System.Windows.Forms.RadioButton rdbMonto;
        private System.Windows.Forms.CheckBox chkListaPrecioCompleta;
        private System.Windows.Forms.NumericUpDown nudValor;
    }
}