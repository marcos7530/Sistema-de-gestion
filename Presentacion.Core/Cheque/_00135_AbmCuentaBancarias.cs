using System.Windows.Forms;
using Presentacion.Core.FormaPago;
using Servicio.Interfaces.Banco;
using Servicio.Interfaces.CuentaBancaria;
using Servicio.Interfaces.CuentaBancaria.DTOs;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Cheque
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using System;

    public partial class _00135_AbmCuentaBancarias : FormularioAbm
    {

        private readonly ICuentaBancariaServicio _cuentaBancariaServicio;
        private readonly IBancoServicio _bancoServicio;

        public _00135_AbmCuentaBancarias(TipoOperacion tipoOperacion, long? entidadId = null, long? entidadFiltroId = null)
            : base(tipoOperacion, entidadId,entidadFiltroId)
        {
            InitializeComponent();
           
            _bancoServicio = ObjectFactory.GetInstance<IBancoServicio>();
            _cuentaBancariaServicio= ObjectFactory.GetInstance<ICuentaBancariaServicio>();


            txtTitular.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender,args);
            };
            
            txtNumeroCuenta.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };


            AsignarEvento_EnterLeave(this);
            CargarDatosObligatorios();
            
        }

       

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(cmbBanco, "Banco");
            AgregarControlesObligatorios(txtNumeroCuenta, "Numero De Cuenta");
            AgregarControlesObligatorios(txtTitular, "Titular");
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtNumeroCuenta.Text)) return false;
            if (string.IsNullOrEmpty(txtTitular.Text)) return false;

            if (cmbBanco.Items.Count <= 0) return false;

            return true;
        }

        public override void CargarDatos(long? entidadId = null)
        {
            base.CargarDatos(entidadId);
            if (entidadId.HasValue&& entidadId.Value > 0)
            {
                var entidad = _cuentaBancariaServicio.GetById(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("No se pudieron obtener los datos.");
                }

                Poblar_ComboBox(cmbBanco,_bancoServicio.Get(string.Empty),"Descripcion", "Id");
                cmbBanco.SelectedValue = entidad.BancoId;
                txtNumeroCuenta.Text = entidad.Numero;
                txtTitular.Text = entidad.Titular;


                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }

            }
            else
            {
                Poblar_ComboBox(cmbBanco, _bancoServicio.Get(string.Empty), "Descripcion", "Id");
                txtNumeroCuenta.Clear();
                txtTitular.Clear();
            }
        }


        public override void EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }
            _cuentaBancariaServicio.Add(new CuentaBancariaDto()
            {
                BancoId = (long)cmbBanco.SelectedValue,
                Numero = txtNumeroCuenta.Text,
                Titular = txtTitular.Text,
                /*=====================================*/
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show("Por favor ingrese los campos obligatorios.", "Faltan Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            _cuentaBancariaServicio.Update(new CuentaBancariaDto()
            {
                Id = entidadId.Value,
                /*============================*/
                BancoId = (long)cmbBanco.SelectedValue,
                Numero = txtNumeroCuenta.Text,
                Titular = txtTitular.Text
            });

        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _cuentaBancariaServicio.Delete(entidadId.Value);
        }


        private void btnNuevoBanco_Click(object sender, EventArgs e)
        {
            new _00129_Abm_Banco(TipoOperacion.Nuevo).ShowDialog();
            Poblar_ComboBox(cmbBanco, _bancoServicio.Get(string.Empty), "Descripcion", "Id");

        }
    }
}
