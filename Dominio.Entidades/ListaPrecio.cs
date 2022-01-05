namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("ListaPrecios")]
    [MetadataType(typeof(IListaPrecio))]
    public class ListaPrecio : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        public decimal PorcentajeGanancia { get; set; }

        public bool NecesitaAutorizacion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Precio> Precios { get; set; }

        public virtual ICollection<Configuracion> Configuraciones { get; set; }
    }
}
