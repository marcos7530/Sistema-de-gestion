namespace Dominio.Entidades
{
    //movimientos de cuenta corriente
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Aplicacion.Constantes.Clases;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;

    [Table("MovimientoCuentaCorrientes")]
    [MetadataType(typeof(IMovimientoCuentaCorriente))]
    public class MovimientoCuentaCorriente : Entidad
    {
        // Propiedades 
        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
