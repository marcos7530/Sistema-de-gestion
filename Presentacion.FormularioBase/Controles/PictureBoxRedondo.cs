﻿namespace Presentacion.FormularioBase.Controles
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class PictureBoxRedondo : PictureBox
    {
        public PictureBoxRedondo()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }
}
