namespace Servicio.Implementacion.Comprobante
{
    using Servicio.Interfaces.Comprobante;
    using Servicio.Interfaces.Comprobante.DTOs;
    using System;
    using System.Collections.Generic;

    public class ComprobanteServicio: IComprobanteServicio
    {
        private Dictionary<Type, string> _diccionario;

        public ComprobanteServicio()
        {
            _diccionario = new Dictionary<Type, string>();
            InicializarDiccionario();
        }

        

        public IEnumerable<ComprobanteDto> Get(Type tipo)
        {
            var c = InstanciarComprobantePorTipo(tipo);
            return c.Get();
        }

        public ComprobanteDto GetById(Type tipo, long id)
        {
            var c = InstanciarComprobantePorTipo(tipo);
            return c.GetById(id);
        }

        public void Grabar(ComprobanteDto entidad)
        {
            var c = InstanciaComprobante(entidad);
            c.Grabar(entidad);            
        }

        private void InicializarDiccionario()
        {
            _diccionario.Add(typeof(ComprobanteDto), "Servicio.Implementacion.Comprobante.Comprobante");
            _diccionario.Add(typeof(FacturaDto), "Servicio.Implementacion.Comprobante.Factura");
            _diccionario.Add(typeof(NotaCreditoDto), "Servicio.Implementacion..Comprobante.NotaCredito");
            _diccionario.Add(typeof(PresupuestoDto), "Servicio.Implementacion..Comprobante.Presupuesto");
            _diccionario.Add(typeof(RemitoDto), "Servicio.Implementacion.Comprobante.Remito");
            _diccionario.Add(typeof(CompraDto), "Servicio.Implementacion.Comprobante.Compra");
        }
        private Comprobante InstanciarEntidad(string tipoEntidad)
        {
            var tipoObjeto = Type.GetType(tipoEntidad);

            if (tipoObjeto == null) return null;

            var entidad = Activator.CreateInstance(tipoObjeto) as Comprobante;

            return entidad;
        }

        private Comprobante InstanciaComprobante(ComprobanteDto entidad)
        {
            if (!_diccionario.TryGetValue(entidad.GetType(), out var tipoEntidad))
                throw new Exception($"No hay {entidad.GetType()} para Instanciar.");

            var comprobante = InstanciarEntidad(tipoEntidad);

            if (comprobante == null) throw new Exception($"Ocurrió un error al Instanciar {entidad.GetType()}");

            return comprobante;
        }

        private Comprobante InstanciarComprobantePorTipo(Type tipo)
        {
            if (!_diccionario.TryGetValue(tipo, out var tipoEntidad))
                throw new Exception($"No hay {tipoEntidad} para Instanciar.");

            var comprobante = InstanciarEntidad(tipoEntidad);

            if (comprobante == null) throw new Exception($"Ocurrió un error al Instanciar {tipo}");

            return comprobante;
        }
    }
}
