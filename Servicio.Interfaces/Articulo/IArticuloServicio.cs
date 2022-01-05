namespace Servicio.Interfaces.Articulo
{
    using Servicio.Interfaces.Articulo.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IArticuloServicio
    {
        long Add(ArticuloDto entidad);

        void Update(ArticuloDto entidad);

        void Delete(long id);

        IEnumerable<ArticuloDto> Get(string cadenaBuscar);

        ArticuloDto GetById(long id);

        ArticuloVentaDto GetByCode(string codigo, long listaPrecioId);

        bool UpdateStock(ArticuloDto entidad, decimal nuevoStock);

    }
}
