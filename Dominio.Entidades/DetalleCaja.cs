using Aplicacion.Constantes.Clases;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;

    [Table("DetalleCajas")]
    [MetadataType(typeof(IDetalleCaja))]
    public class DetalleCaja : Entidad
    {
        // Propiedades
        public long CajaId { get; set; }

        public TipoPago TipoPago { get; set; }

        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public Caja Caja { get; set; }

    }
}