using Dominio.Base;
using Dominio.Entidades.MetaData;
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
    public class RepositorioCtaCte: Repositorio<Dominio.Entidades.FormaPagoCtaCte>, IRepositorioFormaPagoCtaCte
    {
        private DataContext _dataContext;
        public RepositorioCtaCte(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public override IEnumerable<Dominio.Entidades.FormaPagoCtaCte>
            Obtener(Expression<Func<Dominio.Entidades.FormaPagoCtaCte, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.FormaPago>()
                .OfType<Dominio.Entidades.FormaPagoCtaCte>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoCtaCte>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.FormaPagoCtaCte> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.FormaPagoCtaCte Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoCtaCte>>(_dataContext.Set<Dominio.Entidades.FormaPago>()
                        .OfType<Dominio.Entidades.FormaPagoCtaCte>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }
    }
}
