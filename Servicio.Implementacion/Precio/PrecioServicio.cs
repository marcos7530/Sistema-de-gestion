namespace Servicio.Implementacion.Precio
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Transactions;
    using Dominio.Entidades;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.ListaPrecio.DTOs;
    using Servicio.Interfaces.Precio;
    using Servicio.Interfaces.Precio.DTOs;

    public class PrecioServicio : IPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public PrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }
        
        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.PrecioRepositorio.Obtener(id);
            _unidadDeTrabajo.PrecioRepositorio.Eliminar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<PrecioDto> Get(long articuloId)
        {
            Expression<Func<Dominio.Entidades.Precio, bool>> filtro = p =>
                p.ArticuloId == articuloId;

            var resultado = _unidadDeTrabajo.PrecioRepositorio.Obtener(filtro);

            return resultado.Select(x => new PrecioDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                ArticuloId = x.ArticuloId,
                ListaPrecioId = x.ListaPrecioId,
                PrecioCosto = x.PrecioCosto,
                PrecioPublico = x.PrecioPublico,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public IEnumerable<PrecioDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Precio, bool>> filtro = l =>
                !l.EstaEliminado;

            var resultado = _unidadDeTrabajo.PrecioRepositorio.Obtener(filtro);

            return resultado.Select(x => new PrecioDto()
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
               ListaPrecioId = x.ListaPrecioId,
               ArticuloId = x.ArticuloId,
               PrecioCosto = x.PrecioCosto,
               PrecioPublico = x.PrecioPublico,
               FechaActualizacion = x.FechaActualizacion,
                RowVersion = x.RowVersion
            }).ToList();
        }

      

        public void Update(PrecioDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.PrecioRepositorio.Obtener(entidad.Id);

            entidadModificar.ListaPrecioId = entidad.ListaPrecioId;
            entidadModificar.ArticuloId = entidad.ArticuloId;
            entidadModificar.PrecioCosto = entidad.PrecioCosto;
            entidadModificar.PrecioPublico= entidad.PrecioPublico;
            entidadModificar.FechaActualizacion= entidad.FechaActualizacion;

            _unidadDeTrabajo.PrecioRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }


        public PrecioDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.PrecioRepositorio.Obtener(id);

            return new PrecioDto()
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                /*=====================================================*/
                ListaPrecioId = resultado.ListaPrecioId,
                ArticuloId = resultado.ArticuloId,
                PrecioCosto = resultado.PrecioCosto,
                PrecioPublico = resultado.PrecioPublico,
                FechaActualizacion = resultado.FechaActualizacion,
            /*======================================================*/
            RowVersion = resultado.RowVersion
            };
        }


        public bool UpdatePrecios(Expression<Func<Articulo, bool>> filtro, 
                                IEnumerable<ListaPrecioDto> listaPrecios, 
                                decimal? monto = null, 
                                decimal? porcentaje = null)
        {
            var articulos = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro);
            var fechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            decimal _precioPublico = 0m;
            decimal _precioCosto = 0m;

            using (var tran = new TransactionScope())
            {
                //try
                //{
                    foreach (var art in articulos)
                    {
                        _precioCosto = art.Precios.FirstOrDefault(z => z.FechaActualizacion <= fechaActual).PrecioCosto;

                        foreach (var l in listaPrecios)
                        {

                            _precioPublico = art.Precios.FirstOrDefault(x => x.ListaPrecioId == l.Id
                                                         && x.FechaActualizacion == art.Precios
                                                             .Where(p => p.ListaPrecioId == l.Id &&
                                                                     p.FechaActualizacion <= fechaActual)
                                                             .Max(f => f.FechaActualizacion)).PrecioPublico;
                           

                            if (monto.HasValue)
                            {
                                _precioPublico += monto.Value;
                            }

                            if (porcentaje.HasValue)
                            {
                                _precioPublico += ((_precioPublico * porcentaje.Value) / 100);
                            }
                            _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                            {
                                ListaPrecioId = l.Id,
                                ArticuloId = art.Id,
                                PrecioCosto = _precioCosto,
                                PrecioPublico = _precioPublico,
                                FechaActualizacion = DateTime.Now,
                                EstaEliminado = false
                            });

                        }
                    }
                    _unidadDeTrabajo.Commit();
                    tran.Complete();
                    return true;
                //}
                //catch (Exception e)
                //{
                //    tran.Dispose();
                //    return false;
                //}
            }

        }

    }

}
