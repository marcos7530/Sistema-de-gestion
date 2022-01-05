namespace Servicio.Implementacion.Articulo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Transactions;
    using Dominio.Entidades;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using Servicio.Interfaces.Precio.DTOs;

    public class ArticuloServicio : IArticuloServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(ArticuloDto entidad)
        {
            var listaPrecios = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => x.EstaEliminado == false);
            if (listaPrecios == null)
            {
                throw new Exception("Por favor cree la Lista de Precios antes de dar de alta Artículo");
            }
            using (var trani = new TransactionScope())
            {
                try
                {
                    var articuloId = _unidadDeTrabajo.ArticuloRepositorio.Insertar(new Dominio.Entidades.Articulo
                    {
                        EstaEliminado = false,
                        Descripcion = entidad.Descripcion,
                        MarcaId = entidad.MarcaId,
                        RubroId = entidad.RubroId,
                        UnidadMedidaId = entidad.UnidadMedidaId,
                        IvaId = entidad.IvaId,
                        ProveedorId = entidad.ProveedorId,
                        Codigo = entidad.Codigo,
                        CodigoBarra = entidad.CodigoBarra,
                        Abreviatura = entidad.Abreviatura,
                        Detalle = entidad.Detalle,
                        Ubicacion = entidad.Ubicacion,
                        Foto = entidad.Foto,
                        ActivarLimiteVenta = entidad.ActivarLimiteVenta,
                        LimiteVenta = entidad.LimiteVenta,
                        ActivarHoraVenta = entidad.ActivarHoraVenta,
                        HoraLimiteVentaInicio = entidad.HoraLimiteVentaInicio,
                        HoraLimiteVentaFin = entidad.HoraLimiteVentaFin,
                        PermiteStockNegativo = entidad.PermiteStockNegativo,
                        DescuentaStock = entidad.DescuentaStock,
                        Stock = entidad.Stock,
                        StockMinimo = entidad.StockMinimo,
                        Precios = GenerarListaPrecios(entidad.PrecioCosto, listaPrecios)
                    });

                    _unidadDeTrabajo.Commit();
                    trani.Complete();
                    return articuloId;
                }
                catch (Exception e)
                {
                    trani.Dispose();
                    throw new Exception($"Al crear el Artículo se produjo el error: {e.Message}");
                }
            }

        }

        private ICollection<Precio> GenerarListaPrecios(decimal precioCosto, IEnumerable<ListaPrecio> listaPrecios, long? articuloId = null)
        {
            var precios = new List<Precio>();
            foreach (var l in listaPrecios)
            {
                precios.Add(new Precio
                {
                    ArticuloId = articuloId.HasValue ? articuloId.Value : 0,
                    ListaPrecioId = l.Id,
                    PrecioCosto = precioCosto,
                    PrecioPublico = precioCosto + ((precioCosto * l.PorcentajeGanancia) / 100),
                    FechaActualizacion = DateTime.Now
                });
            }
            return precios;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(id);

            _unidadDeTrabajo.ArticuloRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ArticuloDto> Get(string cadenaBuscar)
        {
            Expression<Func<Articulo, bool>> filtro = a =>
                !a.EstaEliminado && a.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Marca, Rubro, UnidadMedida, Iva, Proveedor, Precios");
            var fechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return resultado.Select(entidad => new ArticuloDto
            {
                Id = entidad.Id,
                EstaEliminado = entidad.EstaEliminado,
                Descripcion = entidad.Descripcion,
                RowVersion = entidad.RowVersion,

                MarcaId = entidad.MarcaId,
                Marca = entidad.Marca.Descripcion,
                RubroId = entidad.RubroId,
                Rubro = entidad.Rubro.Descripcion,
                UnidadMedidaId = entidad.UnidadMedidaId,
                UnidadMedida = entidad.UnidadMedida.Descripcion,
                IvaId = entidad.IvaId,
                Iva = entidad.Iva.Descripcion,
                ProveedorId = entidad.ProveedorId,
                Proveedor = entidad.Proveedor.RazonSocial,
                Codigo = entidad.Codigo,
                CodigoBarra = entidad.CodigoBarra,
                Abreviatura = entidad.Abreviatura,
                Detalle = entidad.Detalle,
                Ubicacion = entidad.Ubicacion,
                Foto = entidad.Foto,
                ActivarLimiteVenta = entidad.ActivarLimiteVenta,
                LimiteVenta = entidad.LimiteVenta,
                ActivarHoraVenta = entidad.ActivarHoraVenta,
                HoraLimiteVentaInicio = entidad.HoraLimiteVentaInicio,
                HoraLimiteVentaFin = entidad.HoraLimiteVentaFin,
                PermiteStockNegativo = entidad.PermiteStockNegativo,
                DescuentaStock = entidad.DescuentaStock,
                Stock = entidad.Stock,
                StockMinimo = entidad.StockMinimo,
                PrecioPublico = entidad.Precios.Any()
                            ? entidad.Precios.FirstOrDefault(x => x.ListaPrecioId == 1
                                                            && x.FechaActualizacion == entidad.Precios
                                                                .Where(p =>
                                                                    p.ListaPrecioId == 1 &&
                                                                    p.FechaActualizacion <= fechaActual)
                                                                .Max(f => f.FechaActualizacion))
                        .PrecioPublico
                            : 0
            }).ToList();
        }

        public ArticuloVentaDto GetByCode(string codigo, long listaPrecioId)
        {
            long _codigo = -1;
            long.TryParse(codigo, out _codigo);

            Expression<Func<Articulo, bool>> filtro = x =>
                !x.EstaEliminado
                && (x.Codigo == _codigo || x.CodigoBarra == codigo)
                && x.Precios.Any(p => p.ListaPrecioId == listaPrecioId);


            var articulo = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Precios, Iva").FirstOrDefault(); //TRAE UNO SOLO
            if (articulo != null)
            {
                var fechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                return new ArticuloVentaDto
                {
                    Id = articulo.Id,
                    CodigoArticulo = articulo.Codigo,
                    CodigoBarraArticulo = articulo.CodigoBarra,
                    DescripcionArticulo = articulo.Descripcion,
                    EstaEliminado = articulo.EstaEliminado,
                    ActivarHoraVenta = articulo.ActivarHoraVenta,
                    ActivarLimiteVenta = articulo.ActivarLimiteVenta,
                    DescuentaStock = articulo.DescuentaStock,
                    HoraLimiteVentaInicio = articulo.HoraLimiteVentaInicio,
                    HoraLimiteVentaFin = articulo.HoraLimiteVentaFin,
                    LimiteVenta = articulo.LimiteVenta,
                    PermiteStockNegativo = articulo.PermiteStockNegativo,
                    Stock = articulo.Stock,
                    IvaId = articulo.Iva.Id,//here villada
                    IvaStr = articulo.Iva.Descripcion,
                    MontoIva21 = articulo.Iva.Porcentaje == 21m
                                ? 21m * (articulo.Precios.FirstOrDefault(x => x.ArticuloId == articulo.Id ).PrecioCosto) / 100m
                                : 0m,

                    MontoIva105 = articulo.Iva.Porcentaje == 10.5m
                                ? 10.5m * (articulo.Precios.FirstOrDefault(x => x.ArticuloId == articulo.Id).PrecioCosto) / 100m
                                : 0m,
                                       
                    PrecioArticulo = articulo.Precios.FirstOrDefault(x => x.ListaPrecioId == listaPrecioId
                                                            && x.FechaActualizacion == articulo.Precios
                                                                .Where(p =>
                                                                    p.ListaPrecioId == listaPrecioId &&
                                                                    p.FechaActualizacion <= fechaActual)
                                                                .Max(f => f.FechaActualizacion))
                        .PrecioPublico

                };
            }
            return null;
        }

        public ArticuloDto GetById(long id)
        {
            Expression<Func<Articulo, bool>> filtro = x =>
                !x.EstaEliminado && (x.Id == id) 
                                 && x.Precios.Any(p => p.ArticuloId == id);


            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Marca, Rubro, UnidadMedida, Iva, Proveedor, Precios").FirstOrDefault();
            if (entidad != null)
            {
                return new ArticuloDto
                {
                    Id = entidad.Id,
                    EstaEliminado = entidad.EstaEliminado,
                    Descripcion = entidad.Descripcion,
                    RowVersion = entidad.RowVersion,

                    MarcaId = entidad.MarcaId,
                    RubroId = entidad.RubroId,
                    UnidadMedidaId = entidad.UnidadMedidaId,
                    IvaId = entidad.IvaId,
                    ProveedorId = entidad.ProveedorId,
                    Proveedor = entidad.Proveedor.RazonSocial,
                    Codigo = entidad.Codigo,
                    CodigoBarra = entidad.CodigoBarra,
                    Abreviatura = entidad.Abreviatura,
                    Detalle = entidad.Detalle,
                    Ubicacion = entidad.Ubicacion,
                    Foto = entidad.Foto,
                    ActivarLimiteVenta = entidad.ActivarLimiteVenta,
                    LimiteVenta = entidad.LimiteVenta,
                    ActivarHoraVenta = entidad.ActivarHoraVenta,
                    HoraLimiteVentaInicio = entidad.HoraLimiteVentaInicio,
                    HoraLimiteVentaFin = entidad.HoraLimiteVentaFin,
                    PermiteStockNegativo = entidad.PermiteStockNegativo,
                    DescuentaStock = entidad.DescuentaStock,
                    Stock = entidad.Stock,
                    StockMinimo = entidad.StockMinimo,
                    PrecioCosto = entidad.Precios.Where(x => x.ArticuloId == entidad.Id)
                        .OrderBy(x => x.FechaActualizacion)
                        .Last().PrecioCosto
                    //PrecioCosto = entidad.Precios.FirstOrDefault(x => x.ArticuloId == entidad.Id
                    //                                            //&& x.FechaActualizacion
                    //                                            ).PrecioCosto
                };
            }
            else
            {
                return null;
            }
        }

        public void Update(ArticuloDto entidad)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    var entidadModificar = _unidadDeTrabajo.ArticuloRepositorio.Obtener(entidad.Id);

                    entidadModificar.Descripcion = entidad.Descripcion;
                    entidadModificar.MarcaId = entidad.MarcaId;
                    entidadModificar.RubroId = entidad.RubroId;
                    entidadModificar.UnidadMedidaId = entidad.UnidadMedidaId;
                    entidadModificar.IvaId = entidad.IvaId;
                    entidadModificar.ProveedorId = entidad.ProveedorId;
                    entidadModificar.Codigo = entidad.Codigo;
                    entidadModificar.CodigoBarra = entidad.CodigoBarra;
                    entidadModificar.Abreviatura = entidad.Abreviatura;
                    entidadModificar.Detalle = entidad.Detalle;
                    entidadModificar.Ubicacion = entidad.Ubicacion;
                    entidadModificar.Foto = entidad.Foto;
                    entidadModificar.ActivarLimiteVenta = entidad.ActivarLimiteVenta;
                    entidadModificar.LimiteVenta = entidad.LimiteVenta;
                    entidadModificar.ActivarHoraVenta = entidad.ActivarHoraVenta;
                    entidadModificar.HoraLimiteVentaInicio = entidad.HoraLimiteVentaInicio;
                    entidadModificar.HoraLimiteVentaFin = entidad.HoraLimiteVentaFin;
                    entidadModificar.PermiteStockNegativo = entidad.PermiteStockNegativo;
                    entidadModificar.DescuentaStock = entidad.DescuentaStock;
                    entidadModificar.Stock = entidad.Stock;
                    entidadModificar.StockMinimo = entidad.StockMinimo;
                    entidadModificar.TipoArticulo = entidad.TipoArticulo;
                    if (!entidadModificar.Precios.Any(x => x.PrecioCosto.Equals(entidad.PrecioCosto)))
                    {
                        GenerarListaPrecios(entidad.PrecioCosto, _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado));

                    }
                    _unidadDeTrabajo.ArticuloRepositorio.Modificar(entidadModificar);

                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception($"Intentando Modificar dió el error: {ex.Message}");
                }
            }
        }

        public bool UpdateStock(ArticuloDto entidad, decimal nuevoStock)
        {
            try
            {
                var entidadModificar = _unidadDeTrabajo.ArticuloRepositorio.Obtener(entidad.Id);
                entidadModificar.Stock = nuevoStock;
                _unidadDeTrabajo.ArticuloRepositorio.Modificar(entidadModificar);

                _unidadDeTrabajo.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
                 
        


    }
}
