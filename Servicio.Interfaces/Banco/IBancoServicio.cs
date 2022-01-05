namespace Servicio.Interfaces.Banco
{
    using Servicio.Interfaces.Banco.DTOs;
    using System.Collections.Generic;


    public interface IBancoServicio
    {
        long Add(BancoDto entidad);

        void Update(BancoDto entidad);

        void Delete(long id);

        IEnumerable<BancoDto> Get(string cadenaBuscar);

        BancoDto GetById(long id);
    }
}
