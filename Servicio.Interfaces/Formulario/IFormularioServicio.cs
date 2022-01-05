using System;
using System.Reflection;

namespace Servicio.Interfaces.Formulario
{
    using System.Collections.Generic;
    using DTOs;

    public interface IFormularioServicio
    {
        void Add(List<FormularioDto> formularios);

        IEnumerable<FormularioDto> Get(string cadenaBuscar, List<Type> TypesAssemblies);

        FormularioDto GetByName(string nombreUsuario);
    }
}
