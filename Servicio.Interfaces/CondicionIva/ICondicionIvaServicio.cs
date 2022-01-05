namespace Servicio.Interfaces.CondicionIva
{
    using System.Collections.Generic;
    using DTOs;

    public interface ICondicionIvaServicio
    {
        long Add(CondicionIvaDto entidad);

        void Update(CondicionIvaDto entidad);

        void Delete(long id);

        IEnumerable<CondicionIvaDto> Get(string cadenaBuscar);

        CondicionIvaDto GetById(long id);
    }
}
