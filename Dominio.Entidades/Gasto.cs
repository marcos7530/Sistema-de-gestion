using System;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;

    [Table("Gastos")]
    [MetadataType(typeof(IGasto))]
    public class Gasto : Entidad
    {
        // Propiedades
        public long ConceptoGastoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public virtual ConceptoGasto ConceptoGasto { get; set; }
    }
}
