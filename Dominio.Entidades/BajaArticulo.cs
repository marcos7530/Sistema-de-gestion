using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dominio.Base;
using Dominio.Entidades.MetaData;

namespace Dominio.Entidades
{
    [Table("BajaArticulos")]
    [MetadataType(typeof(IBajaArticulo))]
    public class BajaArticulo : Entidad
    {
        // Propiedades
        public long ArticuloId { get; set; }

        public long MotivoBajaId { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }

        // Propiedades de Navegacion
        public virtual Articulo Articulo { get; set; }

        public virtual MotivoBaja MotivoBaja { get; set; }  
    }
}