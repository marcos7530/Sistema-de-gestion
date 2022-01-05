namespace Servicio.Implementacion.PerfilFormulario
{
    using System;
    using System.Collections.Generic;
    using Servicio.Interfaces.PerfilFormulario.DTOs;

    public class FormularioComparer : IEqualityComparer<PerfilFormularioDto>
    {
        public bool Equals(PerfilFormularioDto x, PerfilFormularioDto y)
        {
            return x.FormularioId.Equals(y.FormularioId);
        }

        public int GetHashCode(PerfilFormularioDto obj)
        {
            return Object.ReferenceEquals(obj, null) ? 0 : obj.FormularioId.GetHashCode();
        }
    }
}
