namespace Servicio.Interfaces.DetalleArticuloCompuesto
{
    using Servicio.Interfaces.DetalleArticuloCompuesto.DTOs;
    using System.Collections.Generic;

    public interface IDetalleArticuloCompuestoServicio
    {
        long Add(DetalleArticuloCompuestoDto entidad);

        void Update(DetalleArticuloCompuestoDto entidad);

        void Delete(long id);

        IEnumerable<DetalleArticuloCompuestoDto> Get(string cadenaBuscar);

        DetalleArticuloCompuestoDto GetById(long id);
    }
}
