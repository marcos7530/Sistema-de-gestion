namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using Base;
    using MetaData;

    [Table("Cheques")]
    [MetadataType(typeof(ICheque))]
    public class Cheque : Entidad
    {
        // Propiedades
        public long ClienteId { get; set; }

        public long BancoId { get; set; }

        public string Numero { get; set; }

        /*================AGREGADO====================*/
        public decimal Monto { get; set; }
        /*====================================*/

        public DateTime FechaVencimiento { get; set; }

        public bool EstaRechazado { get; set; }

        // Propiedades de Navegacion
        public virtual Banco Banco { get; set; }

        public virtual Cliente Cliente { get; set; }

        public ICollection<DepositoCheque> DepositoCheques { get; set; }

        public ICollection<FormaPagoCheque> FormaPagoCheques { get; set; }
    }
}
