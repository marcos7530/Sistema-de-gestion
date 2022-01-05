namespace Servicio.Interfaces.MotivoBaja
{
    using Servicio.Interfaces.MotivoBaja.DTOs;
    using System.Collections.Generic;

    public interface IMotivoBajaServicio
    {
        long Add(MotivoBajaDto entidad);

        void Update(MotivoBajaDto entidad);

        void Delete(long id);

        IEnumerable<MotivoBajaDto> Get(string cadenaBuscar);

        MotivoBajaDto GetById(long id);
    }
}
