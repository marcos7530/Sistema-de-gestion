using Aplicacion.Constantes.Clases;
using Presentacion.Core.Venta.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion.Core.Venta.Venta
{
    public class FacturaView
    {
        public FacturaView()
        {
            PorcentajeDescuento = 0M;
            if (Items == null)
                Items = new List<ItemsView>();
        }

        public TipoComprobante TipoComprobante { get; set; }
        public long UsuarioId { get; set; }
        public int Numerofactura { get; set; }
        public long VendedorId { get; set; }
        public string ApyNomVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public long ClienteId { get; set; }
        public string ApyNomCliente { get; set; }
        public string CuilCliente { get; set; }
        public string DireccionCliente { get; set; }
        public long CondicionIvaClienteId { get; set; }
        public long ListaPrecioId { get; set; }
        //datos
        public List<ItemsView> Items { get; set; }
        public decimal Iva21 => Items.Sum(x => x.Iva21 * x.Cantidad);
        public decimal Iva105 => Items.Sum(x => x.Iva105 * x.Cantidad);
        public decimal Subtotal => Items.Sum(x => x.Subtotal);
        public decimal PorcentajeDescuento { get; set; }
        public decimal MontoDescuento => Porcentaje.CalcularMontoDescuento(PorcentajeDescuento, Subtotal);
        public decimal Total => Subtotal - MontoDescuento;
    }
}
