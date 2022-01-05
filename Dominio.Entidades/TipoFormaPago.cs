namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("TipoFormaPagos")]
    [MetadataType(typeof(ITipoFormaPago))]
    public class TipoFormaPago : Entidad
    {
        //Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        //[ForeignKey("TipoFormaPagoPorDefectoCompraId")]
        //public virtual ICollection<Configuracion> ConfiguracioneCompras { get; set; }

        //[ForeignKey("TipoFormaPagoPorDefectoVentaId")]
        //public virtual ICollection<Configuracion> ConfiguracioneVentas { get; set; }
    }
}