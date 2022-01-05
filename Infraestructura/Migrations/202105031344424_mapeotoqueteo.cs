namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapeotoqueteo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarcaId = c.Long(nullable: false),
                        RubroId = c.Long(nullable: false),
                        UnidadMedidaId = c.Long(nullable: false),
                        IvaId = c.Long(nullable: false),
                        ProveedorId = c.Long(nullable: false),
                        Codigo = c.Long(nullable: false),
                        CodigoBarra = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Abreviatura = c.String(maxLength: 8000, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Detalle = c.String(maxLength: 4000, unicode: false),
                        Ubicacion = c.String(maxLength: 400, unicode: false),
                        Foto = c.Binary(nullable: false),
                        ActivarLimiteVenta = c.Boolean(nullable: false),
                        LimiteVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivarHoraVenta = c.Boolean(nullable: false),
                        HoraLimiteVentaInicio = c.DateTime(nullable: false),
                        HoraLimiteVentaFin = c.DateTime(nullable: false),
                        PermiteStockNegativo = c.Boolean(nullable: false),
                        DescuentaStock = c.Boolean(nullable: false),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoArticulo = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ivas", t => t.IvaId)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .ForeignKey("dbo.Persona_Proveedor", t => t.ProveedorId)
                .ForeignKey("dbo.Rubros", t => t.RubroId)
                .ForeignKey("dbo.UnidadMedidas", t => t.UnidadMedidaId)
                .Index(t => t.MarcaId)
                .Index(t => t.RubroId)
                .Index(t => t.UnidadMedidaId)
                .Index(t => t.IvaId)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.BajaArticulos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloId = c.Long(nullable: false),
                        MotivoBajaId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Observacion = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.MotivoBajas", t => t.MotivoBajaId)
                .Index(t => t.ArticuloId)
                .Index(t => t.MotivoBajaId);
            
            CreateTable(
                "dbo.MotivoBajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleArticuloCompuestos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloPadreId = c.Long(nullable: false),
                        ArticuloHijoId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloHijoId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloPadreId)
                .Index(t => t.ArticuloPadreId)
                .Index(t => t.ArticuloHijoId);
            
            CreateTable(
                "dbo.DetalleComprobantes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Comprobantes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Numero = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva105 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoComprobante = c.Int(nullable: false),
                        EstadoComprobante = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ClienteId = c.Long(),
                        ProveedorId = c.Long(),
                        FechaEntrega = c.DateTime(),
                        Iva27 = c.Decimal(precision: 18, scale: 2),
                        PrecepcionTemp = c.Decimal(precision: 18, scale: 2),
                        PrecepcionPyP = c.Decimal(precision: 18, scale: 2),
                        PrecepcionIva = c.Decimal(precision: 18, scale: 2),
                        PrecepcionIB = c.Decimal(precision: 18, scale: 2),
                        ComprobanteId = c.Long(),
                        ClienteId1 = c.Long(),
                        ClienteId2 = c.Long(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .ForeignKey("dbo.Persona_Proveedor", t => t.ProveedorId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId1)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId2)
                .Index(t => t.EmpleadoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId)
                .Index(t => t.ProveedorId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ClienteId1)
                .Index(t => t.ClienteId2);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalidadId = c.Long(nullable: false),
                        Telefono = c.String(maxLength: 25, unicode: false),
                        Celular = c.String(maxLength: 25, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Apellido = c.String(maxLength: 250, unicode: false),
                        Nombre = c.String(maxLength: 250, unicode: false),
                        Dni = c.String(maxLength: 9, unicode: false),
                        Cuil = c.String(maxLength: 13, unicode: false),
                        FechaNacimiento = c.DateTime(),
                        Foto = c.Binary(),
                        RazonSocial = c.String(maxLength: 250, unicode: false),
                        CUIT = c.String(maxLength: 13, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinciaId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Cheques",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        EstaRechazado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancos", t => t.BancoId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.Bancos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuentaBancarias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Titular = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancos", t => t.BancoId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.DepositoCheques",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChequeId = c.Long(nullable: false),
                        CuentaBancariaId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cheques", t => t.ChequeId)
                .ForeignKey("dbo.CuentaBancarias", t => t.CuentaBancariaId)
                .Index(t => t.ChequeId)
                .Index(t => t.CuentaBancariaId);
            
            CreateTable(
                "dbo.FormaPagos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ChequeId = c.Long(),
                        ClienteId = c.Long(),
                        ClienteId1 = c.Long(),
                        TarjetaId = c.Long(),
                        NumeroTarjeta = c.String(maxLength: 100, unicode: false),
                        CuponPago = c.String(maxLength: 100, unicode: false),
                        CantidadCuotas = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cheques", t => t.ChequeId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId1)
                .ForeignKey("dbo.Tarjetas", t => t.TarjetaId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ChequeId)
                .Index(t => t.ClienteId)
                .Index(t => t.ClienteId1)
                .Index(t => t.TarjetaId);
            
            CreateTable(
                "dbo.CondicionIva",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        TipoComprobante = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovimientoCuentaCorrientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        TipoMovimiento = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaBloqueado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Cajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioAperturaId = c.Long(nullable: false),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaApertura = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(),
                        UsuarioCierreId = c.Long(),
                        MontoCierre = c.Decimal(precision: 18, scale: 2),
                        TotalVentaEfectivo = c.Decimal(precision: 18, scale: 2),
                        TotalCobranzaEfectivo = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaCompras = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaGastos = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaNotaCreditos = c.Decimal(precision: 18, scale: 2),
                        TotalTarjetaEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalChequeEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalCuentaCorrienteEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalTarjetaSalida = c.Decimal(precision: 18, scale: 2),
                        TotalChequeSalida = c.Decimal(precision: 18, scale: 2),
                        TotalCuentaCorrienteSalida = c.Decimal(precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioAperturaId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioCierreId)
                .Index(t => t.UsuarioAperturaId)
                .Index(t => t.UsuarioCierreId);
            
            CreateTable(
                "dbo.DetalleCajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId)
                .Index(t => t.CajaId);
            
            CreateTable(
                "dbo.Movimientos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 4000, unicode: false),
                        TipoMovimiento = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.CajaId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formularios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        NombreCompleto = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ivas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Porcentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ListaPrecioId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioPublico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaActualizacion = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.ListaPrecios", t => t.ListaPrecioId)
                .Index(t => t.ListaPrecioId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.ListaPrecios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        PorcentajeGanancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NecesitaAutorizacion = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configuraciones",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalidadId = c.Long(nullable: false),
                        ProvinciaId = c.Long(nullable: false),
                        RazonSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        Cuit = c.String(nullable: false, maxLength: 15, unicode: false),
                        Telefono = c.String(maxLength: 35, unicode: false),
                        Celular = c.String(maxLength: 35, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        FacturaDescuentaStock = c.Boolean(nullable: false),
                        PresupuestoDescuentaStock = c.Boolean(nullable: false),
                        RemitoDescuentaStock = c.Boolean(nullable: false),
                        ActualizaCostoDesdeCompra = c.Boolean(nullable: false),
                        ModificaPrecioVentaDesdeCompra = c.Boolean(nullable: false),
                        TipoPagoCompraPorDefecto = c.Int(nullable: false),
                        ObservacionEnPieFactura = c.String(nullable: false, maxLength: 400, unicode: false),
                        UnificarRenglonesIngresarMismoProducto = c.Boolean(nullable: false),
                        ListaPrecioPorDefectoVentaId = c.Long(nullable: false),
                        IngresoManualCajaInicial = c.Boolean(nullable: false),
                        CajaSeparada = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListaPrecios", t => t.ListaPrecioPorDefectoVentaId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId)
                .Index(t => t.LocalidadId)
                .Index(t => t.ProvinciaId)
                .Index(t => t.ListaPrecioPorDefectoVentaId);
            
            CreateTable(
                "dbo.Rubros",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contadores",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TipoComprobante = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormularioPerfil",
                c => new
                    {
                        Formulario_Id = c.Long(nullable: false),
                        Perfil_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Formulario_Id, t.Perfil_Id })
                .ForeignKey("dbo.Formularios", t => t.Formulario_Id)
                .ForeignKey("dbo.Perfiles", t => t.Perfil_Id)
                .Index(t => t.Formulario_Id)
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        Perfil_Id = c.Long(nullable: false),
                        Usuario_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Usuario_Id })
                .ForeignKey("dbo.Perfiles", t => t.Perfil_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Persona_Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                        ActivarCtaCte = c.Boolean(nullable: false),
                        TieneLimiteCompra = c.Boolean(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .Index(t => t.Id)
                .Index(t => t.CondicionIvaId);
            
            CreateTable(
                "dbo.Persona_Empleado",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Legajo = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Persona_Proveedor",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                        CodigoProveedor = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .Index(t => t.Id)
                .Index(t => t.CondicionIvaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persona_Proveedor", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Persona_Proveedor", "Id", "dbo.Persona");
            DropForeignKey("dbo.Persona_Empleado", "Id", "dbo.Persona");
            DropForeignKey("dbo.Persona_Cliente", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Persona_Cliente", "Id", "dbo.Persona");
            DropForeignKey("dbo.Articulos", "UnidadMedidaId", "dbo.UnidadMedidas");
            DropForeignKey("dbo.Articulos", "RubroId", "dbo.Rubros");
            DropForeignKey("dbo.Articulos", "ProveedorId", "dbo.Persona_Proveedor");
            DropForeignKey("dbo.Precios", "ListaPrecioId", "dbo.ListaPrecios");
            DropForeignKey("dbo.Configuraciones", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Configuraciones", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Configuraciones", "ListaPrecioPorDefectoVentaId", "dbo.ListaPrecios");
            DropForeignKey("dbo.Precios", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.Articulos", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Articulos", "IvaId", "dbo.Ivas");
            DropForeignKey("dbo.DetalleComprobantes", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.Comprobantes", "ClienteId2", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobantes", "ClienteId1", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobantes", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.Comprobantes", "ProveedorId", "dbo.Persona_Proveedor");
            DropForeignKey("dbo.Comprobantes", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.Localidad", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.FormaPagos", "TarjetaId", "dbo.Tarjetas");
            DropForeignKey("dbo.FormaPagos", "ClienteId1", "dbo.Persona_Cliente");
            DropForeignKey("dbo.FormaPagos", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.FormaPagos", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.Comprobantes", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.PerfilUsuario", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PerfilUsuario", "Perfil_Id", "dbo.Perfiles");
            DropForeignKey("dbo.FormularioPerfil", "Perfil_Id", "dbo.Perfiles");
            DropForeignKey("dbo.FormularioPerfil", "Formulario_Id", "dbo.Formularios");
            DropForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.MovimientoCuentaCorrientes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Comprobantes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Cajas", "UsuarioCierreId", "dbo.Usuarios");
            DropForeignKey("dbo.Cajas", "UsuarioAperturaId", "dbo.Usuarios");
            DropForeignKey("dbo.Movimientos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Movimientos", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.Movimientos", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.DetalleCajas", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.MovimientoCuentaCorrientes", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.MovimientoCuentaCorrientes", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.FormaPagos", "ChequeId", "dbo.Cheques");
            DropForeignKey("dbo.Cheques", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.DepositoCheques", "CuentaBancariaId", "dbo.CuentaBancarias");
            DropForeignKey("dbo.DepositoCheques", "ChequeId", "dbo.Cheques");
            DropForeignKey("dbo.CuentaBancarias", "BancoId", "dbo.Bancos");
            DropForeignKey("dbo.Cheques", "BancoId", "dbo.Bancos");
            DropForeignKey("dbo.Persona", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.DetalleComprobantes", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.DetalleArticuloCompuestos", "ArticuloPadreId", "dbo.Articulos");
            DropForeignKey("dbo.DetalleArticuloCompuestos", "ArticuloHijoId", "dbo.Articulos");
            DropForeignKey("dbo.BajaArticulos", "MotivoBajaId", "dbo.MotivoBajas");
            DropForeignKey("dbo.BajaArticulos", "ArticuloId", "dbo.Articulos");
            DropIndex("dbo.Persona_Proveedor", new[] { "CondicionIvaId" });
            DropIndex("dbo.Persona_Proveedor", new[] { "Id" });
            DropIndex("dbo.Persona_Empleado", new[] { "Id" });
            DropIndex("dbo.Persona_Cliente", new[] { "CondicionIvaId" });
            DropIndex("dbo.Persona_Cliente", new[] { "Id" });
            DropIndex("dbo.PerfilUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.PerfilUsuario", new[] { "Perfil_Id" });
            DropIndex("dbo.FormularioPerfil", new[] { "Perfil_Id" });
            DropIndex("dbo.FormularioPerfil", new[] { "Formulario_Id" });
            DropIndex("dbo.Configuraciones", new[] { "ListaPrecioPorDefectoVentaId" });
            DropIndex("dbo.Configuraciones", new[] { "ProvinciaId" });
            DropIndex("dbo.Configuraciones", new[] { "LocalidadId" });
            DropIndex("dbo.Precios", new[] { "ArticuloId" });
            DropIndex("dbo.Precios", new[] { "ListaPrecioId" });
            DropIndex("dbo.Movimientos", new[] { "UsuarioId" });
            DropIndex("dbo.Movimientos", new[] { "ComprobanteId" });
            DropIndex("dbo.Movimientos", new[] { "CajaId" });
            DropIndex("dbo.DetalleCajas", new[] { "CajaId" });
            DropIndex("dbo.Cajas", new[] { "UsuarioCierreId" });
            DropIndex("dbo.Cajas", new[] { "UsuarioAperturaId" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoId" });
            DropIndex("dbo.MovimientoCuentaCorrientes", new[] { "ClienteId" });
            DropIndex("dbo.MovimientoCuentaCorrientes", new[] { "UsuarioId" });
            DropIndex("dbo.MovimientoCuentaCorrientes", new[] { "ComprobanteId" });
            DropIndex("dbo.FormaPagos", new[] { "TarjetaId" });
            DropIndex("dbo.FormaPagos", new[] { "ClienteId1" });
            DropIndex("dbo.FormaPagos", new[] { "ClienteId" });
            DropIndex("dbo.FormaPagos", new[] { "ChequeId" });
            DropIndex("dbo.FormaPagos", new[] { "ComprobanteId" });
            DropIndex("dbo.DepositoCheques", new[] { "CuentaBancariaId" });
            DropIndex("dbo.DepositoCheques", new[] { "ChequeId" });
            DropIndex("dbo.CuentaBancarias", new[] { "BancoId" });
            DropIndex("dbo.Cheques", new[] { "BancoId" });
            DropIndex("dbo.Cheques", new[] { "ClienteId" });
            DropIndex("dbo.Localidad", new[] { "ProvinciaId" });
            DropIndex("dbo.Persona", new[] { "LocalidadId" });
            DropIndex("dbo.Comprobantes", new[] { "ClienteId2" });
            DropIndex("dbo.Comprobantes", new[] { "ClienteId1" });
            DropIndex("dbo.Comprobantes", new[] { "ComprobanteId" });
            DropIndex("dbo.Comprobantes", new[] { "ProveedorId" });
            DropIndex("dbo.Comprobantes", new[] { "ClienteId" });
            DropIndex("dbo.Comprobantes", new[] { "UsuarioId" });
            DropIndex("dbo.Comprobantes", new[] { "EmpleadoId" });
            DropIndex("dbo.DetalleComprobantes", new[] { "ArticuloId" });
            DropIndex("dbo.DetalleComprobantes", new[] { "ComprobanteId" });
            DropIndex("dbo.DetalleArticuloCompuestos", new[] { "ArticuloHijoId" });
            DropIndex("dbo.DetalleArticuloCompuestos", new[] { "ArticuloPadreId" });
            DropIndex("dbo.BajaArticulos", new[] { "MotivoBajaId" });
            DropIndex("dbo.BajaArticulos", new[] { "ArticuloId" });
            DropIndex("dbo.Articulos", new[] { "ProveedorId" });
            DropIndex("dbo.Articulos", new[] { "IvaId" });
            DropIndex("dbo.Articulos", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Articulos", new[] { "RubroId" });
            DropIndex("dbo.Articulos", new[] { "MarcaId" });
            DropTable("dbo.Persona_Proveedor");
            DropTable("dbo.Persona_Empleado");
            DropTable("dbo.Persona_Cliente");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.FormularioPerfil");
            DropTable("dbo.Contadores");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Rubros");
            DropTable("dbo.Configuraciones");
            DropTable("dbo.ListaPrecios");
            DropTable("dbo.Precios");
            DropTable("dbo.Marcas");
            DropTable("dbo.Ivas");
            DropTable("dbo.Provincia");
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Formularios");
            DropTable("dbo.Perfiles");
            DropTable("dbo.Movimientos");
            DropTable("dbo.DetalleCajas");
            DropTable("dbo.Cajas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.MovimientoCuentaCorrientes");
            DropTable("dbo.CondicionIva");
            DropTable("dbo.FormaPagos");
            DropTable("dbo.DepositoCheques");
            DropTable("dbo.CuentaBancarias");
            DropTable("dbo.Bancos");
            DropTable("dbo.Cheques");
            DropTable("dbo.Localidad");
            DropTable("dbo.Persona");
            DropTable("dbo.Comprobantes");
            DropTable("dbo.DetalleComprobantes");
            DropTable("dbo.DetalleArticuloCompuestos");
            DropTable("dbo.MotivoBajas");
            DropTable("dbo.BajaArticulos");
            DropTable("dbo.Articulos");
        }
    }
}
