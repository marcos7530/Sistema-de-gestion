using System;
using System.Collections.Generic;
using Servicio.Interfaces.PerfilUsuario.DTOs;

namespace Servicio.Implementacion.PerfilUsuario
{
    public class UsuarioComparer : IEqualityComparer<PerfilUsuarioDto>
    {
        public bool Equals(PerfilUsuarioDto x, PerfilUsuarioDto y)
        {
            return x.UsuarioId.Equals(y.UsuarioId);
        }

        public int GetHashCode(PerfilUsuarioDto obj)
        {
            return Object.ReferenceEquals(obj, null) ? 0 : obj.UsuarioId.GetHashCode();
        }
    }
}
