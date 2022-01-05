namespace Servicio.Implementacion.Caja
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Caja;
    using Servicio.Interfaces.Caja.DTOs;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Interfaces.DetalleCaja.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CajaServicio: ICajaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IConfiguracionServicio _configuracionServicio;

        public CajaServicio(IUnidadDeTrabajo unidadDeTrabajo,
                            IConfiguracionServicio configuracionServicio)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _configuracionServicio = configuracionServicio;
        }

        public long AbrirCaja(CajaAperturaDto cajaInicial)
        {
            long c = _unidadDeTrabajo.CajaRepositorio.Insertar(new Dominio.Entidades.Caja
            {
                UsuarioAperturaId = cajaInicial.UsuarioAperturaId,
                MontoInicial = cajaInicial.MontoInicial,
                FechaApertura = cajaInicial.FechaApertura,
                EstaEliminado = false,
                TotalChequeEntrada = 0m,
                TotalCuentaCorrienteEntrada = 0m,
                TotalSalidaCompras = 0m,
                TotalTarjetaEntrada = 0m,
                TotalSalidaNotaCreditos = 0m,
                TotalCobranzaEfectivo = 0m,
                TotalSalidaGastos = 0m,
                TotalVentaEfectivo = 0m,
                TotalCuentaCorrienteSalida = 0m,
                TotalTarjetaSalida = 0m,
                TotalChequeSalida = 0m
            });
            _unidadDeTrabajo.Commit();
            return c;
        }

        public void ActualizarCaja(CajaDto caja)
        {
            var cajaActualizar = _unidadDeTrabajo.CajaRepositorio.Obtener(caja.Id);

            cajaActualizar.TotalChequeEntrada = caja.TotalChequeEntrada;
            cajaActualizar.TotalCuentaCorrienteEntrada = caja.TotalCuentaCorrienteEntrada;
            cajaActualizar.TotalSalidaCompras = caja.TotalSalidaCompras;
            cajaActualizar.TotalTarjetaEntrada = caja.TotalTarjetaEntrada;
            cajaActualizar.TotalSalidaNotaCreditos = caja.TotalSalidaNotaCreditos;
            cajaActualizar.TotalCobranzaEfectivo = caja.TotalCobranzaEfectivo;
            cajaActualizar.TotalSalidaGastos = caja.TotalSalidaGastos;
            cajaActualizar.TotalVentaEfectivo = caja.TotalVentaEfectivo;
            cajaActualizar.TotalCuentaCorrienteSalida = caja.TotalCuentaCorrienteSalida;
            cajaActualizar.TotalTarjetaSalida = caja.TotalTarjetaSalida;
            cajaActualizar.TotalChequeSalida = caja.TotalChequeSalida;
            _unidadDeTrabajo.CajaRepositorio.Modificar(cajaActualizar);
            _unidadDeTrabajo.Commit();
        }

        public void CerrarCaja(CajaDto caja)
        {
            var cajaCerrar = _unidadDeTrabajo.CajaRepositorio.Obtener(caja.Id);
            
            cajaCerrar.FechaCierre = DateTime.Now;

            cajaCerrar.UsuarioCierreId = caja.UsuarioCierreId;
            cajaCerrar.MontoCierre = caja.MontoCierre;
                        
            _unidadDeTrabajo.CajaRepositorio.Modificar(cajaCerrar);
            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<CajaDto> Get(DateTime fechaDesde, DateTime fechaHasta, string cadenaBuscar)
        {
            var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

            Expression<Func<Dominio.Entidades.Caja, bool>> filtro = caja =>
                !caja.EstaEliminado
                && caja.FechaApertura >= fechaDesde && caja.FechaApertura <= _fechaHasta;

            var listaCajas = _unidadDeTrabajo.CajaRepositorio.Obtener(filtro,
                "UsuarioApertura, UsuarioApertura.Empleado, UsuarioCierre, UsuarioCierre.Empleado, DetalleCajas, Movimientos");


            try
            {
                return listaCajas.Select(x => new CajaDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    UsuarioAperturaId = x.UsuarioAperturaId,
                    UsuarioApertura = x.UsuarioApertura.Nombre,
                    ApellidoEmpleadoApertura = x.UsuarioApertura.Empleado.Apellido,
                    NombreEmpleadoApertura = x.UsuarioApertura.Empleado.Nombre,

                    MontoInicial = x.MontoInicial,
                    FechaApertura = x.FechaApertura,
                    FechaCierre = x.FechaCierre,
                   
                    MontoCierre = x.MontoCierre,
                    TotalVentaEfectivo = x.TotalVentaEfectivo,
                    TotalCobranzaEfectivo = x.TotalCobranzaEfectivo,
                    TotalSalidaCompras = x.TotalSalidaCompras,
                    TotalSalidaGastos = x.TotalSalidaGastos,
                    TotalSalidaNotaCreditos = x.TotalSalidaNotaCreditos,
                    TotalTarjetaEntrada = x.TotalTarjetaEntrada,
                    TotalChequeEntrada = x.TotalChequeEntrada,
                    TotalCuentaCorrienteEntrada = x.TotalCuentaCorrienteEntrada,
                    TotalTarjetaSalida = x.TotalTarjetaSalida,
                    TotalChequeSalida = x.TotalChequeSalida,
                    TotalCuentaCorrienteSalida = x.TotalCuentaCorrienteSalida,
                    RowVersion = x.RowVersion,

                    UsuarioCierreId = x.UsuarioCierreId,
                    UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : string.Empty,
                    ApellidoEmpleadoCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Empleado.Apellido : "--",
                    NombreEmpleadoCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Empleado.Nombre : "--",
                   
                    DetalleCajas = x.DetalleCajas.Select(d => new DetalleCajaDto
                    {
                        Id = d.Id,
                        EstaEliminado = d.EstaEliminado,
                        RowVersion = d.RowVersion,
                        Monto = d.Monto,
                        TipoPago = d.TipoPago
                    }).ToList()
                }).ToList();

            }
            catch { return null; }
        }

        public IEnumerable<CajaDto> GetCajas()
        {
            Expression<Func<Dominio.Entidades.Caja, bool>> filtro = caja =>
                !caja.EstaEliminado;

            var listaCajas = _unidadDeTrabajo.CajaRepositorio.Obtener(filtro,
                "UsuarioApertura, UsuarioApertura.Empleado, UsuarioCierre, UsuarioCierre.Empleado, DetalleCajas, Movimientos");
            
            try
            {
                return listaCajas.Select(x => new CajaDto
                {
                    Id = x.Id,
                    EstaEliminado = x.EstaEliminado,
                    UsuarioAperturaId = x.UsuarioAperturaId,
                    UsuarioApertura = x.UsuarioApertura.Nombre,
                    ApellidoEmpleadoApertura = x.UsuarioApertura.Empleado.Apellido,
                    NombreEmpleadoApertura = x.UsuarioApertura.Empleado.Nombre,

                    MontoInicial = x.MontoInicial,
                    FechaApertura = x.FechaApertura,
                    FechaCierre = x.FechaCierre,

                    MontoCierre = x.MontoCierre,
                    TotalVentaEfectivo = x.DetalleCajas.Where(z=>z.TipoPago == Aplicacion.Constantes.Clases.TipoPago.Efectivo).Sum(y=>y.Monto),
                    TotalCobranzaEfectivo = x.TotalCobranzaEfectivo,
                    TotalSalidaCompras = x.TotalSalidaCompras,
                    TotalSalidaGastos = x.TotalSalidaGastos,
                    TotalSalidaNotaCreditos = x.TotalSalidaNotaCreditos,
                    TotalTarjetaEntrada = x.TotalTarjetaEntrada,
                    TotalChequeEntrada = x.TotalChequeEntrada,
                    TotalCuentaCorrienteEntrada = x.TotalCuentaCorrienteEntrada,
                    TotalTarjetaSalida = x.TotalTarjetaSalida,
                    TotalChequeSalida = x.TotalChequeSalida,
                    TotalCuentaCorrienteSalida = x.TotalCuentaCorrienteSalida,
                    RowVersion = x.RowVersion,

                    UsuarioCierreId = x.UsuarioCierreId,
                    UsuarioCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Nombre : string.Empty,
                    ApellidoEmpleadoCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Empleado.Apellido : "--",
                    NombreEmpleadoCierre = x.UsuarioCierreId.HasValue ? x.UsuarioCierre.Empleado.Nombre : "--",

                    DetalleCajas = x.DetalleCajas.Select(d => new DetalleCajaDto
                    {
                        Id = d.Id,
                        EstaEliminado = d.EstaEliminado,
                        RowVersion = d.RowVersion,
                        Monto = d.Monto,
                        TipoPago = d.TipoPago
                    }).ToList()
                }).ToList();

            }
            catch { return null; }
        }

        public long ObtenerUltimaCajaSinCerrar()
        {
            var cajas = _unidadDeTrabajo.CajaRepositorio.Obtener(x => x.EstaEliminado == false, "UsuarioApertura, UsuarioCierre, DetalleCajas, Movimientos");
            if (cajas != null)
            {
                var ultimaCajaSinCerrar = cajas.FirstOrDefault(x => x.FechaCierre == null);
                return ultimaCajaSinCerrar != null ? ultimaCajaSinCerrar.Id : 0;
                
            }
            else
                return 0;
        }
    }
}
