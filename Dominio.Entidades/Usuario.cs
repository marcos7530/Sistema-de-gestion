namespace Dominio.Entidades
{
    using Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Usuarios")]
    [MetadataType(typeof(IUsuario))]
    public class Usuario : Entidad
    {
        // Propiedades
        public long EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }

        // Propiedades de Navegacion

        public virtual Empleado Empleado { get; set; }

        public virtual ICollection<Perfil> Perfiles { get; set; }

        public virtual ICollection<Comprobante> Comprobantes { get; set; }

        [ForeignKey("UsuarioAperturaId")]
        public virtual ICollection<Caja> CajaAperturas { get; set; }

        [ForeignKey("UsuarioCierreId")]
        public virtual ICollection<Caja> CajaCierres { get; set; }

        public virtual ICollection<MovimientoCuentaCorriente> CuentaCorrientes { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
