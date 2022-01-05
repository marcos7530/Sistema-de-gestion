namespace Servicio.Interfaces.Marca
{
    using Servicio.Interfaces.Marca.DTOs;
    using System.Collections.Generic;

    public interface IMarcaServicio
    {
        long Add(MarcaDto entidad);

        void Update(MarcaDto entidad);

        void Delete(long id);

        IEnumerable<MarcaDto> Get(string cadenaBuscar);

        MarcaDto GetById(long id);
    }
}
