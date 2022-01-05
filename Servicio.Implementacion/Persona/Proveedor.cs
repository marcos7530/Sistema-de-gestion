using System.Linq;

namespace Servicio.Implementacion.Persona
{
    using System;
    using System.Collections.Generic;
    using Servicio.Interfaces.Persona.DTOs;
    using System.Linq.Expressions;
    using Dominio.Entidades.UnidadDeTrabajo;
    using StructureMap;

    public class Proveedor : Persona
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public Proveedor()
        {
            _unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
        }

        public override long Add(PersonaDto entidad)
        {
            var entidadNueva = (ProveedorDto)entidad;

            var entidadId = _unidadDeTrabajo.ProveedorRepositorio.Insertar(new Dominio.Entidades.Proveedor
                {
                    EstaEliminado = false,
                    CUIT = entidadNueva.CUIT,
                    RazonSocial = entidadNueva.RazonSocial,
                    Celular = entidadNueva.Celular,
                    Direccion = entidadNueva.Direccion,
                    Email = entidadNueva.Email,
                    LocalidadId = entidadNueva.LocalidadId,
                    Telefono = entidadNueva.Telefono,
                    CondicionIvaId = entidadNueva.CondicionIvaId,
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public override void Update(PersonaDto entidad)
        {
            var entidadModificar = (ProveedorDto)entidad;

            _unidadDeTrabajo.ProveedorRepositorio.Modificar(new Dominio.Entidades.Proveedor
            {
                Id = entidadModificar.Id,
                EstaEliminado = false,
                CUIT = entidadModificar.CUIT,
                RazonSocial = entidadModificar.RazonSocial,
                Celular = entidadModificar.Celular,
                Direccion = entidadModificar.Direccion,
                Email = entidadModificar.Email,
                LocalidadId = entidadModificar.LocalidadId,
                Telefono = entidadModificar.Telefono,
                CondicionIvaId = entidadModificar.CondicionIvaId,
            });

            _unidadDeTrabajo.Commit();
        }

        public override void Delete(PersonaDto entidad)
        {
            var entidadEliminar = (ProveedorDto)entidad;

            _unidadDeTrabajo.ProveedorRepositorio.Eliminar(new Dominio.Entidades.Proveedor
            {
                Id = entidadEliminar.Id,
                EstaEliminado = true,
                CUIT = entidadEliminar.CUIT,
                RazonSocial = entidadEliminar.RazonSocial,
                Celular = entidadEliminar.Celular,
                Direccion = entidadEliminar.Direccion,
                Email = entidadEliminar.Email,
                LocalidadId = entidadEliminar.LocalidadId,
                Telefono = entidadEliminar.Telefono,
                CondicionIvaId = entidadEliminar.CondicionIvaId,
            });

            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<PersonaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Proveedor, bool>> filtro = proveedor =>
                !proveedor.EstaEliminado && proveedor.RazonSocial.Contains(cadenaBuscar)
                || proveedor.CUIT == cadenaBuscar;

            return _unidadDeTrabajo.ProveedorRepositorio.Obtener(filtro, "Localidad, Localidad.Provincia, CondicionIva")
                .Select(x => new ProveedorDto
                {
                    Id = x.Id,
                    RazonSocial = x.RazonSocial,
                    CUIT = x.CUIT,
                    Celular = x.Celular,
                    Direccion = x.Direccion,
                    Email = x.Email,
                    LocalidadId = x.LocalidadId,
                    Localidad = x.Localidad.Descripcion,
                    ProvinciaId = x.Localidad.ProvinciaId,
                    Provincia = x.Localidad.Provincia.Descripcion,
                    Telefono = x.Telefono,
                    EstaEliminado = x.EstaEliminado,
                    CondicionIva = x.CondicionIva.Descripcion,
                    CondicionIvaId = x.CondicionIvaId,
                    RowVersion = x.RowVersion
                }).OrderBy(x => x.RazonSocial)
                .ToList();
        }

        public override PersonaDto GetById(long id)
        {
            var proveedor = _unidadDeTrabajo.ProveedorRepositorio.Obtener(id, "Localidad, Localidad.Provincia, CondicionIva");

            return new ProveedorDto
            {
                Id = proveedor.Id,
                RazonSocial = proveedor.RazonSocial,
                CUIT = proveedor.CUIT,
                Celular = proveedor.Celular,
                Direccion = proveedor.Direccion,
                Email = proveedor.Email,
                LocalidadId = proveedor.LocalidadId,
                Localidad = proveedor.Localidad.Descripcion,
                ProvinciaId = proveedor.Localidad.ProvinciaId,
                Provincia = proveedor.Localidad.Provincia.Descripcion,
                Telefono = proveedor.Telefono,
                EstaEliminado = proveedor.EstaEliminado,
                CondicionIva = proveedor.CondicionIva.Descripcion,
                CondicionIvaId = proveedor.CondicionIvaId,
                RowVersion = proveedor.RowVersion
            };
        }
    }
}
