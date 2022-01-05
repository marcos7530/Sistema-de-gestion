namespace Servicio.Interfaces.Localidad
{
    using System.Collections.Generic;
    using DTOs;

    public interface ILocalidadServicio
    {
        long Add(LocalidadDto entidad);

        void Update(LocalidadDto entidad);

        void Delete(long id);

        IEnumerable<LocalidadDto> Get(string cadenaBuscar);

        IEnumerable<LocalidadDto> Get(long provinciaId);

        LocalidadDto GetById(long id);
    }
}
