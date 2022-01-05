namespace Servicio.Interfaces.Perfil
{
    using System.Collections.Generic;
    using DTOs;

    public interface IPerfilServicio
    {
        long Add(PerfilDto entidad);

        void Update(PerfilDto entidad);

        void Delete(long id);

        IEnumerable<PerfilDto> Get(string cadenaBuscar);

        PerfilDto GetById(long id);
    }
}
