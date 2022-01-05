using System.Runtime.Remoting.Contexts;
using Dominio.Entidades;
using Dominio.Entidades.MetaData;
using Servicio.Implementacion.Cheque;
using Servicio.Implementacion.ConceptoGasto;
using Servicio.Implementacion.CuentaBancaria;
using Servicio.Implementacion.DepositoCheqque;
using Servicio.Implementacion.Gasto;
using Servicio.Interfaces.Cheque;
using Servicio.Interfaces.ConceptoGasto;
using Servicio.Interfaces.CuentaBancaria;
using Servicio.Interfaces.DepositoCheque;
using Servicio.Interfaces.Gastos;

namespace Aplicacion.IoC
{
    using Infraestructura;
    using System.Data.Entity;
    using Servicio.Implementacion.Provincia;
    using Servicio.Interfaces.Provincia;
    using Servicio.Implementacion.CondicionIva;
    using Servicio.Implementacion.Localidad;
    using Servicio.Implementacion.Persona;
    using Servicio.Interfaces.CondicionIva;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Persona;
    using StructureMap;
    using Dominio.Base;
    using Infraestructura.Repositorio;
    using Dominio.Entidades.Repositorio;
    using Servicio.Implementacion.Formulario;
    using Servicio.Implementacion.Perfil;
    using Servicio.Implementacion.PerfilFormulario;
    using Servicio.Implementacion.PerfilUsuario;
    using Servicio.Implementacion.Seguridad;
    using Servicio.Implementacion.Usuario;
    using Servicio.Interfaces.Formulario;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.PerfilFormulario;
    using Servicio.Interfaces.PerfilUsuario;
    using Servicio.Interfaces.Seguridad;
    using Servicio.Interfaces.Usuario;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Infraestructura.UnidadDeTrabajo;
    using Servicio.Interfaces.Marca;
    using Servicio.Implementacion.Marca;
    using Servicio.Interfaces.Rubro;
    using Servicio.Implementacion.Rubro;
    using Servicio.Interfaces.Iva;
    using Servicio.Implementacion.Iva;
    using Servicio.Interfaces.ListaPrecio;
    using Servicio.Implementacion.ListaPrecio;
    using Servicio.Interfaces.UnidadMedida;
    using Servicio.Implementacion.UnidadMedida;
    using Servicio.Interfaces.Articulo;
    using Servicio.Implementacion.Articulo;
    using Servicio.Implementacion.BajaArticulo;
    using Servicio.Interfaces.BajaArticulo;
    using Servicio.Implementacion.MotivoBaja;
    using Servicio.Interfaces.MotivoBaja;
    using Servicio.Interfaces.DetalleArticuloCompuesto;
    using Servicio.Implementacion.DetalleArticuloCompuesto;
    using Servicio.Interfaces.Precio;
    using Servicio.Implementacion.Precio;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Implementacion.Configuracion;
    using Servicio.Interfaces.Comprobante;
    using Servicio.Implementacion.Comprobante;
    using Servicio.Interfaces.DetalleComprobante;
    using System;
    using Servicio.Implementacion.DetalleComprobante;
    using Servicio.Interfaces.Contador;
    using Servicio.Implementacion.Contador;
    using Servicio.Interfaces.Caja;
    using Servicio.Implementacion.Caja;
    using Servicio.Interfaces.DetalleCaja;
    using Servicio.Implementacion.DetalleCaja;
    using Servicio.Interfaces.FormaPago;
    using Servicio.Implementacion.FormaPago;
    using Servicio.Interfaces.Tarjeta;
    using Servicio.Implementacion.Tarjeta;
    using Servicio.Implementacion.Banco;
    using Servicio.Interfaces.Banco;

    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof(IRepositorio<>));
                    scan.Assembly(GetType().Assembly);
                });

                x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));
                x.ForSingletonOf<DbContext>().HybridHttpOrThreadLocalScoped();

                x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                x.For<IConfiguracionServicio>().Use<ConfiguracionServicio>();

                x.For<IRepositorioEmpleado>().Use<RepositorioEmpleado>();
                x.For<IRepositorioCliente>().Use<RepositorioCliente>();
                x.For<IRepositorioProveedor>().Use<RepositorioProveedor>();

                x.For<IRepositorioFormaPagoEfectivo>().Use<RepositorioEfectivo>();
                x.For<IRepositorioFormaPagoCheque>().Use<RepositorioCheque>();
                x.For<IRepositorioFormaPagoTarjeta>().Use<RepositorioTarjeta>();
                x.For<IRepositorioFormaPagoCtaCte>().Use<RepositorioCtaCte>();

                x.For<IRepositorioFactura>().Use<RepositorioFactura>();
                

                // ======================================================== //

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();
                x.For<ILocalidadServicio>().Use<LocalidadServicio>();
                x.For<ICondicionIvaServicio>().Use<CondicionIvaServicio>();

                // ======================================================== //

                x.For<IPersonaServicio>().Use<PersonaServicio>();
                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();                
                x.For<IProveedorServicio>().Use<ProveedorServicio>();

                x.For<IClienteServicio>().Use<ClienteServicio>();
                //x.For<IMovimientoCtaCteServicio>().Use<MovimientoCtaCteServicio>();

                // ======================================================== //

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();
                x.For<ISeguridadServicio>().Use<SeguridadServicio>();
                x.For<IFormularioServicio>().Use<FormularioServicio>();
                x.For<IPerfilServicio>().Use<PerfilServicio>();
                x.For<IPerfilFormularioServicio>().Use<PerfilFormularioServicio>();
                x.For<IPerfilUsuarioServicio>().Use<PerfilUsuarioServicio>();
                x.For<IMarcaServicio>().Use<MarcaServicio>();
                x.For<IRubroServicio>().Use<RubroServicio>();
                x.For<IIvaServicio>().Use<IvaServicio>();                
                x.For<IUnidadMedidaServicio>().Use<UnidadMedidaServicio>();
                x.For<IBajaArticuloServicio>().Use<BajaArticuloServicio>();
                x.For<IMotivoBajaServicio>().Use<MotivoBajaServicio>();
                x.For<IArticuloServicio>().Use<ArticuloServicio>();
                x.For<IListaPrecioServicio>().Use<ListaPrecioServicio>();
                x.For<IDetalleArticuloCompuestoServicio>().Use<DetalleArticuloCompuestoServicio>();
                x.For<IPrecioServicio>().Use<PrecioServicio>();
                x.For<IComprobanteServicio>().Use<ComprobanteServicio>();
                x.For<IDetalleComprobanteServicio>().Use<DetalleComprobanteServicio>();
                x.For<IFacturaServicio>().Use<FacturaServicio>();
                x.For<IContadorServicio>().Use<ContadorServicio>();         
                x.For<ICajaServicio>().Use<CajaServicio>();
                x.For<IDetalleCajaServicio>().Use<DetalleCajaServicio>();           
                x.For<IFormaPagoEfectivoServicio>().Use<FormaPagoEfectivoServicio>();
                x.For<IFormaPagoTarjetaServicio>().Use<FormaPagoTarjetaServicio>();
                x.For<IFormaPagoCtaCteServicio>().Use<FormaPagoCtaCteServicio>();
                x.For<IFormaPagoChequeServicio>().Use<FormaPagoChequeServicio>();
                x.For<ITarjetaServicio>().Use<TarjetaServicio>();
                x.For<IBancoServicio>().Use<BancoServicio>();
                /*=================================================================*/
                x.For<IConceptoGastoServicio>().Use<ConceptoGastoServicio>();
                x.For<IGastoServicio>().Use<GastoServicio>();
                x.For<IChequeServicio>().Use<ChequeServicio>();
                x.For<ICuentaBancariaServicio>().Use<CuentaBancariaServicio>();
                x.For<IDepositoChequeServicio>().Use<DepositoChequeServicio>();
                x.For<ICompraServicio>().Use<CompraServicio>();


                //Ejemplo de como declarar las propiedades en StructureMap
                //x.SetAllProperties(p => p.OfType<Implementacion>());
            });
        }

    }
}
