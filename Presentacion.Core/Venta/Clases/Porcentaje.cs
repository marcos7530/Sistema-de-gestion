namespace Presentacion.Core.Venta.Clases
{
    public static class Porcentaje
    {
        public static decimal CalcularMontoDescuento(decimal porcentaje, decimal monto)
        {
            return ( porcentaje * monto ) / 100m;
        }
    }
}
