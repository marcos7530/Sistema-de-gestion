using Dominio.Entidades.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("FormaPagos")]
    [MetadataType(typeof(IFormaPagoEfectivo))]
    public class FormaPagoEfectivo: FormaPago
    {
        public long ClienteId { get; set; }

        //propiedades de navegacion
        public Cliente Cliente { get; set; }
    }
}
