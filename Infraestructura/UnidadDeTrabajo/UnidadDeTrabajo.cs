using System;
using System.Data.Entity.Validation;

namespace Infraestructura.UnidadDeTrabajo
{
    using Dominio.Base;
    using Dominio.Entidades;
    using Dominio.Entidades.Repositorio;
    using Dominio.Entidades.UnidadDeTrabajo;

    using Repositorio;

    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DataContext _dataContext;

        public UnidadDeTrabajo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private IRepositorio<Usuario> _usuarioRepositorio;
        public IRepositorio<Usuario> UsuarioRepositorio
        {
            get { return _usuarioRepositorio ?? (_usuarioRepositorio = new Repositorio<Usuario>(_dataContext)); }
        }

        private IRepositorio<Provincia> _provinciaRepositorio;
        public IRepositorio<Provincia> ProvinciaRepositorio
        {
            get { return _provinciaRepositorio ?? (_provinciaRepositorio = new Repositorio<Provincia>(_dataContext)); }
        }

        private IRepositorio<Localidad> _localidadRepositorio;
        public IRepositorio<Localidad> LocalidadRepositorio
        {
            get { return _localidadRepositorio ?? (_localidadRepositorio = new Repositorio<Localidad>(_dataContext)); }
        }

        private IRepositorio<CondicionIva> _condicionIvaRepositorio;
        public IRepositorio<CondicionIva> CondicionIvaRepositorio
        {
            get { return _condicionIvaRepositorio ?? (_condicionIvaRepositorio = new Repositorio<CondicionIva>(_dataContext)); }
        }

        private IRepositorioEmpleado _empleadoRepositorio;
        public IRepositorioEmpleado EmpleadoRepositorio
        {
            get { return _empleadoRepositorio ?? (_empleadoRepositorio = new RepositorioEmpleado(_dataContext)); }
        }

        private IRepositorioCliente _clienteRepositorio;
        public IRepositorioCliente ClienteRepositorio
        {
            get { return _clienteRepositorio ?? (_clienteRepositorio = new RepositorioCliente(_dataContext)); }
        }

        private IRepositorioProveedor _proveedorRepositorio;
        public IRepositorioProveedor ProveedorRepositorio
        {
            get { return _proveedorRepositorio ?? (_proveedorRepositorio = new RepositorioProveedor(_dataContext)); }
        }

        private IRepositorio<Perfil> _perfilRepositorio;
        public IRepositorio<Perfil> PerfilRepositorio
        {
            get { return _perfilRepositorio ?? (_perfilRepositorio = new Repositorio<Perfil>(_dataContext)); }
        }

        private IRepositorio<Formulario> _formularioRepositorio;
        public IRepositorio<Formulario> FormularioRepositorio
        {
            get { return _formularioRepositorio ?? (_formularioRepositorio = new Repositorio<Formulario>(_dataContext)); }
        }

        private IRepositorio<Articulo> _articuloRepositorio;
        public IRepositorio<Articulo> ArticuloRepositorio
        {
            get { return _articuloRepositorio ?? (_articuloRepositorio = new Repositorio<Articulo>(_dataContext)); }
        }

        private IRepositorio<Iva> _ivaRepositorio;
        public IRepositorio<Iva> IvaRepositorio
        {
            get { return _ivaRepositorio ?? (_ivaRepositorio = new Repositorio<Iva>(_dataContext)); }
        }

        private IRepositorio<Marca> _marcaRepositorio;
        public IRepositorio<Marca> MarcaRepositorio
        {
            get { return _marcaRepositorio ?? (_marcaRepositorio = new Repositorio<Marca>(_dataContext)); }
        }

        private IRepositorio<UnidadMedida> _unidadMedidaRepositorio;
        public IRepositorio<UnidadMedida> UnidadMedidaRepositorio
        {
            get { return _unidadMedidaRepositorio ?? (_unidadMedidaRepositorio = new Repositorio<UnidadMedida>(_dataContext)); }
        }

        private IRepositorio<Rubro> _rubroRepositorio;
        public IRepositorio<Rubro> RubroRepositorio
        {
            get { return _rubroRepositorio ?? (_rubroRepositorio = new Repositorio<Rubro>(_dataContext)); }
        }

        private IRepositorio<ListaPrecio> _listaPrecioRepositorio;
        public IRepositorio<ListaPrecio> ListaPrecioRepositorio
        {
            get { return _listaPrecioRepositorio ?? (_listaPrecioRepositorio = new Repositorio<ListaPrecio>(_dataContext)); }
        }

