using Aplicacion.Constantes.Clases;

namespace Servicio.Interfaces.Configuracion.DTOs
{
    public class ConfiguracionDto: Base.BaseDto
    {
        public long LocalidadId { get; set; }
        
        public long ProvinciaId { get; set; }
        
        public string RazonSocial { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        // Datos Stock
        public bool FacturaDescuentaStock { get; set; }

        public bool PresupuestoDescuentaStock { get; set; }

        public bool RemitoDescuentaStock { get; set; }

        public bool ActualizaCostoDesdeCompra { get; set; }

        public bool ModificaPrecioVentaDesdeCompra { get; set; }

        public TipoPago TipoPagoCompraPorDefecto { get; set; }

        // Datos Ventas

        public string ObservacionEnPieFactura { get; set; }

        public bool UnificarRenglonesIngresarMismoProducto { get; set; }

        public long ListaPrecioPorDefectoVentaId { get; set; }

        // Datos Caja
        public bool IngresoManualCajaInicial { get; set; }

        public bool CajaSeparada { get; set; }

    }
}
