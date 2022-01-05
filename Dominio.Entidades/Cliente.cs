using System.Collections.Generic;

namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using Dominio.Entidades.MetaData;

    [Table("Persona_Cliente")]
    [MetadataType(typeof(ICliente))]
    public class Cliente : PersonaFisica
    {
        // Propiedades
        public long CondicionIvaId { get; set; }
        public bool ActivarCtaCte { get; set; }
        public bool TieneLimiteCompra { get; set; }
        public decimal Monto { get; set; }

        // Propiedades de Navegacion
        public virtual CondicionIva CondicionIva { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual ICollection<MovimientoCuentaCorriente> CuentaCorrientes { get; set; }
        public virtual ICollection<FormaPagoCtaCte> FormaPagoCtaCtes { get; set; }
    }
}
