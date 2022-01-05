using Servicio.Interfaces.Precio.DTOs;

namespace Presentacion.Core.Articulo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using FormularioBase;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Precio;
    using Servicio.Interfaces.Rubro;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00124_ActualizacionPrecios : Formulario
    {
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IListaPrecioServicio _listaPrecioServicio;
        private readonly IPrecioServicio _precioServicio;

        private decimal? _monto = null;
        private decimal? _porcentaje = null;

        //private ListaPrecioDto _listaPrecio;


        public _00124_ActualizacionPrecios(IMarcaServicio marcaServicio,
            IRubroServicio rubroServicio,
            IArticuloServicio articuloServicio,
            IListaPrecioServicio listaPrecioServicio,
            IPrecioServicio precioServicio)
        {
            InitializeComponent();
            _marcaServicio = marcaServicio;
            _rubroServicio = rubroServicio;
            _articuloServicio = articuloServicio;
            _listaPrecioServicio = listaPrecioServicio;
            _precioServicio = precioServicio;

            IEnumerable<ListaPrecioDto> _todasListasprecio = _listaPrecioServicio.Get(String.Empty);

            CargarDatos();

            txtCodigoDesde.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtCodigoHasta.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };
        }

        private void CargarDatos()
        {
            var marcas = _marcaServicio.Get(string.Empty);
            var rubros = _rubroServicio.Get(string.Empty);
            var articulos = _articuloServicio.Get(string.Empty);
            var listaPrecios = _listaPrecioServicio.Get(string.Empty);

            if (marcas != null)
                Poblar_ComboBox(cmbMarca, marcas, "Descripcion", "Id");
            else
                MessageBox.Show("Debe cargar alguna marca primero");

            if (rubros != null)
                Poblar_ComboBox(cmbRubro, rubros, "Descripcion", "Id");
            else
                MessageBox.Show("Debe cargar algun rubro primero");

            if (listaPrecios != null)
                Poblar_ComboBox(cmbListaPrecio, listaPrecios, "Descripcion", "Id");
            else
                MessageBox.Show("Debe cargar alguna lista de precio primero");

        }

        private void chkMarca_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkMarca.Checked)
            {
                chkRubro.Checked = false;
                chkArticulo.Checked = false;
                cmbMarca.Enabled = true;
                cmbRubro.Enabled = false;
                txtCodigoDesde.Enabled = false;
                txtCodigoHasta.Enabled = false;
            }
            else
                cmbMarca.Enabled = false;
        }

        private void chkRubro_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkRubro.Checked)
            {
                chkMarca.Checked = false;
                chkArticulo.Checked = false;
                cmbRubro.Enabled = true;
                cmbMarca.Enabled = false;
                txtCodigoDesde.Enabled = false;
                txtCodigoHasta.Enabled = false;
            }
            else
                cmbRubro.Enabled = false;
        }

        private void chkArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArticulo.Checked)
            {
                chkMarca.Checked = false;
                chkRubro.Checked = false;
                cmbRubro.Enabled = false;
                cmbMarca.Enabled = false;
                txtCodigoDesde.Enabled = true;
                txtCodigoHasta.Enabled = true;
            }
            else
            {
                txtCodigoHasta.Enabled = false;
                txtCodigoDesde.Enabled = false;
            }
        }

        private void txtCodigoDesde_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (nudValor.Value > 0) // SE FIJA QUE HAYA ALGO EN EL NUD DEL VALOR
            {
                if (rdbMonto.Checked) //SE FIJA SI ACTUALIZA EN UN PORCENTAJE O EN UN MONTO
                {
                    _monto = nudValor.Value;
                    //_porcentaje = null;
                }
                else
                {
                    //_monto = null;
                    _porcentaje = nudValor.Value;
                }

                if (chkArticulo.Checked) //ACTUALIZAR POR CODIGO
                {
                    if (!string.IsNullOrEmpty(txtCodigoDesde.Text)
                        && !string.IsNullOrEmpty(txtCodigoHasta.Text))
                    {
                        if (int.Parse(txtCodigoDesde.Text)
                            <= int.Parse(txtCodigoHasta.Text))
                        {
                            ActualizarPorCodigos(int.Parse(txtCodigoDesde.Text), int.Parse(txtCodigoHasta.Text));
                        }
                        else
                        {
                            MessageBox.Show("Los codigos no se cargaron correctamente");
                            return;
                        }
                    }
                }
                else if (chkMarca.Checked) //ACTUALIZAR POR MARCA
                {
                    ActualizarPorMarca((long) cmbMarca.SelectedValue);
                    LimpiarControles(this);
                }
                else if (chkRubro.Checked) //ACTUALIZAR POR RUBRO
                {
                    ActualizarPorRubro((long) cmbRubro.SelectedValue);
                    LimpiarControles(this);
                }
                else if (chkListaPrecioCompleta.Checked)//ACTUALIZA TODAS LAS LISTAS DE PRECIO
                {
                    ActualizarTodasLasListasDeprecio(_precioServicio.Get(string.Empty));
                    LimpiarControles(this);
                }
                else if (chkMarca.Checked==false
                         &&chkRubro.Checked==false
                         &&chkArticulo.Checked==false
                         &&chkListaPrecioCompleta.Checked==false)//ACTUALIZA DETERMINADA LISTA DE PRECIO
                {
                    ActulizarDeterminadaListaDePrecio((long)cmbListaPrecio.SelectedValue, _precioServicio.Get(string.Empty));
                    LimpiarControles(this);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido!");
            }
        }

        private void chkListaPrecioCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkListaPrecioCompleta.Checked)
            {
                cmbListaPrecio.Enabled = false;
                //rdbMonto.Enabled = false;
                //rdbPorcentaje.Checked = true;
            }
            else
            {
                rdbMonto.Enabled = true;
                cmbListaPrecio.Enabled = true;
            }
        }

        private IEnumerable<ListaPrecioDto> ObtenerListaDePrecios()
        {
            if (chkListaPrecioCompleta.Checked)
                return _listaPrecioServicio.Get(string.Empty);
            else
                return _listaPrecioServicio.Get(cmbListaPrecio.Text);
        }

        private void ActualizarPorRubro(long rubroSeleccionado)
        {
            if (_precioServicio.UpdatePrecios(x => x.RubroId == rubroSeleccionado,
                ObtenerListaDePrecios(),
                _monto,
                _porcentaje))
                MessageBox.Show("Actualizacion de precios completada");
            else
                MessageBox.Show(@"Hubo un problema al actualizar");

        }

        private void ActualizarPorMarca(long marcaSeleccionada)
        {
            if (_precioServicio.UpdatePrecios(x => x.MarcaId == marcaSeleccionada,
                ObtenerListaDePrecios(),
                _monto,
                _porcentaje))
                MessageBox.Show("Actualizacion de precios completada");
            else
                MessageBox.Show(@"Hubo un problema al actualizar");
        }

        private void ActualizarPorCodigos(int v1, int v2)
        {
            if (_precioServicio.UpdatePrecios(x => x.Codigo >= v1 && x.Codigo <= v2,
                ObtenerListaDePrecios(),
                _monto,
                _porcentaje))
                MessageBox.Show("Actualizacion de precios completada");
            else
                MessageBox.Show(@"Hubo un problema al actualizar");
        }

        /*====================================================================*/
        private void ActualizarTodasLasListasDeprecio(IEnumerable<PrecioDto> Precios)
        {

            foreach (var _precio in Precios)
            {
                if (_monto.HasValue)
                {
                    _precio.PrecioPublico += _monto.Value;

                }

                if (_porcentaje.HasValue)
                {
                    _precio.PrecioPublico += _precio.PrecioPublico + (_precio.PrecioPublico * _porcentaje.Value / 100);
                }

                _precioServicio.Update(_precio);
            }

            //try
            //{
            //    foreach (var listaPrecio in listalistaPrecio)
            //    {
            //        listaPrecio.PorcentajeGanancia += nudValor.Value;

            //        _listaPrecioServicio.Update(listaPrecio);
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(@"Hubo un problema al actualizar");
            //}

            //MessageBox.Show("Actualizacion de precios completada");

        }
        /*===================================================================*/
        private void ActulizarDeterminadaListaDePrecio(long selectedValue, IEnumerable<PrecioDto> Precios)
        {

            foreach (var _precio in Precios)
            {
                if (_precio.ListaPrecioId==selectedValue)
                {
                    if (_monto.HasValue)
                    {
                        _precio.PrecioPublico += _monto.Value;
                    }

                    if (_porcentaje.HasValue)
                    {
                        _precio.PrecioPublico += _precio.PrecioPublico + (_precio.PrecioPublico * _porcentaje.Value / 100);
                    }
                    _precioServicio.Update(_precio);
                }
            }


            //var listaPrecio = _listaPrecioServicio.GetById(selectedValue);

            //listaPrecio.PorcentajeGanancia += nudValor.Value;

            //try
            //{
            //    _listaPrecioServicio.Update(listaPrecio);
            //    MessageBox.Show("Actualizacion de precios completada");
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(@"Hubo un problema al actualizar");
            //}
        }
    }
}
