namespace Servicio.Implementacion.Seguridad
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using static Aplicacion.Constantes.Clases.Password;
    using Servicio.Interfaces.Seguridad;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class SeguridadServicio : ISeguridadServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public SeguridadServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public bool VerificarAcceso(string usuario, string password)
        {
            var passwordEncriptado = Encriptar(password);

            Expression<Func<Dominio.Entidades.Usuario, bool>> filtro = x =>
                x.Nombre == usuario && x.Password == passwordEncriptado;

            return _unidadDeTrabajo.UsuarioRepositorio.Obtener(filtro).Any();
        }

        public bool VerificarAccesoFormulario(string usuarioLogin, string nombreFormulario)
        {
            if (usuarioLogin == "admin") return true;

            return _unidadDeTrabajo.PerfilRepositorio
                .Obtener(x => x.Formularios.Any(f => f.NombreCompleto == nombreFormulario)
                              && x.Usuarios.Any(u => u.Nombre == usuarioLogin), "Formularios, Usuarios")
                .Any();
        }
    }
}
