using Servicio.Interfaces.DetalleComprobante.DTOs;

namespace Servicio.Implementacion.Comprobante
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Comprobante;
    using Servicio.Interfaces.Comprobante.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class FacturaServicio: ComprobanteServicio, IFacturaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        public FacturaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public IEnumerable<FacturaDto> ObtenerPendientesDePagos()
        {
            Expression<Func<Dominio.Entidades.Factura, bool>> filtro =
                f => !f.EstaEliminado && f.EstadoComprobante == Aplicacion.Constantes.Clases.EstadoComprobante.Pendiente;

            return _unidadDeTrabajo.FacturaRepositorio.Obtener(filtro, "DetalleComprobantes, Cliente, Cliente.CondicionIva, Empleado")
                .Select(x => new FacturaDto
                {
                    EstaEliminado = x.EstaEliminado,
                    ClienteFacturaId = x.ClienteId,
                    ApellidoCliente = x.Cliente.Apellido,
                    Descuento = x.Descuento,
                    DniCliente = x.Cliente.Dni,
                    EmpleadoId = x.EmpleadoId,
                    EstadoComprobante = x.EstadoComprobante,
                    Fecha = x.Fecha,
                    Id = x.Id,
                    Iva105 = x.Iva105,
                    Iva21 = x.Iva21,
                    NombreCliente = x.Cliente.Nombre,
                    Numero = x.Numero,
                    SubTotal = x.SubTotal,
                    TipoComprobante = x.TipoComprobante,
                    Total = x.Total,
                    UsuarioId = x.UsuarioId,
                    RowVersion = x.RowVersion,
                    Items = x.DetalleComprobantes.Select(c => new DetalleComprobanteDto
                    {
                        EstaEliminado = c.EstaEliminado,
                        Descripcion = c.Descripcion,
                        RowVersion = c.RowVersion,
                        ArticuloId = c.ArticuloId,
                        Cantidad = c.Cantidad,
                        Codigo = c.Codigo,
                        ComprobanteId = c.ComprobanteId,
                        Iva = c.Iva,
                        Precio = c.Precio,
                        SubTotal = c.SubTotal,
                        Id = c.Id
                    }).ToList()
                }).OrderBy(x => x.Fecha).ToList();
        }
    }
}
