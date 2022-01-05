namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;

    [Table("Tarjetas")]
    [MetadataType(typeof(ITarjeta))]
    public class Tarjeta : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public ICollection<FormaPagoTarjeta> FormaPagoTarjetas { get; set; }
    }
}