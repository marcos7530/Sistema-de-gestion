namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;
    using System.Collections.Generic;

    [Table("ConceptoGastos")]
    [MetadataType(typeof(IConceptoGasto))]
    public class ConceptoGasto : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Gasto> Gastos { get; set; }  
    }
}
