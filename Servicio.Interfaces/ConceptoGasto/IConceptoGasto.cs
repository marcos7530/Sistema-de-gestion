using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Interfaces.Base;
using Servicio.Interfaces.ConceptoGasto.DTOs;

namespace Servicio.Interfaces.ConceptoGasto
{
    public interface IConceptoGastoServicio
    {

        long Add(ConceptoGastoDto entidad);

        void Update(ConceptoGastoDto entidad);

        void Delete(long id);

        IEnumerable<ConceptoGastoDto> Get(string cadenaBuscar);

        ConceptoGastoDto GetById(long id);


        //BaseDto Obtener(long id);

        //IEnumerable<BaseDto> Obtener(string cadenaBuscar, bool mostrarTodos = true);
        //void Insertar(BaseDto dtoEntidad);

        //void Modificar(BaseDto dtoEntidad);

        //void Eliminar(long id);

        //bool VerificarSiExiste(string datoVerificar, long? entidadId = null);
    }
}
