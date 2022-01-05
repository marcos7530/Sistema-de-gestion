 namespace Servicio.Interfaces.Articulo.DTOs
{
    using Aplicacion.Constantes.Clases;
    using System;

    public class ArticuloDto: Base.BaseDto
    {
        public long MarcaId { get; set; }
        public string Marca { get; set; }
        public long RubroId { get; set; }
        public string Rubro { get; set; }
        public long UnidadMedidaId { get; set; }
        public string UnidadMedida { get; set; }
        public long IvaId { get; set; }
        public string Iva { get; set; }
        public long ProveedorId { get; set; }
        public string Proveedor { get; set; }
        public long Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Ubicacion { get; set; }
        public byte[] Foto { get; set; }
        public bool ActivarLimiteVenta { get; set; }
        public decimal LimiteVenta { get; set; }
        public bool ActivarHoraVenta { get; set; }
        public DateTime HoraLimiteVentaInicio { get; set; }
        public DateTime HoraLimiteVentaFin { get; set; }
        public bool PermiteStockNegativo { get; set; }
        public bool DescuentaStock { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public string CodigoProveedor { get; set; }
        public TipoArticulo TipoArticulo { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioPublico { get; set; }
    }
}
