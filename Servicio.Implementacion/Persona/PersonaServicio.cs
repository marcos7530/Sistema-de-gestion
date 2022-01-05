using System.Linq;
using Dominio.Entidades.UnidadDeTrabajo;

namespace Servicio.Implementacion.Persona
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Servicio.Interfaces.Persona;
    using Servicio.Interfaces.Persona.DTOs;

    public class PersonaServicio : IPersonaServicio
    {
        private Dictionary<Type, string> _diccionario;
        //private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public PersonaServicio(/*IUnidadDeTrabajo unidadDeTrabajo*/)
        {
            _diccionario = new Dictionary<Type, string>();
            //_unidadDeTrabajo = unidadDeTrabajo;
            InicializadorDiccionario();
        }
        
        public void AgregarOpcionDiccionario(Type type, string nombre)
        {
            _diccionario.Add(type, nombre);
        }

        public long Add(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            return persona.Add(entidad);
        }
        
        public void Delete(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            persona.Delete(entidad);
        }

        public IEnumerable<PersonaDto> Get(Type tipo, string cadenaBuscar)
        {
            var persona = InstanciarPersonaPorTipo(tipo);

            return persona.Get(cadenaBuscar);
        }
        
        public PersonaDto GetById(Type tipo, long id)
        {
            var persona = InstanciarPersonaPorTipo(tipo);

            return persona.GetById(id);
        }

        public void Update(PersonaDto entidad)
        {
            var persona = InstanciaPersona(entidad);

            persona.Update(entidad);
        }

        // =========================================================== //
        // ============         Metodos Privados           =========== //
        // =========================================================== //

        private void InicializadorDiccionario()
        {
            _diccionario.Add(typeof(EmpleadoDto), "Servicio.Implementacion.Persona.Empleado");
            _diccionario.Add(typeof(ClienteDto), "Servicio.Implementacion.Persona.Cliente");
            _diccionario.Add(typeof(ProveedorDto), "Servicio.Implementacion.Persona.Proveedor");
        }

        private Persona InstanciarEntidad(string tipoEntidad)
        {
            var tipoObjeto = Type.GetType(tipoEntidad);

            if (tipoObjeto == null) return null;

            var entidad = Activator.CreateInstance(tipoObjeto) as Persona;

            return entidad;
        }

        private Persona InstanciaPersona(PersonaDto entidad)
        {
            if (!_diccionario.TryGetValue(entidad.GetType(), out var tipoEntidad))
                throw new Exception($"No hay {entidad.GetType()} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {entidad.GetType()}");

            return persona;
        }

        private Persona InstanciarPersonaPorTipo(Type tipo)
        {
            if (!_diccionario.TryGetValue(tipo, out var tipoEntidad))
                throw new Exception($"No hay {tipoEntidad} para Instanciar.");

            var persona = InstanciarEntidad(tipoEntidad);

            if (persona == null) throw new Exception($"Ocurrió un error al Instanciar {tipo}");

            return persona;
        }

        //public IEnumerable<ProveedorDto> GetProveedores(string cadenaBuscar)
        //{
        //    Expression<Func<Dominio.Entidades.Proveedor, bool>> filtro = t =>
        //        !t.EstaEliminado && t.RazonSocial.Contains(cadenaBuscar);

        //    var resultado = _unidadDeTrabajo.ProveedorRepositorio.Obtener(filtro, "Localidad,Localidad.Provincia, CondicionIva");

        //    return resultado.Select(x => new ProveedorDto()
        //    {
        //        Id = x.Id,
        //        EstaEliminado = x.EstaEliminado,
        //        /*===============================================*/
        //        LocalidadId = x.LocalidadId,
        //        Localidad = x.Localidad.Descripcion,
        //        ProvinciaId = x.Localidad.ProvinciaId,
        //        Provincia = x.Localidad.Provincia.Descripcion,
        //        Telefono = x.Telefono,
        //        Celular = x.Celular,
        //        Direccion = x.Direccion,
        //        Email = x.Email,
        //        RazonSocial = x.RazonSocial,
        //        CUIT = x.CUIT,
        //        CondicionIvaId = x.CondicionIvaId,
        //        CondicionIva = x.CondicionIva.Descripcion,
        //        /*===============================================*/
        //        RowVersion = x.RowVersion
        //    }).ToList();
        //}
    }
}