        private IRepositorio<BajaArticulo> _bajaArticuloRepositorio;
        public IRepositorio<BajaArticulo> BajaArticuloRepositorio
        {
            get { return _bajaArticuloRepositorio ?? (_bajaArticuloRepositorio = new Repositorio<BajaArticulo>(_dataContext));  }
        }        

        private IRepositorio<DetalleComprobante> _detalleComprobanteRepositorio;
        public IRepositorio<DetalleComprobante> DetalleComprobanteRepositorio
        {
            get { return _detalleComprobanteRepositorio ?? (_detalleComprobanteRepositorio = new Repositorio<DetalleComprobante>(_dataContext)); }
        }

        private IRepositorio<DetalleArticuloCompuesto> _detalleArticuloCompuestoRepositorio;
        public IRepositorio<DetalleArticuloCompuesto> DetalleArticuloCompuestoRepositorio
        {
            get { return _detalleArticuloCompuestoRepositorio ?? (_detalleArticuloCompuestoRepositorio = new Repositorio<DetalleArticuloCompuesto>(_dataContext)); }
        }

        private IRepositorioFactura _facturaRepositorio;
        public IRepositorioFactura FacturaRepositorio
        {
            get { return _facturaRepositorio ?? (_facturaRepositorio = new RepositorioFactura(_dataContext)); }
        }

        private IRepositorio<MotivoBaja> _motivoBajaRepositorio;
        public IRepositorio<MotivoBaja> MotivoBajaRepositorio
        {
            get { return _motivoBajaRepositorio ?? (_motivoBajaRepositorio = new Repositorio<MotivoBaja>(_dataContext)); }
        }

        private IRepositorio<Precio> _precioRepositorio;
        public IRepositorio<Precio> PrecioRepositorio
        {
            get { return _precioRepositorio ?? (_precioRepositorio = new Repositorio<Precio>(_dataContext)); }
        }

        /*private IRepositorioNotaCredito _notaCreditoRepositorio;
        public IRepositorioNotaCredito NotaCreditoRepositorio
        {
            get { return _notaCreditoRepositorio ?? (_notaCreditoRepositorio = new RepositorioNotaCredito(_dataContext)); }
        }

        private IRepositorioPresupuesto _presupuestoRepositorio;
        public IRepositorioPresupuesto PresupuestoRepositorio
        {
            get { return _presupuestoRepositorio ?? (_presupuestoRepositorio = new RepositorioPresupuesto(_dataContext)); }
        }

        private IRepositorioRemito _remitoRepositorio;
        public IRepositorioRemito RemitoRepositorio
        {
            get { return _remitoRepositorio ?? (_remitoRepositorio = new RepositorioRemito(_dataContext)); }
        }

        private IRepositorioCompra _compraRepositorio;
        public IRepositorioCompra CompraRepositorio
        {
            get { return _compraRepositorio ?? (_compraRepositorio = new RepositorioCompra(_dataContext)); }
        }*/

        private IRepositorio<Configuracion> _configuracionRepositorio;
        public IRepositorio<Configuracion> ConfiguracionRepositorio
        {
            get { return _configuracionRepositorio ?? (_configuracionRepositorio = new Repositorio<Configuracion>(_dataContext)); }
        }

        private IRepositorio<Contador> _contadorRepositorio;
        public IRepositorio<Contador> ContadorRepositorio
        {
            get { return _contadorRepositorio ?? (_contadorRepositorio = new Repositorio<Contador>(_dataContext)); }
        }

        private IRepositorio<Caja> _cajaRepositorio;
        public IRepositorio<Caja> CajaRepositorio
        {
            get { return _cajaRepositorio ?? (_cajaRepositorio = new Repositorio<Caja>(_dataContext)); }
        }

        private IRepositorio<DetalleCaja> _detalleCajaRepositorio;
        public IRepositorio<DetalleCaja> DetalleCajaRepositorio
        {
            get { return _detalleCajaRepositorio ?? (_detalleCajaRepositorio = new Repositorio<DetalleCaja>(_dataContext)); }
        }
               
        private IRepositorioFormaPagoCheque _formaPagoChequeRepositorio;
        public IRepositorioFormaPagoCheque FormaPagoChequeRepositorio
        {
            get { return _formaPagoChequeRepositorio ?? (_formaPagoChequeRepositorio = new RepositorioCheque(_dataContext)); }
        }

