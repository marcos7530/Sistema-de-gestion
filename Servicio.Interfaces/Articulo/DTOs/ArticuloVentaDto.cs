using System;

namespace Servicio.Interfaces.Articulo.DTOs
{
    public class ArticuloVentaDto: Base.BaseDto
    {
        
        public long CodigoArticulo{ get; set; }
        public string CodigoBarraArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public string IvaStr { get; set; }
        public decimal Stock { get; set; }
        public decimal PrecioArticulo { get; set; }        
        public long IvaId { get; set; }//agregados 2 prop
        public decimal MontoIva105 { get; set; }
        public decimal MontoIva21 { get; set; }
        

        //restricciones
        public bool ActivarLimiteVenta { get; set; }
        public decimal LimiteVenta { get; set; }
        public bool ActivarHoraVenta { get; set; }
        public DateTime HoraLimiteVentaInicio { get; set; }
        public DateTime HoraLimiteVentaFin { get; set; }
        

        //cuando se va a facturar
        public bool PermiteStockNegativo { get; set; }
        public bool DescuentaStock { get; set; }
    }
}
