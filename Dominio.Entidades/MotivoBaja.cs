

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;
    
    [Table("MotivoBajas")]
    [MetadataType(typeof(IMotivoBaja))]
    public class MotivoBaja : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public ICollection<BajaArticulo> BajaArticulos { get; set; }
    }
}