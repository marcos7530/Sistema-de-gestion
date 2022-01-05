namespace Dominio.Entidades
{
    using Aplicacion.Constantes.Clases;
    using Dominio.Entidades.MetaData;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comprobantes")]
    [MetadataType(typeof(IRemito))]
    public class Remito: Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }
        
        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}
/* el remito te da informacion de la mercaderia que  lleva
 * p ej yo compro por telefono puedo facturar virtualmente
 * cuando llega la mercaderia recibo el remito. sirve para controles
 * policiales para el transporte
 * puede llevar la informacion del tranporte 
 * remito solo tiene cantidades no precios
 * */