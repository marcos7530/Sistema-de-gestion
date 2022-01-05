namespace Servicio.Interfaces.Precio
{
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using Servicio.Interfaces.Precio.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IPrecioServicio
    {
        void Delete(long id);

        IEnumerable<PrecioDto> Get(long articuloId);

        bool UpdatePrecios( Expression<Func<Dominio.Entidades.Articulo, bool>> filtro, 
                          IEnumerable<ListaPrecioDto> listaPrecios, 
                          decimal? monto = null, 
                          decimal? porcentaje = null);

        IEnumerable<PrecioDto> Get(string cadenaBuscar);

        void Update(PrecioDto entidad);

         PrecioDto GetById(long id);
    }
}
