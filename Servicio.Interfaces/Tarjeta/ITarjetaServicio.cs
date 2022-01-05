namespace Servicio.Interfaces.Tarjeta
{
    using Servicio.Interfaces.Tarjeta.DTOs;
    using System.Collections.Generic;

    public interface ITarjetaServicio
    {
        long Add(TarjetaDto entidad);

        void Update(TarjetaDto entidad);

        void Delete(long id);

        IEnumerable<TarjetaDto> Get(string cadenaBuscar);

        TarjetaDto GetById(long id);
    }
}
