namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("Bancos")]
    [MetadataType(typeof(IBanco))]
    public  class Banco : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Cheque> Cheques { get; set; }

        public virtual ICollection<CuentaBancaria> CuentaBancarias { get; set; }
    }
}