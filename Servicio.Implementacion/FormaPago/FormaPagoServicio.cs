namespace Servicio.Implementacion.FormaPago
{
    using Servicio.Interfaces.FormaPago;
    using Servicio.Interfaces.FormaPago.DTOs;
    using System;
    using System.Collections.Generic;

    public class FormaPagoServicio: IFormaPagoServicio
    {
        private Dictionary<Type, string> _diccionario;

        public FormaPagoServicio()
        {
            _diccionario = new Dictionary<Type, string>();
            InicializarDiccionario();
        }

        public void Grabar(FormaPagoDto entidad)
        {
            var c = Instancia(entidad);
            c.Grabar(entidad);
        }

        public IEnumerable<FormaPagoDto> Get(Type tipo, string cadenaBuscar)
        {
            var c = InstanciarPorTipo(tipo);
            return c.Get();
        }

        public FormaPagoDto GetById(Type tipo, long id)
        {
            var c = InstanciarPorTipo(tipo);
            return c.GetById(id);
        }

        //========================================================================================
        private void InicializarDiccionario()
        {
            _diccionario.Add(typeof(FormaPagoCtaCteDto), "Servicio.Implementacion.FormaPago.FormaPagoCtaCte");
            _diccionario.Add(typeof(FormaPagoTarjetaDto), "Servicio.Implementacion.FormaPago.FormaPagoTarjeta");
            _diccionario.Add(typeof(FormaPagoChequeDto), "Servicio.Implementacion.FormaPago.FormaPagoCheque");
            _diccionario.Add(typeof(FormaPagoEfectivoDto), "Servicio.Implementacion.FormaPago.FormaPagoEfectivo");

        }

        private FormaPago InstanciarEntidad(string tipoEntidad)
        {
            var tipoObjeto = Type.GetType(tipoEntidad);

            if (tipoObjeto == null) return null;

            var entidad = Activator.CreateInstance(tipoObjeto) as FormaPago;

            return entidad;
        }

        private FormaPago Instancia(FormaPagoDto entidad)
        {
            if (!_diccionario.TryGetValue(entidad.GetType(), out var tipoEntidad))
                throw new Exception($"No hay {entidad.GetType()} para Instanciar.");

            var f = InstanciarEntidad(tipoEntidad);

            if (f == null) throw new Exception($"Ocurrió un error al Instanciar {entidad.GetType()}");

            return f;
        }

        private FormaPago InstanciarPorTipo(Type tipo)
        {
            if (!_diccionario.TryGetValue(tipo, out var tipoEntidad))
                throw new Exception($"No hay {tipoEntidad} para Instanciar.");

            var f = InstanciarEntidad(tipoEntidad);

            if (f == null) throw new Exception($"Ocurrió un error al Instanciar {tipo}");

            return f;
        }

        
    }
}
