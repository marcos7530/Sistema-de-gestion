namespace Presentacion.Core.FormaPago
{
    partial class PendientesPago
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.dgvGrillaDetalles = new System.Windows.Forms.DataGridView();
            this.dgvGrillaPendientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFacturar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 81);
            this.panel1.TabIndex = 1;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(29, 12);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 59);
            this.btnFacturar.TabIndex = 0;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nudTotal);
            this.panel2.Controls.Add(this.dgvGrillaDetalles);
            this.panel2.Controls.Add(this.dgvGrillaPendientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 347);
            this.panel2.TabIndex = 2;
            // 
            // nudTotal
            // 
            this.nudTotal.BackColor = System.Drawing.SystemColors.InfoText;
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.nudTotal.Location = new System.Drawing.Point(426, 272);
            this.nudTotal.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.ReadOnly = true;
            this.nudTotal.Size = new System.Drawing.Size(371, 47);
            this.nudTotal.TabIndex = 6;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvGrillaDetalles
            // 
            this.dgvGrillaDetalles.AllowUserToAddRows = false;
            this.dgvGrillaDetalles.AllowUserToDeleteRows = false;
            this.dgvGrillaDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrillaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaDetalles.Location = new System.Drawing.Point(426, 0);
            this.dgvGrillaDetalles.Name = "dgvGrillaDetalles";
            this.dgvGrillaDetalles.ReadOnly = true;
            this.dgvGrillaDetalles.RowHeadersVisible = false;
            this.dgvGrillaDetalles.RowHeadersWidth = 62;
            this.dgvGrillaDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaDetalles.Size = new System.Drawing.Size(374, 266);
            this.dgvGrillaDetalles.TabIndex = 5;
            // 
            // dgvGrillaPendientes
            // 
            this.dgvGrillaPendientes.AllowUserToAddRows = false;
            this.dgvGrillaPendientes.AllowUserToDeleteRows = false;
            this.dgvGrillaPendientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrillaPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaPendientes.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvGrillaPendientes.Location = new System.Drawing.Point(0, 0);
            this.dgvGrillaPendientes.Name = "dgvGrillaPendientes";
            this.dgvGrillaPendientes.ReadOnly = true;
            this.dgvGrillaPendientes.RowHeadersVisible = false;
            this.dgvGrillaPendientes.RowHeadersWidth = 62;
            this.dgvGrillaPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaPendientes.Size = new System.Drawing.Size(420, 347);
            this.dgvGrillaPendientes.TabIndex = 4;
            this.dgvGrillaPendientes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaPendientes_RowEnter);
            this.dgvGrillaPendientes.Click += new System.EventHandler(this.dgvGrillaPendientes_Click);
            // 
            // PendientesPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PendientesPago";
            this.Text = "PendientesPago";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.DataGridView dgvGrillaDetalles;
        private System.Windows.Forms.DataGridView dgvGrillaPendientes;
    }
}