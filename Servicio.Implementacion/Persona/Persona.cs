namespace Servicio.Implementacion.Persona
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Servicio.Interfaces.Persona.DTOs;

    public class Persona
    {
        public virtual long Add(PersonaDto entidad)
        {
            return 0;
        }

        public virtual void Delete(PersonaDto entidad)
        {            
        }

        public virtual IEnumerable<PersonaDto> Get(string cadenaBuscar)
        {
            return null;
        }

        public virtual PersonaDto GetById(long id)
        {
            return null;
        }

        public virtual void Update(PersonaDto entidad)
        {
        }
    }
}
