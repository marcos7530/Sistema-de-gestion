namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Aplicacion.Constantes.Clases;
    using MetaData;

    [Table("Comprobantes")]
    [MetadataType(typeof(IPresupuesto))]
    public class Presupuesto : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }        

        // Propiedades de Navegacion
        public Cliente Cliente { get; set; }
    }
}
/*******************************************************
 * El Presupuesto tiene precioPublico que puede ser modificado
 * descripcion dela mercaderia detalllada
 * mostrar Observaciones
 * tiene fecha limite
 * *********************************************/