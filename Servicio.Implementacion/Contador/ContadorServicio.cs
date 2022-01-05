using Aplicacion.Constantes.Clases;
using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.Contador;
using Servicio.Interfaces.Contador.DTOs;
using System.Linq;

namespace Servicio.Implementacion.Contador
{
    public class ContadorServicio: IContadorServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ContadorServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Grabar(ContadorDto dto)
        {
            _unidadDeTrabajo.ContadorRepositorio.Insertar(new Dominio.Entidades.Contador
            {
                EstaEliminado = false,
                TipoComprobante = dto.TipoComprobante,
                Valor = dto.Valor
            });
            _unidadDeTrabajo.Commit();
        }

        public int ObtenerSiguienteNumeroComprobante(TipoComprobante tipoComprobante)
        {
            if (_unidadDeTrabajo.ContadorRepositorio.Obtener(x => x.TipoComprobante == tipoComprobante).Any())
                return _unidadDeTrabajo.ContadorRepositorio.Obtener(x => x.TipoComprobante == tipoComprobante).Max(v => v.Valor) + 1;
            return 1;
        }
    }
}
