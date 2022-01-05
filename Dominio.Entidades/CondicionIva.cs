namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using Dominio.Entidades.MetaData;
    using Base;
    using Aplicacion.Constantes.Clases;

    [Table("CondicionIva")]
    [MetadataType(typeof(ICondicionIva))]
    public class CondicionIva : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }
        public TipoComprobante TipoComprobante { get; set; }//no estaba

        // Propiedades de Navegacion
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}