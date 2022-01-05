namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;
    using System.Collections.Generic;

    [Table("CuentaBancarias")]
    [MetadataType(typeof(ICuentaBancaria))]
    public class CuentaBancaria : Entidad
    {
        // Propiedades        
        public long BancoId { get; set; }
        
        public string Numero { get; set; }
        
        public string Titular { get; set; }

        // Propiedades de Navegacion
        public virtual Banco Banco { get; set; }

        public virtual ICollection<DepositoCheque> DepositoCheques { get; set; }
    }
}
