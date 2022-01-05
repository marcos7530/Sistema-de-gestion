namespace Infraestructura.Repositorio
{
    using Dominio.Entidades.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    public class RepositorioCheque : Repositorio<Dominio.Entidades.FormaPagoCheque>, IRepositorioFormaPagoCheque
    {
        private DataContext _dataContext;
        public RepositorioCheque(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public override IEnumerable<Dominio.Entidades.FormaPagoCheque> 
            Obtener(Expression<Func<Dominio.Entidades.FormaPagoCheque, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.FormaPago>()
                .OfType<Dominio.Entidades.FormaPagoCheque>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoCheque>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.FormaPagoCheque> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.FormaPagoCheque Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoCheque>>(_dataContext.Set<Dominio.Entidades.FormaPago>()
                        .OfType<Dominio.Entidades.FormaPagoCheque>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }
    }
}
