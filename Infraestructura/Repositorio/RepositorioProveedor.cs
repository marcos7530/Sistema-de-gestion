namespace Infraestructura.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Entidades.Repositorio;
    using Infraestructura;
    using Infraestructura.Repositorio;

    public class RepositorioProveedor : Repositorio<Dominio.Entidades.Proveedor>, IRepositorioProveedor
    {
        private DataContext _dataContext;
        public RepositorioProveedor(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public override IEnumerable<Dominio.Entidades.Proveedor> Obtener(Expression<Func<Dominio.Entidades.Proveedor, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.Persona>()
                .OfType<Dominio.Entidades.Proveedor>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Proveedor>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.Proveedor> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.Proveedor Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Proveedor>>(_dataContext.Set<Dominio.Entidades.Persona>()
                        .OfType<Dominio.Entidades.Proveedor>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }
    }
}
