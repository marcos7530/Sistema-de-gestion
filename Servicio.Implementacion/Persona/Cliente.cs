namespace Servicio.Implementacion.Persona
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using Servicio.Interfaces.Persona.DTOs;
    using StructureMap;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.MOvimientoCuentaCorriente.DTOs;

    public class Cliente : Persona
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public Cliente()
        {
            _unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
        }

        public override long Add(PersonaDto entidad)
        {
            var entidadNueva = (ClienteDto)entidad;

            var entidadId = _unidadDeTrabajo.ClienteRepositorio.Insertar(new Dominio.Entidades.Cliente
                {
                    EstaEliminado = false,
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
                    ActivarCtaCte = entidadNueva.ActivarCtaCte,
                    CondicionIvaId = entidadNueva.CondicionIvaId,
                    Monto = entidadNueva.Monto,
                    TieneLimiteCompra = entidadNueva.TieneLimiteCompra,
                }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public override void Update(PersonaDto entidad)
        {
            var entidadModificar = (ClienteDto)entidad;

            _unidadDeTrabajo.ClienteRepositorio.Modificar(new Dominio.Entidades.Cliente
                {
                    Id = entidadModificar.Id,
                    EstaEliminado = false,
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
                    ActivarCtaCte = entidadModificar.ActivarCtaCte,
                    CondicionIvaId = entidadModificar.CondicionIvaId,
                    Monto = entidadModificar.Monto,
                    TieneLimiteCompra = entidadModificar.TieneLimiteCompra,
                    RowVersion = entidadModificar.RowVersion
                }
            );

            _unidadDeTrabajo.Commit();
        }

        public override void Delete(PersonaDto entidad)
        {
            var entidadEliminar = (ClienteDto)entidad;

            _unidadDeTrabajo.ClienteRepositorio.Eliminar(new Dominio.Entidades.Cliente
                {
                    Id = entidadEliminar.Id,
                    EstaEliminado = false,
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
                    ActivarCtaCte = entidadEliminar.ActivarCtaCte,
                    CondicionIvaId = entidadEliminar.CondicionIvaId,
                    Monto = entidadEliminar.Monto,
                    TieneLimiteCompra = entidadEliminar.TieneLimiteCompra,
                    RowVersion = entidadEliminar.RowVersion
                }
            );

            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<PersonaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = Cliente =>
                !Cliente.EstaEliminado && Cliente.Apellido.Contains(cadenaBuscar)
                || Cliente.Nombre.Contains(cadenaBuscar)
                || Cliente.Dni == cadenaBuscar
                || Cliente.Cuil == cadenaBuscar;

            return _unidadDeTrabajo.ClienteRepositorio.Obtener(filtro, "Localidad, Localidad.Provincia, CondicionIva")
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
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
                        CondicionIva = x.CondicionIva.Descripcion,
                        Monto = x.Monto,
                        TieneLimiteCompra = x.TieneLimiteCompra,
                        ActivarCtaCte = x.ActivarCtaCte,
                        CondicionIvaId = x.CondicionIvaId,
                        RowVersion = x.RowVersion
                    }).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                    .ToList();
        }

        public override PersonaDto GetById(long id)
        {
            var Cliente = _unidadDeTrabajo.ClienteRepositorio.Obtener(id, "Localidad, Localidad.Provincia, CondicionIva");

            return new ClienteDto
            {
                Id = Cliente.Id,
                Apellido = Cliente.Apellido,
                Celular = Cliente.Celular,
                Cuil = Cliente.Cuil,
                Direccion = Cliente.Direccion,
                Dni = Cliente.Dni,
                Email = Cliente.Email,
                FechaNacimiento = Cliente.FechaNacimiento,
                Foto = Cliente.Foto,
                LocalidadId = Cliente.LocalidadId,
                Localidad = Cliente.Localidad.Descripcion,
                ProvinciaId = Cliente.Localidad.ProvinciaId,
                Provincia = Cliente.Localidad.Provincia.Descripcion,
                Nombre = Cliente.Nombre,
                Telefono = Cliente.Telefono,
                EstaEliminado = Cliente.EstaEliminado,
                CondicionIva = Cliente.CondicionIva.Descripcion,
                Monto = Cliente.Monto,
                TieneLimiteCompra = Cliente.TieneLimiteCompra,
                ActivarCtaCte = Cliente.ActivarCtaCte,
                CondicionIvaId = Cliente.CondicionIvaId,
                RowVersion = Cliente.RowVersion,
                Movimientos = _unidadDeTrabajo.MovimientoCuentaCorrienteRepositorio.Obtener(x => x.ClienteId == Cliente.Id)
                               .Select(x => new MovimientoCuentaCorrienteDto
                               {
                                   ComprobanteId = x.ComprobanteId,
                                   UsuarioId = x.UsuarioId,
                                   ClienteId = x.ClienteId,
                                   Descripcion = x.Descripcion,
                                   Monto = x.Monto,
                                   Fecha = x.Fecha,
                                   TipoMovimiento = x.TipoMovimiento
                               }).ToList()
            };
        }
    }
}
