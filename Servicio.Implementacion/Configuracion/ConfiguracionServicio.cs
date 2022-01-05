namespace Servicio.Implementacion.Configuracion
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Interfaces.Configuracion.DTOs;
    using System.Linq;

    public class ConfiguracionServicio : IConfiguracionServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ConfiguracionServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

         public ConfiguracionDto Get()
        {
            var c =_unidadDeTrabajo.ConfiguracionRepositorio.Obtener(
                x=>x.EstaEliminado == false, "Localidad, Provincia, ListaPrecioPorDefectoVenta").FirstOrDefault();
            if (c != null)
            {
                return new ConfiguracionDto
                {
                    LocalidadId = c.LocalidadId,
                    ProvinciaId = c.ProvinciaId,
                    RazonSocial = c.RazonSocial,
                    Cuit = c.Cuit,
                    Telefono = c.Telefono,
                    Celular = c.Celular,
                    Direccion = c.Direccion,
                    Email = c.Email,
                    FacturaDescuentaStock = c.FacturaDescuentaStock,
                    PresupuestoDescuentaStock = c.PresupuestoDescuentaStock,
                    RemitoDescuentaStock = c.RemitoDescuentaStock,
                    ActualizaCostoDesdeCompra = c.ActualizaCostoDesdeCompra,
                    ModificaPrecioVentaDesdeCompra = c.ModificaPrecioVentaDesdeCompra,
                    TipoPagoCompraPorDefecto = c.TipoPagoCompraPorDefecto,
                    ObservacionEnPieFactura = c.ObservacionEnPieFactura,
                    UnificarRenglonesIngresarMismoProducto = c.UnificarRenglonesIngresarMismoProducto,
                    ListaPrecioPorDefectoVentaId = c.ListaPrecioPorDefectoVentaId,
                    IngresoManualCajaInicial = c.IngresoManualCajaInicial,
                    CajaSeparada = c.CajaSeparada,
                    RowVersion = c.RowVersion
                };
            }
            else return null;
        }

        public void Grabar(ConfiguracionDto entidad)
        {
            var conf = _unidadDeTrabajo.ConfiguracionRepositorio.Obtener(x => x.EstaEliminado == false,
                                    "Localidad, Provincia, ListaPrecioPorDefectoVenta").FirstOrDefault();

            if (conf == null)
            {
                _unidadDeTrabajo.ConfiguracionRepositorio.Insertar(new Dominio.Entidades.Configuracion
                {
                    EstaEliminado = false,
                    LocalidadId = entidad.LocalidadId,
                    ProvinciaId = entidad.ProvinciaId,
                    RazonSocial = entidad.RazonSocial,
                    Cuit = entidad.Cuit,
                    Telefono = entidad.Telefono,
                    Celular = entidad.Celular,
                    Direccion = entidad.Direccion,
                    Email = entidad.Email,
                    FacturaDescuentaStock = entidad.FacturaDescuentaStock,
                    PresupuestoDescuentaStock = entidad.PresupuestoDescuentaStock,
                    RemitoDescuentaStock = entidad.RemitoDescuentaStock,
                    ActualizaCostoDesdeCompra = entidad.ActualizaCostoDesdeCompra,
                    ModificaPrecioVentaDesdeCompra = entidad.ModificaPrecioVentaDesdeCompra,
                    TipoPagoCompraPorDefecto = entidad.TipoPagoCompraPorDefecto,
                    ObservacionEnPieFactura = entidad.ObservacionEnPieFactura,
                    UnificarRenglonesIngresarMismoProducto = entidad.UnificarRenglonesIngresarMismoProducto,
                    ListaPrecioPorDefectoVentaId = entidad.ListaPrecioPorDefectoVentaId,
                    IngresoManualCajaInicial = entidad.IngresoManualCajaInicial,
                    CajaSeparada = entidad.CajaSeparada
                });
            }
            else
            {
                conf.LocalidadId = entidad.LocalidadId;
                conf.EstaEliminado = false;
                conf.ProvinciaId = entidad.ProvinciaId;
                conf.RazonSocial = entidad.RazonSocial;
                conf.Cuit = entidad.Cuit;
                conf.Telefono = entidad.Telefono;
                conf.Celular = entidad.Celular;
                conf.Direccion = entidad.Direccion;
                conf.Email = entidad.Email;
                conf.FacturaDescuentaStock = entidad.FacturaDescuentaStock;
                conf.PresupuestoDescuentaStock = entidad.PresupuestoDescuentaStock;
                conf.RemitoDescuentaStock = entidad.RemitoDescuentaStock;
                conf.ActualizaCostoDesdeCompra = entidad.ActualizaCostoDesdeCompra;
                conf.ModificaPrecioVentaDesdeCompra = entidad.ModificaPrecioVentaDesdeCompra;
                conf.TipoPagoCompraPorDefecto = entidad.TipoPagoCompraPorDefecto;
                conf.ObservacionEnPieFactura = entidad.ObservacionEnPieFactura;
                conf.UnificarRenglonesIngresarMismoProducto = entidad.UnificarRenglonesIngresarMismoProducto;
                conf.ListaPrecioPorDefectoVentaId = entidad.ListaPrecioPorDefectoVentaId;
                conf.IngresoManualCajaInicial = entidad.IngresoManualCajaInicial;
                conf.CajaSeparada = entidad.CajaSeparada;
                //conf.RowVersion = entidad.RowVersion;
                _unidadDeTrabajo.ConfiguracionRepositorio.Modificar(conf);                
            } 

            _unidadDeTrabajo.Commit();
        }

    }
}
