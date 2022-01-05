namespace Servicio.Interfaces.Provincia
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;

    public interface IProvinciaServicio
    {
        long AddProvincia(ProvinciaDto entidad);

        void UpdateProvincia(ProvinciaDto entidad);

        void DeleteProvincia(long id);

        IEnumerable<ProvinciaDto> Get(string cadenaBuscar);

        ProvinciaDto GetById(long id);
    }
}
