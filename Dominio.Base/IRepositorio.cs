namespace Dominio.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepositorio<TEntidad> where TEntidad : Entidad
    {

        //estas son las operaciones que tendre que hacer contra el motor
        long Insertar(TEntidad entidadNueva);

        void Eliminar(TEntidad entidad);

        //void EliminarAgregado(long entidadId);//este lo agregue 

        void Modificar(TEntidad entidad);

        TEntidad Obtener(long entidadId, string propiedadNavegacion = "");

        IEnumerable<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro = null, string propiedadNavegacion = "");

       // void Commit();
    }
}
