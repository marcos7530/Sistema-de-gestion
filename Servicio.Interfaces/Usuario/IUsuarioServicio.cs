using System.Collections.Generic;
using Servicio.Interfaces.Usuario.DTOs;

namespace Servicio.Interfaces.Usuario
{
    public interface IUsuarioServicio
    {
        IEnumerable<UsuarioDto> Get(string cadenaBuscar);

        UsuarioDto GetByUser(string nombreUsuario);

        void Add(List<UsuarioDto> empleados);

        void BloquearDesbloquear(List<UsuarioDto> usuarios);

        void ResetearPassword(List<UsuarioDto> usuarios);
    }
}
