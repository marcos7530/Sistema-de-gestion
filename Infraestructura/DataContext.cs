namespace Infraestructura
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Dominio.Entidades;
    //using static Aplicacion.Conexion.CadenaConexion;

    public class DataContext : DbContext
    {
        public DataContext()
            : base(Aplicacion.Conexion.CadenaConexion.ObtenerCadenaConexion)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
            

            ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = 600;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(x=>x.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

        // Mapeo de las Entidades
        public IDbSet<Persona> Personas { get; set; }        
        public IDbSet<Empleado> Empleados { get; set; }
        public IDbSet<Cliente> Clientes { get; set; }
        public IDbSet<Proveedor> Proveedores { get; set; }
        public IDbSet<CondicionIva> CondicionIvas { get; set; }
        public IDbSet<Provincia> Provincias { get; set; }
        public IDbSet<Localidad> Localidades { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Formulario> Formularios { get; set; }
        public IDbSet<Perfil> Perfiles { get; set; }
        public IDbSet<Articulo> Articulos { get; set; }
        public IDbSet<Marca> Marcas { get; set; }
        public IDbSet<Rubro> Rubros { get; set; }
        public IDbSet<Iva> Ivas { get; set; }
        public IDbSet<ListaPrecio> ListaPrecios { get; set; }
        public IDbSet<BajaArticulo> BajaArticulos { get; set; }
        public IDbSet<Comprobante> Comprobantes { get; set; }
        public IDbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public IDbSet<DetalleArticuloCompuesto> DetalleArticuloCompuestos { get; set; }
        public IDbSet<Factura> Facturas { get; set; }
        public IDbSet<MotivoBaja> MotivoBajas { get; set; }
        public IDbSet<Precio> Precios { get; set; }
        public IDbSet<Configuracion> Configuraciones { get; set; }
        public IDbSet<Compra> Compras { get; set; }
        public IDbSet<NotaCredito> NotaCreditos { get; set; }
        public IDbSet<Presupuesto> Presupuestos { get; set; }
        public IDbSet<Remito> Remitos { get; set; }
        public IDbSet<Contador> Contadores { get; set; }
        public IDbSet<Caja> Cajas { get; set; }
        public IDbSet<DetalleCaja> DetalleCajas { get; set; }
        public IDbSet<MovimientoCuentaCorriente> MovimientoCuentaCorrientes { get; set; }
        public IDbSet<FormaPagoEfectivo> FormaPagosEfectivo { get; set; }
        public IDbSet<FormaPagoCheque> FormaPagosCheque { get; set; }
        public IDbSet<FormaPagoCtaCte> FormaPagosCtaCte { get; set; }
        public IDbSet<FormaPagoTarjeta> FormaPagosTarjeta { get; set; }
        public IDbSet<Tarjeta> Tarjetas { get; set; }
        public IDbSet<Banco> Bancos { get; set; }
/*===========================================================================*/
        public IDbSet<ConceptoGasto> ConceptoGastos { get; set; }
    }
}
