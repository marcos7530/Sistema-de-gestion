namespace Servicio.Implementacion.FormaPago
{
    using System.Collections.Generic;
    using System.Linq;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.FormaPago.DTOs;

    public class FormaPagoEfectivo: FormaPago
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public FormaPagoEfectivo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public override void Grabar(FormaPagoDto entidad)
        {
            _unidadDeTrabajo.FormaPagoEfectivoRepositorio.Insertar(
                new Dominio.Entidades.FormaPagoEfectivo
                {
                    ComprobanteId = entidad.ComprobanteId,
                    TipoPago = entidad.TipoPago,
                    Monto = entidad.Monto,
                    EstaEliminado = false
                });
            _unidadDeTrabajo.Commit();
        }

        public override IEnumerable<FormaPagoDto> Get()
        {
            return _unidadDeTrabajo.FormaPagoEfectivoRepositorio.Obtener(x => x.EstaEliminado == false, "Comprobante")
                .Select(x => new FormaPagoEfectivoDto
                {
                    Id = x.Id,
                    ComprobanteId = x.ComprobanteId,
                    TipoPago = x.TipoPago,
                    Monto = x.Monto,
                    EstaEliminado = x.EstaEliminado,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public override FormaPagoDto GetById(long entidadId)
        {
            var x = _unidadDeTrabajo.FormaPagoEfectivoRepositorio.Obtener(entidadId, "Comprobante");
            return new FormaPagoEfectivoDto
            {
                Id = x.Id,
                ComprobanteId = x.ComprobanteId,
                TipoPago = x.TipoPago,
                Monto = x.Monto,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion
            };
        }
    }
}
