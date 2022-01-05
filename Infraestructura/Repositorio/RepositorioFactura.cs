using Dominio.Entidades;
using Dominio.Entidades.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositorio
{
    public class RepositorioFactura: Repositorio<Dominio.Entidades.Factura>, IRepositorioFactura
    {
        private DataContext _dataContext;
        public RepositorioFactura(DataContext context)
            :base(context)
        {
            _dataContext = context;
        }

        public override Factura Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Factura>>(_dataContext.Set<Dominio.Entidades.Comprobante>()
                        .OfType<Dominio.Entidades.Factura>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }

        public override IEnumerable<Dominio.Entidades.Factura>
            Obtener(Expression<Func<Dominio.Entidades.Factura, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.Comprobante>()
                .OfType<Dominio.Entidades.Factura>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Factura>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.Factura> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }
    }
}
