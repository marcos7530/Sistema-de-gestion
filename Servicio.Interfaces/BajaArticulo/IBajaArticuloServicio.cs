namespace Servicio.Interfaces.BajaArticulo
{
    using Servicio.Interfaces.BajaArticulo.DTOs;
    using System.Collections.Generic;

    public interface IBajaArticuloServicio
    {
        long Add(BajaArticuloDto entidad);

        void Update(BajaArticuloDto entidad);

        void Delete(long id);

        IEnumerable<BajaArticuloDto> Get(string cadenaBuscar);

        BajaArticuloDto GetById(long id);
    }
}
