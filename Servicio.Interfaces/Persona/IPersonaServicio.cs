namespace Servicio.Interfaces.Persona
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DTOs;

    public interface IPersonaServicio
    {
        long Add(PersonaDto entidad);

        void Update(PersonaDto entidad);

        void Delete(PersonaDto entidad);

        IEnumerable<PersonaDto> Get(Type tipo, string cadenaBuscar);

        PersonaDto GetById(Type tipo, long id);
    }
}
