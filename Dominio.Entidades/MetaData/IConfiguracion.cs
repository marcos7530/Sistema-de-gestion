namespace Dominio.Entidades.MetaData
{
    using Aplicacion.Constantes.Clases;
    using System.ComponentModel.DataAnnotations;

    public interface IConfiguracion
    {
        // Datos Generales
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string RazonSocial { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(15, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Cuit { get; set; }

        [StringLength(35, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Telefono { get; set; }

        [StringLength(35, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Celular { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Email { get; set; }

        // Datos Stock
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool FacturaDescuentaStock { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool PresupuestoDescuentaStock { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool RemitoDescuentaStock { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool ActualizaCostoDesdeCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool ModificaPrecioVentaDesdeCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        TipoPago TipoPagoCompraPorDefecto { get; set; }
        //long TipoFormaPagoPorDefectoCompraId { get; set; }

        // Datos Ventas
        //[Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        //long TipoFormaPagoPorDefectoVentaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ListaPrecioPorDefectoVentaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(400, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string ObservacionEnPieFactura { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool UnificarRenglonesIngresarMismoProducto { get; set; }

        // Datos Caja
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool IngresoManualCajaInicial { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        bool CajaSeparada { get; set; }
    }
}
