using System;
using Aplicacion.Constantes.Clases;

namespace Dominio.Entidades
{
    using Dominio.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;

    [Table("Movimientos")]
    [MetadataType(typeof(IMovimiento))]
    public class Movimiento : Entidad
    {
        // Propiedades
        public long CajaId { get; set; }

        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
        public virtual Caja Caja { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
