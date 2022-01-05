namespace Infraestructura.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using Infraestructura;
    using Dominio.Entidades.Repositorio;

    public class RepositorioCliente : Repositorio<Dominio.Entidades.Cliente>, IRepositorioCliente
    {
        private DataContext _dataContext;
        public RepositorioCliente(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public override IEnumerable<Dominio.Entidades.Cliente> Obtener(Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.Persona>()
                .OfType<Dominio.Entidades.Cliente>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Cliente>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.Cliente> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.Cliente Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Cliente>>(_dataContext.Set<Dominio.Entidades.Persona>()
                        .OfType<Dominio.Entidades.Cliente>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }
    }
}
