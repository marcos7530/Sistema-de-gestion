using Aplicacion.Constantes.Clases;

namespace Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Comprobantes")]
    [MetadataType(typeof(IComprobante))]
    public class Comprobante : Entidad
    {
        public long EmpleadoId { get; set; }

        public long UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public int Numero { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public decimal Iva21 { get; set; }

        public decimal Iva105 { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public EstadoComprobante EstadoComprobante { get; set; }

        // Propiedades de Navegacion 
        public Empleado Empleado { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }                         

        [ForeignKey("ComprobanteId")]
        public virtual ICollection<FormaPago> FormaPagos { get; set; }                

        public virtual ICollection<MovimientoCuentaCorriente> MovimientoCuentaCorrientes { get; set; }        
    }
}