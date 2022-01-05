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

    public class RepositorioEfectivo : Repositorio<Dominio.Entidades.FormaPagoEfectivo>, IRepositorioFormaPagoEfectivo
    {
        private DataContext _dataContext;
        public RepositorioEfectivo(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public override IEnumerable<Dominio.Entidades.FormaPagoEfectivo>
            Obtener(Expression<Func<Dominio.Entidades.FormaPagoEfectivo, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.FormaPagoEfectivo>()
                .OfType<Dominio.Entidades.FormaPagoEfectivo>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoEfectivo>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.FormaPagoEfectivo> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.FormaPagoEfectivo Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.FormaPagoEfectivo>>(_dataContext.Set<Dominio.Entidades.FormaPago>()
                        .OfType<Dominio.Entidades.FormaPagoEfectivo>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }
    }
}
