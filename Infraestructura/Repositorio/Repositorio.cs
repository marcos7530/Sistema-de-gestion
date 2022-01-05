namespace Infraestructura.Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Base;

    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : Entidad
    {
        internal DataContext _dataContext;

        public Repositorio(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual long Insertar(TEntidad entidadNueva)
        {
            if(entidadNueva == null)
                throw new Exception("La entidad no puede ser un valor Null");

            _dataContext.Set<TEntidad>().Add(entidadNueva);

            return entidadNueva.Id;
        }
        
        public virtual void Eliminar(TEntidad entidadEliminar)
        {
            if (entidadEliminar == null)
                throw new Exception("La entidad no puede ser un valor Null");

            var entidad = _dataContext.Set<TEntidad>().FirstOrDefault(x=>x.Id == entidadEliminar.Id);

            entidad.EstaEliminado = !entidad.EstaEliminado;
        }
        
        public virtual void Modificar(TEntidad entidadModificar)
        {
            if (entidadModificar == null)
                throw new Exception("La entidad no puede ser un valor Null");

            _dataContext.Set<TEntidad>().Attach(entidadModificar);
            //_dataContext.Set<TEntidad>().AddOrUpdate(entidadModificar);
            //error de attaching
            var entidad = _dataContext.Set<TEntidad>().FirstOrDefault(x => x.Id == entidadModificar.Id);
            if (entidad != null)
                _dataContext.Entry(entidad).State = EntityState.Detached;

            

            _dataContext.Entry(entidadModificar).State = EntityState.Modified;
        }
        
        public virtual TEntidad Obtener(long entidadId, string propiedadNavegacion = "")
        {
            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<TEntidad>>(_dataContext.Set<TEntidad>(), (current, include) => current.Include(include));

            return resultado.FirstOrDefault(x => x.Id == entidadId);
        }

        public virtual IEnumerable<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro = null, string propiedadNavegacion = "")
        {
            var context = ((IObjectContextAdapter)_dataContext).ObjectContext;
            var resultadoClient = context.CreateObjectSet<TEntidad>();
            context.Refresh(RefreshMode.ClientWins, resultadoClient);

            var resultado = propiedadNavegacion.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate<string,
                IQueryable<TEntidad>>(resultadoClient, (current, include) => current.Include(include));

            if (filtro != null) resultado = resultado.Where(filtro);

            return resultado.ToList();
        }

        
        //Esta es la implementacion 
        public void EliminarAgregado(long entidadId)
        {
            var entidadEliminar = _dataContext.Set<TEntidad>().FirstOrDefault(x => x.Id == entidadId);

            if (entidadEliminar == null) throw new Exception("La entidad a eliminar no puede ser Null");

            entidadEliminar.EstaEliminado = !entidadEliminar.EstaEliminado;
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }
    }
}