        private IRepositorioFormaPagoCtaCte _formaPagoCtaCteRepositorio;
        public IRepositorioFormaPagoCtaCte FormaPagoCtaCteRepositorio
        {
            get { return _formaPagoCtaCteRepositorio ?? (_formaPagoCtaCteRepositorio = new RepositorioCtaCte(_dataContext)); }
        }

        private IRepositorioFormaPagoTarjeta _formaPagoTarjetaRepositorio;
        public IRepositorioFormaPagoTarjeta FormaPagoTarjetaRepositorio
        {
            get { return _formaPagoTarjetaRepositorio ?? (_formaPagoTarjetaRepositorio = new RepositorioTarjeta(_dataContext)); }
        }

        IRepositorio<MovimientoCuentaCorriente> _movimientoCtaCteRepositorio;
        public IRepositorio<MovimientoCuentaCorriente> MovimientoCtaCteRepositorio
        {
            get { return _movimientoCtaCteRepositorio ?? (_movimientoCtaCteRepositorio = new Repositorio<MovimientoCuentaCorriente>(_dataContext)); }
        }

        IRepositorio<Movimiento> _movimientoRepositorio;
        public IRepositorio<Movimiento> MovimientoRepositorio
        {
            get { return _movimientoRepositorio ?? (_movimientoRepositorio = new Repositorio<Movimiento>(_dataContext)); }
        }

        private IRepositorioFormaPagoEfectivo _formaPagoEfectivoRepositorio;
        public IRepositorioFormaPagoEfectivo FormaPagoEfectivoRepositorio
        {
            get { return _formaPagoEfectivoRepositorio ?? (_formaPagoEfectivoRepositorio = new RepositorioEfectivo(_dataContext)); }
        }

        private IRepositorio<Tarjeta> _tarjetaRepositorio;
        public IRepositorio<Tarjeta> TarjetaRepositorio
        {
            get { return _tarjetaRepositorio ?? (_tarjetaRepositorio = new Repositorio<Tarjeta>(_dataContext)); }
        }

        private IRepositorio<Banco> _bancoRepositorio;
        public IRepositorio<Banco> BancoRepositorio
        {
            get { return _bancoRepositorio ?? (_bancoRepositorio = new Repositorio<Banco>(_dataContext)); }
        }

        private IRepositorio<MovimientoCuentaCorriente> _movimientoCuentaCorrienteRepositorio;
        public IRepositorio<MovimientoCuentaCorriente> MovimientoCuentaCorrienteRepositorio
        {
            get { return _movimientoCuentaCorrienteRepositorio ?? (_movimientoCuentaCorrienteRepositorio = new Repositorio<MovimientoCuentaCorriente>(_dataContext)); }
        }

        /*======================================================================================================*/
        private IRepositorio<ConceptoGasto> _conceptoGastoRepositorio;
        public IRepositorio<ConceptoGasto> ConceptoGastoRepositorio
        {
            get { return _conceptoGastoRepositorio ?? (_conceptoGastoRepositorio = new Repositorio<ConceptoGasto>(_dataContext)); }
        }


        private IRepositorio<Gasto> _gastoRepositorio;
        public IRepositorio<Gasto> GastoRepositorio
        {
            get { return _gastoRepositorio ?? (_gastoRepositorio = new Repositorio<Gasto>(_dataContext)); }
        }


        private IRepositorio<Cheque> _chequeRepositorio;
        public IRepositorio<Cheque> ChequeRepositorio
        {
            get { return _chequeRepositorio ?? (_chequeRepositorio = new Repositorio<Cheque>(_dataContext)); }
        }

        private IRepositorio<CuentaBancaria> _cuentaBancariaRepositorio;
        public IRepositorio<CuentaBancaria> CuentaBancariaRepositorio
        {
            get { return _cuentaBancariaRepositorio ?? (_cuentaBancariaRepositorio = new Repositorio<CuentaBancaria>(_dataContext)); }
        }

        private IRepositorio<DepositoCheque> _depositoChequeRepositorio;
        public IRepositorio<DepositoCheque> DepositoChequeRepositorio
        {
            get { return _depositoChequeRepositorio ?? (_depositoChequeRepositorio = new Repositorio<DepositoCheque>(_dataContext)); }
        }


        public void Commit()
        {
            _dataContext.SaveChanges();


            //Esto de abajo lo puse para detectar un error que no encontraba jeje

            //try
            //{
            //    _dataContext.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
        }

        public void Disposed()
        {
            _dataContext.Dispose();
        }
    }
}
