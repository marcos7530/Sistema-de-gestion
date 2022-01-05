using Aplicacion.Constantes.Clases;
using System;

namespace Servicio.Interfaces.MOvimientoCuentaCorriente.DTOs
{
    public class MovimientoCuentaCorrienteDto: Base.BaseDto
    {
        public long ComprobanteId { get; set; }

        public long UsuarioId { get; set; }

        public long ClienteId { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
