namespace Servicio.Interfaces.Rubro
{
    using Servicio.Interfaces.Rubro.DTOs;
    using System.Collections.Generic;

    public interface IRubroServicio
    {
        long Add(RubroDto entidad);

        void Update(RubroDto entidad);

        void Delete(long id);

        IEnumerable<RubroDto> Get(string cadenaBuscar);

        RubroDto GetById(long id);
    }
}
