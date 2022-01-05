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

    public class RepositorioEmpleado : Repositorio<Dominio.Entidades.Empleado>, IRepositorioEmpleado
    {
        private DataContext _dataContext;
        public RepositorioEmpleado(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        
        public override IEnumerable<Dominio.Entidades.Empleado> Obtener(Expression<Func<Dominio.Entidades.Empleado, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.Persona>()
                .OfType<Dominio.Entidades.Empleado>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Empleado>>(resultadoClient,
                    (current, include) => current.Include(include));

            IQueryable<Dominio.Entidades.Empleado> entidades = resultado;

            if (filtro != null)
                entidades = entidades.Where(filtro);

            return entidades.AsNoTracking().ToList();
        }

        public override Dominio.Entidades.Empleado Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<Dominio.Entidades.Empleado>>(_dataContext.Set<Dominio.Entidades.Persona>()
                        .OfType<Dominio.Entidades.Empleado>(),
                    (current, include) => current.Include(include));

            return resultado.AsNoTracking().FirstOrDefault(x => x.Id == entidadId);
        }

        public int ObtenerSiguienteNumeroLegajo()
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<Dominio.Entidades.Persona>()
                .OfType<Dominio.Entidades.Empleado>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            IQueryable<Dominio.Entidades.Empleado> entidades = resultadoClient;

            return entidades.AsNoTracking().Any() ? entidades.Max(x => x.Legajo) + 1 : 1;
        }
    }
}
