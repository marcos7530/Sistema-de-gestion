using Dominio.Entidades.MetaData;
using Presentacion.Core.Cliente;
using Presentacion.Core.FormaPago;
using Servicio.Interfaces.Banco;
using Servicio.Interfaces.Cheque;
using Servicio.Interfaces.Cheque.DTOs;
using Servicio.Interfaces.Persona;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Cheque
{
    using FormularioBase;
    using FormularioBase.Helpers;
    using Presentacion.Core.LookUp;
    using Servicio.Interfaces.Persona.DTOs;
    using System;
    using System.Windows.Forms;

    public partial class _00157_Abm_Cheque : FormularioAbm
    {
     

        private readonly IChequeServicio _chequeServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IBancoServicio _bancoServicio;

        long _clienteId;

        public _00157_Abm_Cheque(TipoOperacion tipoOperacion, long? entidadId)
        : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _chequeServicio = ObjectFactory.GetInstance<IChequeServicio>();
            _bancoServicio= ObjectFactory.GetInstance<IBancoServicio>();


            textBox1.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            textBox2.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            numericUpDown1.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);

            };

            textBox1.Enabled = false;

            AsignarEvento_EnterLeave(this);

            CargarDatosObligatorios();
        }

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(textBox2, "Numero De Cheque");
            AgregarControlesObligatorios(textBox2, "Cliente");
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(textBox2.Text)) return false;
            if (string.IsNullOrEmpty(textBox1.Text)) return false;

            if (cmbBanco.Items.Count <= 0) return false;

            return true;
        }

        public override void CargarDatos(long? entidadId = null)
        {
            if (entidadId.HasValue)
            {
                if (_tipoOperacion == TipoOperacion.Eliminar)
                {
                    DesactivarControles(this);
                }

                var entidad = (ChequeDto)_chequeServicio.GetById(entidadId.Value);

                if (entidad == null)
                {
                    MessageBox.Show("Ocuriro un error al obtener el registro seleciconado");
                    Close();
                }

                Poblar_ComboBox(cmbBanco, _bancoServicio.Get(string.Empty), "Descripcion", "Id");
                cmbBanco.SelectedValue = entidad.BancoId;


            }
            else
            {
                Poblar_ComboBox(cmbBanco, _bancoServicio.Get(string.Empty), "Descripcion", "Id");
               // Poblar_ComboBox(comboBox1, _clienteServicio.Get(typeof(ClienteDto),string.Empty), "Descripcion", "Id");
                textBox2.Clear();
                numericUpDown1 = null;
               

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

            _chequeServicio.Add(new ChequeDto()
            {
                ClienteId = _clienteId/*(long)comboBox1.SelectedValue*/,
                BancoId = (long)cmbBanco.SelectedValue,
                Numero = textBox2.Text,
                FechaVencimiento = dateTimePicker1.Value,
                EstaRechazado = false,
                /*============================================================*/
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
            _chequeServicio.Update(new ChequeDto()
            {
                Id = entidadId.Value,
                /*===========================================================*/
                ClienteId = _clienteId/*(long)comboBox1.SelectedValue*/,
                BancoId = (long)cmbBanco.SelectedValue,
                Numero = textBox2.Text,
                FechaVencimiento = dateTimePicker1.Value,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _chequeServicio.Delete(entidadId.Value);
        }


        private void btnBuscarBanco_Click(object sender, EventArgs e)
        {
            new _00129_Abm_Banco(TipoOperacion.Nuevo).ShowDialog();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //ESTO ES SE USA EN EL CASO DE QUE USE EL LOOKUP PARA PONER EL CLIENTE EN UN TEXTBOX

            var fLookUpCliente = ObjectFactory.GetInstance<LookUpCliente>();
            fLookUpCliente.ShowDialog();
            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                var clienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                AgregarDatosCliente(clienteSeleccionado);

                _clienteId = clienteSeleccionado.Id;

            }
        }
        private void AgregarDatosCliente(ClienteDto cliente)
        {
            textBox1.Text = cliente.ApyNom;
        }


    }
}
