namespace Presentacion.Core.Venta.Venta
{
    public class ItemsView
    {
        public ItemsView()
        {
            PrecioArticulo = 0m;
            Cantidad = 0;
        }

        public long ListaPrecioId { get; set; }
        public long ProductoId { get; set; }
        public long CodigoArticulo { get; set; }
        public string CodigoBarraArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public decimal PrecioArticulo { get; set; }
        public string PrecioProductoStr => PrecioArticulo.ToString("C");
        public decimal Cantidad { get; set; }
        public long IvaId { get; set; }
        public string IvaStr { get; set; }
        public decimal Iva105 { get; set; }
        public string Iva105Str => Iva105.ToString("C");
        public decimal Iva21 { get; set; }
        public string Iva21Str => Iva21.ToString("C");

        public decimal TotalIva => Iva105 * Cantidad + Iva21 * Cantidad;
        public string TotalIvaStr => TotalIva.ToString("C");

        public decimal Subtotal => PrecioArticulo * Cantidad;  
        public string SubtotalStr => Subtotal.ToString("C");
    }
}
