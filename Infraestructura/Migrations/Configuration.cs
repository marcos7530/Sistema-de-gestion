using Dominio.Entidades;

namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infraestructura.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infraestructura.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            try
            {
                if (!context.Configuraciones.Any())
                {
                    var configuracion = new Configuracion()
                    {
                        RazonSocial = "Negocio",
                        Cuit = "99999999999",
                        Telefono = "9999999",
                        Celular = "9999999999",
                        Direccion = "ALGUN LUGAR",
                        ProvinciaId = 0,
                        LocalidadId = 0,
                        Email = "NOTIENE@GMAIL.COM",
                        FacturaDescuentaStock = true,
                        PresupuestoDescuentaStock = false,
                        RemitoDescuentaStock = false,
                        ActualizaCostoDesdeCompra = false,
                        ModificaPrecioVentaDesdeCompra = true,
                        TipoPagoCompraPorDefecto = Aplicacion.Constantes.Clases.TipoPago.Efectivo,
                        ListaPrecioPorDefectoVentaId = 0,
                        ObservacionEnPieFactura = "",
                        UnificarRenglonesIngresarMismoProducto = true,
                        IngresoManualCajaInicial = true,
                        CajaSeparada = false
                    };

                    context.Configuraciones.Add(configuracion);

                    context.SaveChanges();
                }


                //if (!context.Clientes.Any())
                //{
                //    var cliente = new Cliente()
                //    {
                        
                //    };
                //}
               

            }
            catch (Exception e)
            {
                throw new Exception($"Ocurrio un Error en el Seed - {e.Message}");
            }



        }
    }
}
