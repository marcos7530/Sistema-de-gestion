namespace Servicio.Interfaces.Caja
{
    using Servicio.Interfaces.Caja.DTOs;
    using System;
    using System.Collections.Generic;

    public interface ICajaServicio
    {
        //CajaDto Get(long cajaId);

        long AbrirCaja(CajaAperturaDto cajaInicial );

        IEnumerable<CajaDto> Get(DateTime fechaDesde, DateTime fechaHasta, string cadenaBuscar);

        IEnumerable<CajaDto> GetCajas();

        void CerrarCaja(CajaDto caja);

        void ActualizarCaja(CajaDto caja);

        long ObtenerUltimaCajaSinCerrar();
    }
}
