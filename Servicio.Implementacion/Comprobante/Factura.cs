namespace Servicio.Implementacion.Comprobante
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Transactions;
    using Aplicacion.Constantes.Clases;
    using Dominio.Entidades;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Comprobante.DTOs;
    using Servicio.Interfaces.Configuracion;
    using Servicio.Interfaces.FormaPago;
    using Servicio.Interfaces.FormaPago.DTOs;
    using StructureMap;

    public class Factura: Comprobante
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly IArticuloServicio _articuloServicio;
        private readonly IFormaPagoTarjetaServicio _formaPagoTarjetaServicio;
        private readonly IFormaPagoCtaCteServicio _formaPagoCtaCteServicio;
        private readonly IFormaPagoChequeServicio _formaPagoChequeServicio;

        public Factura()
        {
            _unidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            _formaPagoChequeServicio = ObjectFactory.GetInstance<IFormaPagoChequeServicio>();
            _formaPagoCtaCteServicio = ObjectFactory.GetInstance<IFormaPagoCtaCteServicio>();
            _formaPagoTarjetaServicio = ObjectFactory.GetInstance<IFormaPagoTarjetaServicio>();
        }

        public override void Grabar(ComprobanteDto entidad)
        {            
            using (var t = new TransactionScope())
            {
                var f = (FacturaDto)entidad;
                var config = _configuracionServicio.Get();
                if (config == null)
                {
                    throw new Exception("Ocurrio un error al Obtener la Configuracion del Sistema.");
                }
                var facturaNueva = _unidadDeTrabajo.FacturaRepositorio.Obtener(entidad.Id);
                if (facturaNueva == null)
                {
                    facturaNueva = new Dominio.Entidades.Factura
                    {
                        TipoComprobante = f.TipoComprobante,
                        EstaEliminado = f.EstaEliminado,
                        ClienteId = f.ClienteFacturaId,
                        Descuento = f.Descuento,
                        EstadoComprobante = EstadoComprobante.Pendiente,
                        Fecha = f.Fecha,
                        Numero = f.Numero,
                        UsuarioId = f.UsuarioId,
                        SubTotal = f.SubTotal,
                        Total = f.Total,
                        EmpleadoId = f.EmpleadoId,
                        Iva105 = f.Iva105,
                        Iva21 = f.Iva21
                                               
                    };
                    facturaNueva.DetalleComprobantes = new List<DetalleComprobante>();

                    foreach (var item in f.Items)
                    {
                        var articulo = _unidadDeTrabajo.ArticuloRepositorio.Obtener(item.ArticuloId);
                        /*
                        if (HoraVenta.Validar(articulo.ActivarHoraVenta, articulo.HoraLimiteVentaInicio, articulo.HoraLimiteVentaFin))
                        {
                            throw new Exception(
                                $@"No es posible vender {articulo.Descripcion} a esta hora.");
                        }*/
                        facturaNueva.Id = f.Id;
                        facturaNueva.DetalleComprobantes.Add(new DetalleComprobante
                        {
                            EstaEliminado = false,
                            ArticuloId = item.ArticuloId,
                            ComprobanteId = item.ComprobanteId,
                            Cantidad = item.Cantidad,
                            Codigo = item.Codigo,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            SubTotal = item.SubTotal,
                            Iva = item.Iva
                        });

                        if (!config.FacturaDescuentaStock) continue;

                        if (articulo.Stock >= item.Cantidad)
                        {
                            articulo.Stock -= item.Cantidad;
                        }
                        else
                        {
                            if (articulo.PermiteStockNegativo)
                                articulo.Stock -= item.Cantidad;
                        }
                    }
                    _unidadDeTrabajo.FacturaRepositorio.Insertar(facturaNueva);
                }
                else
                {
                    f.EstadoComprobante = EstadoComprobante.Pagado;
                }

                if (f.EstadoComprobante == EstadoComprobante.Pagado)
                {
                    facturaNueva.EstadoComprobante =EstadoComprobante.Pagado;

                    facturaNueva.Movimientos = new List<Movimiento>();
                    facturaNueva.FormaPagos = new List<FormaPago>();

                    var caja = _unidadDeTrabajo.CajaRepositorio.Obtener(entidad.CajaId, "UsuarioApertura, UsuarioCierre, DetalleCajas, Movimientos");
                    if (caja == null)
                        throw new Exception("error recuperando la caja");

                    //----Formas de pago----------------pago-con-efectivo--------------------------
                    if (entidad.PagoEfectivoDto != null && entidad.PagoEfectivoDto.Monto > 0)
                    {
                        facturaNueva.FormaPagos.Add(new FormaPagoEfectivo
                        {
                            ComprobanteId = facturaNueva.Id,
                            EstaEliminado = false,
                            ClienteId = f.ClienteFacturaId,
                            Monto = entidad.PagoEfectivoDto.Monto,
                            TipoPago = entidad.PagoEfectivoDto.TipoPago
                        });

                        caja.DetalleCajas.Add(new DetalleCaja
                        {
                            EstaEliminado = false,
                            CajaId = f.CajaId,
                            Monto = entidad.PagoEfectivoDto.Monto,
                            TipoPago = TipoPago.Efectivo
                        });
                    }

                    //-----------------------------------Pago-con-cheque---------------------------
                    if (entidad.PagoChequeDto != null && entidad.PagoChequeDto.Monto > 0)
                    {
                        facturaNueva.FormaPagos.Add(new Dominio.Entidades.FormaPagoCheque
                        {
                            EstaEliminado = false,
                            Monto = entidad.PagoChequeDto.Monto,
                            TipoPago = entidad.PagoChequeDto.TipoPago,
                            Cheque = new Cheque
                            {
                                EstaEliminado = false,
                                Numero = f.PagoChequeDto.Numero,
                                BancoId = f.PagoChequeDto.BancoId,
                                ClienteId = f.PagoChequeDto.ClienteId,
                                EstaRechazado = false,
                                FechaVencimiento = f.PagoChequeDto.FechaVencimiento
                            }
                        });

                        caja.DetalleCajas.Add(new DetalleCaja
                        {
                            CajaId = entidad.CajaId,
                            EstaEliminado = false,
                            Monto = entidad.PagoChequeDto.Monto,
                            TipoPago = TipoPago.Cheque
                        });
                    }

                    //----------------------------Pago-a-cuenta-corriente-------------------------------------
                    if (entidad.PagoCtaCteDto != null && entidad.PagoCtaCteDto.Monto > 0)
                    {
                        var clienteSeleccionado = _unidadDeTrabajo.ClienteRepositorio.Obtener(f.ClienteFacturaId);
                        if (!clienteSeleccionado.ActivarCtaCte)
                            throw new Exception($"{clienteSeleccionado.Apellido}, {clienteSeleccionado.Nombre} no tiene una cuenta corriente Activa");
                        
                        if (clienteSeleccionado.TieneLimiteCompra)
                        {
                            var movimientos = _unidadDeTrabajo.MovimientoCtaCteRepositorio.Obtener(x => x.ClienteId == f.ClienteFacturaId);

                            decimal deuda = movimientos.Any()
                                ? movimientos.Where(x => x.TipoMovimiento == TipoMovimiento.Ingreso).Sum(x => x.Monto)
                                    - movimientos.Where(x => x.TipoMovimiento == TipoMovimiento.Egreso).Sum(x => x.Monto)
                                : 0;

                            if (deuda + entidad.PagoCtaCteDto.Monto > clienteSeleccionado.Monto)
                                throw new Exception($"{clienteSeleccionado.Apellido}, " +
                                    $"{clienteSeleccionado.Nombre} tiene un limite de Monto de {clienteSeleccionado.Monto.ToString("C")}");
                        }
                        facturaNueva.FormaPagos.Add(new Dominio.Entidades.FormaPagoCtaCte
                        {
                            EstaEliminado = false,
                            ClienteId = f.ClienteFacturaId,
                            Monto = f.PagoCtaCteDto.Monto,
                            TipoPago = f.PagoCtaCteDto.TipoPago,
                            ComprobanteId = facturaNueva.Id,
                        });

                        caja.DetalleCajas.Add(new DetalleCaja
                        {
                            CajaId = entidad.CajaId,
                            EstaEliminado = false,
                            Monto = entidad.PagoCtaCteDto.Monto,
                            TipoPago = TipoPago.CtaCte
                        });
                        _unidadDeTrabajo.MovimientoCtaCteRepositorio.Insertar(new MovimientoCuentaCorriente
                        {
                            EstaEliminado = false,
                            ClienteId = f.ClienteFacturaId,
                            ComprobanteId = facturaNueva.Id,
                            Descripcion = $"{f.TipoComprobante} - Nro: {f.Numero} - Total: {f.Total.ToString("C")}",
                            Fecha = DateTime.Now,
                            Monto = entidad.PagoCtaCteDto.Monto,
                            TipoMovimiento = TipoMovimiento.Ingreso,
                            UsuarioId = f.UsuarioId
                        }) ;
                    }

                    //------------------pago-con-tarjeta---------------------------------------------------
                    if (entidad.PagoTarjetaDto != null && entidad.PagoTarjetaDto.Monto > 0)
                    {
                        //_formaPagoTarjetaServicio.Grabar(f.PagoTarjetaDto);
                        facturaNueva.FormaPagos.Add(new Dominio.Entidades.FormaPagoTarjeta
                        {
                            ComprobanteId = facturaNueva.Id,
                            EstaEliminado = false,
                            Monto = f.PagoTarjetaDto.Monto,
                            TipoPago = f.PagoTarjetaDto.TipoPago,
                            CantidadCuotas = f.PagoTarjetaDto.CantidadCuotas,
                            CuponPago = f.PagoTarjetaDto.CuponPago,
                            NumeroTarjeta = f.PagoTarjetaDto.NumeroTarjeta,
                            TarjetaId = f.PagoTarjetaDto.TarjetaId
                            
                        });

                        caja.DetalleCajas.Add(new DetalleCaja
                        {
                            EstaEliminado = false,
                            CajaId = f.CajaId,
                            Monto = entidad.PagoTarjetaDto.Monto,
                            TipoPago = TipoPago.Tarjeta
                        });
                    }

                    //--------------movimiento----------------
                    facturaNueva.Movimientos.Add(new Movimiento
                    {
                        EstaEliminado = false,
                        ComprobanteId = entidad.Id,
                        CajaId = f.CajaId,
                        Fecha = f.Fecha,
                        Monto = f.Total,
                        TipoMovimiento = TipoMovimiento.Ingreso,
                        UsuarioId = f.UsuarioId,
                        Descripcion = $"{f.TipoComprobante} - Nro: {f.Numero} - Total: {f.Total.ToString("C")}"
                    });
                    
                    _unidadDeTrabajo.FacturaRepositorio.Modificar(facturaNueva);
                }              

                _unidadDeTrabajo.Commit();
                t.Complete();
                
            }
        }

        public override IEnumerable<ComprobanteDto> Get()
        {
            return _unidadDeTrabajo.FacturaRepositorio.Obtener(x => x.EstaEliminado == false, "")
                .Select(x => new FacturaDto
                {
                    Id = x.Id,
                    EmpleadoId = x.EmpleadoId,
                    UsuarioId = x.UsuarioId,
                    Fecha = x.Fecha,
                    Numero = x.Numero,
                    SubTotal = x.SubTotal,
                    Descuento = x.Descuento,
                    Total = x.Total,
                    TipoComprobante = x.TipoComprobante,
                    EstadoComprobante = x.EstadoComprobante,
                    Iva105 = x.Iva105,
                    Iva21 = x.Iva21,
                    ClienteFacturaId = x.ClienteId,
                    RowVersion = x.RowVersion
                }).ToList();
        }

        public override ComprobanteDto GetById(long entidadId)
        {
            var e = _unidadDeTrabajo.FacturaRepositorio.Obtener(entidadId, "Cliente, Usuario");

            return new FacturaDto
            {
                Id = e.Id,
                RowVersion = e.RowVersion,
                EmpleadoId = e.EmpleadoId,
                NombreEmpleado = e.Empleado.Nombre,
                ApellidoEmpleado = e.Empleado.Apellido,

                EstaEliminado = false,
                ClienteFacturaId = e.ClienteId,
                NombreCliente = e.Cliente.Nombre,
                ApellidoCliente = e.Cliente.Apellido,
                UsuarioId = e.UsuarioId,
                NombreUsuario = e.Usuario.Nombre,
                Fecha = e.Fecha,
                Numero = e.Numero,

                SubTotal = e.SubTotal,

                Descuento = e.Descuento,
                Total = e.Total,

                TipoComprobante = e.TipoComprobante,
                EstadoComprobante = e.EstadoComprobante,
                Iva105 = e.Iva105,
                Iva21 = e.Iva21
            };
        }

    }
}
