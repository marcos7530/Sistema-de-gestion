using Servicio.Interfaces.ListaPrecio.DTOs;
using System.Collections.Generic;

namespace Servicio.Interfaces.ListaPrecio
{
    public interface IListaPrecioServicio
    {
        long Add(ListaPrecioDto entidad);

        void Update(ListaPrecioDto entidad);

        void Delete(long id);

        IEnumerable<ListaPrecioDto> Get(string cadenaBuscar);

        ListaPrecioDto GetById(long id);
    }
}
