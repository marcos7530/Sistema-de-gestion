    using Dominio.Entidades.UnidadDeTrabajo;

namespace Servicio.Implementacion.Persona
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Dominio.Base;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;

    public class Empleado : Persona
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public Empleado()
        {
            _unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
        }


        public override long Add(PersonaDto entidad)
        {
            var entidadNueva = (EmpleadoDto) entidad;

            var entidadId = _unidadDeTrabajo.EmpleadoRepositorio.Insertar(new Dominio.Entidades.Empleado
                {
                    EstaEliminado = false,
                    Legajo = entidadNueva.Legajo,
                    FechaIngreso = entidadNueva.FechaIngreso,
                    Apellido = entidadNueva.Apellido,
                    Celular = entidadNueva.Celular,
                    Cuil = entidadNueva.Cuil,
                    Direccion = entidadNueva.Direccion,
                    Dni = entidadNueva.Dni,
                    Email = entidadNueva.Email,
                    FechaNacimiento = entidadNueva.FechaNacimiento,
                    Foto = entidadNueva.Foto,
                    LocalidadId = entidadNueva.LocalidadId,
                    Nombre = entidadNueva.Nombre,
                    Telefono = entidadNueva.Telefono,
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public override void Update(PersonaDto entidad)
        {
            var entidadModificar = (EmpleadoDto) entidad;

            _unidadDeTrabajo.EmpleadoRepositorio.Modificar(new Dominio.Entidades.Empleado
                {
                    Id = entidadModificar.Id,
                    EstaEliminado = false,
                    Legajo = entidadModificar.Legajo,
                    FechaIngreso = entidadModificar.FechaIngreso,
                    Apellido = entidadModificar.Apellido,
                    Celular = entidadModificar.Celular,
                    Cuil = entidadModificar.Cuil,
                    Direccion = entidadModificar.Direccion,
                    Dni = entidadModificar.Dni,
                    Email = entidadModificar.Email,
                    FechaNacimiento = entidadModificar.FechaNacimiento,
                    Foto = entidadModificar.Foto,
                    LocalidadId = entidadModificar.LocalidadId,
                    Nombre = entidadModificar.Nombre,
                    Telefono = entidadModificar.Telefono,
                    RowVersion = entidadModificar.RowVersion
                }
            );

            _unidadDeTrabajo.Commit();
        }

        public override void Delete(PersonaDto entidad)
        {
            var entidadEliminar = (EmpleadoDto)entidad;

            _unidadDeTrabajo.EmpleadoRepositorio.Eliminar(new Dominio.Entidades.Empleado
                {
                    Id = entidadEliminar.Id,
                    EstaEliminado = false,
                    Legajo = entidadEliminar.Legajo,
                    FechaIngreso = entidadEliminar.FechaIngreso,
                    Apellido = entidadEliminar.Apellido,
                    Celular = entidadEliminar.Celular,
                    Cuil = entidadEliminar.Cuil,
                    Direccion = entidadEliminar.Direccion,
                    Dni = entidadEliminar.Dni,
                    Email = entidadEliminar.Email,
                    FechaNacimiento = entidadEliminar.FechaNacimiento,
                    Foto = entidadEliminar.Foto,
                    LocalidadId = entidadEliminar.LocalidadId,
                    Nombre = entidadEliminar.Nombre,
                    Telefono = entidadEliminar.Telefono,
                    RowVersion = entidadEliminar.RowVersion
                }
            );

            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<PersonaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Empleado, bool>> filtro = empleado =>
                !empleado.EstaEliminado && empleado.Apellido.Contains(cadenaBuscar)
                || empleado.Nombre.Contains(cadenaBuscar)
                || empleado.Dni == cadenaBuscar
                || empleado.Cuil == cadenaBuscar;

            return _unidadDeTrabajo.EmpleadoRepositorio.Obtener(filtro, "Localidad, Localidad.Provincia")
                    .Select(x => new EmpleadoDto
                    {
                        Id = x.Id,
                        Legajo = x.Legajo,
                        FechaIngreso =  x.FechaIngreso,
                        Apellido = x.Apellido,
                        Celular = x.Celular,
                        Cuil = x.Cuil,
                        Direccion = x.Direccion,
                        Dni = x.Dni,
                        Email = x.Email,
                        FechaNacimiento = x.FechaNacimiento,
                        Foto = x.Foto,
                        LocalidadId = x.LocalidadId,
                        Localidad = x.Localidad.Descripcion,
                        ProvinciaId = x.Localidad.ProvinciaId,
                        Provincia = x.Localidad.Provincia.Descripcion,
                        Nombre = x.Nombre,
                        Telefono = x.Telefono,
                        EstaEliminado = x.EstaEliminado,
                        RowVersion = x.RowVersion
                    }).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList();
        }

        public override PersonaDto GetById(long id)
        {
            var empleado = _unidadDeTrabajo.EmpleadoRepositorio.Obtener(id, "Localidad, Localidad.Provincia");

            return new EmpleadoDto
            {
                Id = empleado.Id,
                Legajo = empleado.Legajo,
                FechaIngreso = empleado.FechaIngreso,
                Apellido = empleado.Apellido,
                Celular = empleado.Celular,
                Cuil = empleado.Cuil,
                Direccion = empleado.Direccion,
                Dni = empleado.Dni,
                Email = empleado.Email,
                FechaNacimiento = empleado.FechaNacimiento,
                Foto = empleado.Foto,
                LocalidadId = empleado.LocalidadId,
                Localidad = empleado.Localidad.Descripcion,
                ProvinciaId = empleado.Localidad.ProvinciaId,
                Provincia = empleado.Localidad.Provincia.Descripcion,
                Nombre = empleado.Nombre,
                Telefono = empleado.Telefono,
                EstaEliminado = empleado.EstaEliminado,
                RowVersion = empleado.RowVersion
            };
        }
    }
}