namespace Dominio.Entidades.UnidadDeTrabajo
{
    using Dominio.Base;
    using Dominio.Entidades.Repositorio;

    public interface IUnidadDeTrabajo
    {
        void Commit();
        void Disposed();

        IRepositorio<Provincia> ProvinciaRepositorio { get; }

        IRepositorio<Localidad> LocalidadRepositorio { get; }

        IRepositorio<CondicionIva> CondicionIvaRepositorio { get; }

        IRepositorioEmpleado EmpleadoRepositorio { get; }

        IRepositorioCliente ClienteRepositorio { get; }

        IRepositorioProveedor ProveedorRepositorio { get; }

        IRepositorio<Perfil> PerfilRepositorio { get; }

        IRepositorio<Formulario> FormularioRepositorio { get; }

        IRepositorio<Usuario> UsuarioRepositorio { get; }

        IRepositorio<Articulo> ArticuloRepositorio { get; }

        IRepositorio<Iva> IvaRepositorio { get;  }

        IRepositorio<Marca> MarcaRepositorio { get; }

        IRepositorio<UnidadMedida> UnidadMedidaRepositorio { get; }

        IRepositorio<Rubro> RubroRepositorio { get; }

        IRepositorio<ListaPrecio> ListaPrecioRepositorio { get; }

        IRepositorio<BajaArticulo> BajaArticuloRepositorio { get; }
        
        IRepositorio<DetalleComprobante> DetalleComprobanteRepositorio { get; }

        IRepositorio<DetalleArticuloCompuesto> DetalleArticuloCompuestoRepositorio { get; }

        IRepositorioFactura FacturaRepositorio { get; }

        //IRepositorioNotaCredito NotaCreditoRepositorio { get; }

        //IRepositorioPresupuesto PresupuestoRepositorio { get; }

        //IRepositorioRemito RemitoRepositorio { get; }

        IRepositorio<MotivoBaja> MotivoBajaRepositorio { get; }

        IRepositorio<Precio> PrecioRepositorio { get; }

        //IRepositorioCompra CompraRepositorio { get; }

        IRepositorio<Configuracion> ConfiguracionRepositorio { get; }

        IRepositorio<Contador> ContadorRepositorio { get; }

        IRepositorio<Caja> CajaRepositorio { get; }

        IRepositorio<DetalleCaja> DetalleCajaRepositorio { get; }

        IRepositorioFormaPagoEfectivo FormaPagoEfectivoRepositorio { get; } //verificar

        IRepositorioFormaPagoCheque FormaPagoChequeRepositorio { get; }

        IRepositorioFormaPagoCtaCte FormaPagoCtaCteRepositorio { get; }

        IRepositorioFormaPagoTarjeta FormaPagoTarjetaRepositorio { get; }

        IRepositorio<MovimientoCuentaCorriente> MovimientoCtaCteRepositorio { get; }

        IRepositorio<Movimiento> MovimientoRepositorio { get; }

        IRepositorio<Tarjeta> TarjetaRepositorio { get; }

        IRepositorio<Banco> BancoRepositorio { get; }
        
        IRepositorio<MovimientoCuentaCorriente> MovimientoCuentaCorrienteRepositorio { get; }

        /*=======================================================================0*/

        IRepositorio<ConceptoGasto> ConceptoGastoRepositorio { get; }

        IRepositorio<Gasto> GastoRepositorio { get; }

        IRepositorio<Cheque> ChequeRepositorio { get; }

        IRepositorio<CuentaBancaria> CuentaBancariaRepositorio { get; }

        IRepositorio<DepositoCheque> DepositoChequeRepositorio { get; }



    }
}
