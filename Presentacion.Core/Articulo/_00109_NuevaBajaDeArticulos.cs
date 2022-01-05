namespace Presentacion.Core.Articulo
{
    using System;
    using System.Collections.Generic;
    using System.Transactions;
    using System.Windows.Forms;
    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using Presentacion.Core.LookUp;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.BajaArticulo;
    using Servicio.Interfaces.MotivoBaja;
    using Servicio.Interfaces.MotivoBaja.DTOs;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00109_NuevaBajaDeArticulos : Formulario
    {
        private readonly IArticuloServicio _arcticuloServicio;
        private readonly IMotivoBajaServicio _motivoBajaServicio;
        private readonly IBajaArticuloServicio _bajaArticuloServicio;

        private ArticuloDto _articulo;

        public _00109_NuevaBajaDeArticulos(IArticuloServicio arcticuloServicio,
                                           IMotivoBajaServicio motivoBajaServicio,
                                           IBajaArticuloServicio bajaArticuloServicio)
        {
            InitializeComponent();
            _arcticuloServicio = arcticuloServicio;
            _motivoBajaServicio = motivoBajaServicio;
            _bajaArticuloServicio = bajaArticuloServicio;
            imgFotoArticulo.Image = Imagen.Camara;

            txtDescripcionArticulo.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            txtObservacion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            CargarMotivosBaja();
            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
           AgregarControlesObligatorios(txtDescripcionArticulo,"Descripcion Articulo");
           AgregarControlesObligatorios(nudStockActual, "Stock Actual");
           AgregarControlesObligatorios(nudCantidadBaja, "Cantidad Para Baja");
           AgregarControlesObligatorios(cmbMotivoBaja, "Motivo de Baja");
           AgregarControlesObligatorios(txtObservacion, "Observacion");

        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcionArticulo.Text)) return false;
            if (string.IsNullOrEmpty(txtObservacion.Text)) return false;

            if (cmbMotivoBaja.Items.Count <= 0) return false;

            if (nudCantidadBaja.Value <= 0) return false;
            if (nudStockActual.Value <= 0) return false;

            return true;
        }

        private void CargarMotivosBaja()
        {
            var motivoBaja = _motivoBajaServicio.Get(string.Empty);
            CargarCombo(motivoBaja);
        }

        private void CargarCombo(IEnumerable<MotivoBajaDto> motivoBaja)
        {
            if (motivoBaja != null)
            {
                Poblar_ComboBox(cmbMotivoBaja, motivoBaja, "Descripcion", "Id");
            }
        }

        private void btnNuevoMotivoBaja_Click(object sender, EventArgs e)
        {
            try
            {
                var fNuevo = new _00107_Abm_MotivoBajaArticulo(TipoOperacion.Nuevo);
                fNuevo.ShowDialog();
                CargarMotivosBaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Ocurrió un Error. {ex.Message}");
            }
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            var fLookUpArticulo = ObjectFactory.GetInstance<LookUpArticulo>();
            fLookUpArticulo.ShowDialog();
            if (fLookUpArticulo.EntidadSeleccionada != null)
            {
                var articuloSeleccionado = (ArticuloDto)fLookUpArticulo.EntidadSeleccionada;
                if (articuloSeleccionado != null)
                {
                    _articulo = articuloSeleccionado;
                    txtDescripcionArticulo.Text = articuloSeleccionado.Descripcion;
                    nudStockActual.Value = articuloSeleccionado.Stock;
                    imgFotoArticulo.Image = Imagen.Convertir(articuloSeleccionado.Foto);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            imgFotoArticulo.Image = Imagen.Camara;
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtDescripcionArticulo.Text)
            //    && nudCantidadBaja.Value != 0
            //    && nudCantidadBaja.Value <= nudStockActual.Value
            //    && !string.IsNullOrEmpty(cmbMotivoBaja.Text))
            //{

            //}

            decimal nuevoStock = nudStockActual.Value - nudCantidadBaja.Value;

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            if (nudStockActual.Value < nudCantidadBaja.Value)
            {
                MessageBox.Show("El stock a dar de baja no puede ser mayor al stock actual!", "Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            using (var tran = new TransactionScope())
            {
                try
                {
                    _arcticuloServicio.UpdateStock(_articulo, nuevoStock);
                    _bajaArticuloServicio.Add(new Servicio.Interfaces.BajaArticulo.DTOs.BajaArticuloDto
                    {
                        ArticuloId = _articulo.Id,
                        MotivoBajaId = (long)cmbMotivoBaja.SelectedValue,
                        Cantidad = nudCantidadBaja.Value,
                        Fecha = DateTime.Now,
                        Observacion = txtObservacion.Text,
                        EstaEliminado = false
                    });
                    tran.Complete();

                    MessageBox.Show($@"El articulo {_articulo.Descripcion} fué dado de baja con exito!");

                    btnLimpiar.PerformClick();
                }
                catch (Exception exc)
                {
                    tran.Dispose();
                    MessageBox.Show($@"Error dando de baja{_articulo.Descripcion} en {exc.Message}");
                }
            }
        }
    }
}
