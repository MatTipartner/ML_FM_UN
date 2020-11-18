using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_PRODUCTOS.Models;
using MS_ML_FU_P_PRODUCTOS.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MS_ML_FU_P_PRODUCTOS.Persistence.Impl
{
    public class MsProductosPersistence : IMsProductosPersistence
    {
        public IEnumerable<ParametricasBdEstandar> GetListaTipoProducto()
        {
            List<ParametricasBdEstandar> ltipoProducto = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoProducto;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from TipoProducto in db.FUWEB_P_TIPOPRODUCTO
                               where TipoProducto.VIGENTE == "S"
                               select TipoProducto;

                    foreach (var DatoTipoProducto in list)
                    {
                        tipoProducto = new ParametricasBdEstandar();
                        tipoProducto.Id = DatoTipoProducto.ID_TIPOPRODUCTO;
                        tipoProducto.Descripcion = DatoTipoProducto.NOMBRE;
                        ltipoProducto.Add(tipoProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoProducto;
        }
        public IEnumerable<ParametricasBdReferencia> GetListaCobertura()
        {
            List<ParametricasBdReferencia> ltipoCobertura = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia cobertura = null;
            try
            {
                using (Entities db = new Entities())
                {

                    var list = from ListCobertura in db.FUWEB_P_COBERTURA
                               where ListCobertura.VIGENTE == "S"
                               select ListCobertura;

                    foreach (var coberturaList in list)
                    {
                        cobertura = new ParametricasBdReferencia();
                        cobertura.Id = coberturaList.ID_COBERTURA;
                        cobertura.Descripcion = coberturaList.NOMBRE;
                        cobertura.IdReferencia = coberturaList.ID_TIPOPRODUCTO;
                        ltipoCobertura.Add(cobertura);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoCobertura;
        }
        public IEnumerable<ParametricasBdEstandar> GetListaTipoProductoPorGrupo(int GrupoFormulario)
        {
            List<ParametricasBdEstandar> ltipoProducto = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoProducto;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from A in db.FUWEB_PRODUCTOLIST_SALUD
                                join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                join C in db.FUWEB_P_TIPOPRODUCTO on B.ID_TIPOPRODUCTO equals C.ID_TIPOPRODUCTO
                                where A.ID_AGRUPACION == GrupoFormulario
                                select new
                                {
                                    C.ID_TIPOPRODUCTO,
                                    C.NOMBRE
                                }).Union(
                                from A in db.FUWEB_PRODUCTOLIST_VIDAAP
                                join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                join C in db.FUWEB_P_TIPOPRODUCTO on B.ID_TIPOPRODUCTO equals C.ID_TIPOPRODUCTO
                                where A.ID_AGRUPACION == GrupoFormulario
                                select new
                                {
                                    C.ID_TIPOPRODUCTO,
                                    C.NOMBRE
                                });

                    foreach (var DatoTipoProducto in list)
                    {
                        tipoProducto = new ParametricasBdEstandar();
                        tipoProducto.Id = DatoTipoProducto.ID_TIPOPRODUCTO;
                        tipoProducto.Descripcion = DatoTipoProducto.NOMBRE;
                        ltipoProducto.Add(tipoProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoProducto;
        }
        public IEnumerable<ParametricasBdReferencia> GetListaCoberturaPorGrupo(int GrupoFormulario)
        {
            List<ParametricasBdReferencia> lticobertura = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia ticobertura;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from A in db.FUWEB_PRODUCTOLIST_SALUD
                                join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                where A.ID_AGRUPACION == GrupoFormulario
                                orderby B.ID_TIPOPRODUCTO, B.ORDENAR
                                select new
                                {
                                    B.ID_COBERTURA,
                                    B.NOMBRE,
                                    B.ID_TIPOPRODUCTO
                                }).Union
                               (
                                 from A in db.FUWEB_PRODUCTOLIST_VIDAAP
                                 join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                 where A.ID_AGRUPACION == GrupoFormulario
                                 orderby B.ID_TIPOPRODUCTO, B.ORDENAR
                                 select new
                                 {
                                     B.ID_COBERTURA,
                                     B.NOMBRE,
                                     B.ID_TIPOPRODUCTO
                                 });
                    foreach (var Datocobertura in list)
                    {
                        ticobertura = new ParametricasBdReferencia();
                        ticobertura.Id = Datocobertura.ID_COBERTURA;
                        ticobertura.Descripcion = Datocobertura.NOMBRE;
                        ticobertura.IdReferencia = Datocobertura.ID_TIPOPRODUCTO;
                        lticobertura.Add(ticobertura);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lticobertura;
        }
        public IEnumerable<ParametricasBdReferencia> GetListaCoberturaPrestacionBasicaPorGrupo(int GrupoFormulario)
        {
            List<ParametricasBdReferencia> lticobertura = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia ticobertura;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from PRES in db.FUWEB_P_PRESTACIONBASICA
                                join COB in db.FUWEB_P_COBERTURA_PRESTBASICA on PRES.ID_PRESTACIONBASICA equals COB.ID_PRESTACIONBASICA
                                join SUB in (from A in db.FUWEB_PRODUCTOLIST_SALUD
                                             join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                             where A.ID_AGRUPACION == GrupoFormulario
                                             select new
                                             {
                                                 B.ID_COBERTURA
                                             }
                                             ).Union(
                                 from A in db.FUWEB_PRODUCTOLIST_VIDAAP
                                 join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                 where A.ID_AGRUPACION == GrupoFormulario
                                 select new
                                 {
                                     B.ID_COBERTURA
                                 }
                                 )
                                on COB.ID_COBERTURA equals SUB.ID_COBERTURA
                                group PRES by new { PRES.ID_PRESTACIONBASICA, PRES.NOMBRE, COB.ID_COBERTURA } into g
                                orderby g.Key.ID_PRESTACIONBASICA, g.Key.NOMBRE
                                select new
                                {
                                    g.Key.ID_PRESTACIONBASICA,
                                    g.Key.NOMBRE,
                                    g.Key.ID_COBERTURA
                                });
                    foreach (var Datocobertura in list)
                    {
                        ticobertura = new ParametricasBdReferencia();
                        ticobertura.Id = Datocobertura.ID_PRESTACIONBASICA;
                        ticobertura.Descripcion = Datocobertura.NOMBRE;
                        ticobertura.IdReferencia = Datocobertura.ID_COBERTURA;
                        lticobertura.Add(ticobertura);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lticobertura;

        }
        public IEnumerable<ParametricasBdReferencia> GetListaCoberturaPrestacionGenericaPorGrupo(int GrupoFormulario)
        {
            List<ParametricasBdReferencia> lticobertura = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia ticobertura;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from GEN in db.FUWEB_P_PRESTACIONGENERICA
                                join BASGEN in db.FUWEB_P_PRESTACIONBASICGENERIC on GEN.ID_PRESTACIONGENERICA equals BASGEN.ID_PRESTACIONGENERICA
                                join COB in db.FUWEB_P_COBERTURA_PRESTBASICA on BASGEN.ID_PRESTACIONBASICA equals COB.ID_PRESTACIONBASICA
                                join SUB in (from A in db.FUWEB_PRODUCTOLIST_SALUD
                                             join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                             where A.ID_AGRUPACION == GrupoFormulario
                                             select new
                                             {
                                                 B.ID_COBERTURA
                                             }
                                             ).Union(
                                 from A in db.FUWEB_PRODUCTOLIST_VIDAAP
                                 join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                 where A.ID_AGRUPACION == GrupoFormulario

                                 select new
                                 {
                                     B.ID_COBERTURA
                                 }
                                 )
                                on COB.ID_COBERTURA equals SUB.ID_COBERTURA
                                group GEN by new { GEN.ID_PRESTACIONGENERICA, GEN.NOMBRE, COB.ID_COBERTURA } into g
                                orderby g.Key.ID_PRESTACIONGENERICA, g.Key.NOMBRE
                                select new
                                {
                                    g.Key.ID_PRESTACIONGENERICA,
                                    g.Key.NOMBRE,
                                    g.Key.ID_COBERTURA
                                });


                    foreach (var Datocobertura in list)
                    {
                        ticobertura = new ParametricasBdReferencia();
                        ticobertura.Id = Datocobertura.ID_PRESTACIONGENERICA;
                        ticobertura.Descripcion = Datocobertura.NOMBRE;
                        ticobertura.IdReferencia = Datocobertura.ID_COBERTURA;
                        lticobertura.Add(ticobertura);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lticobertura;
        }
        public IEnumerable<ParametricasBdPrestacionParametrica> GetListaCoberturaPrestacionesPorGrupo(int GrupoFormulario)
        {
            List<ParametricasBdPrestacionParametrica> lticobertura = new List<ParametricasBdPrestacionParametrica>();
            ParametricasBdPrestacionParametrica ticobertura;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from GEN in db.FUWEB_P_PRESTACION
                                join BASGEN in db.FUWEB_P_PRESTACIONBASICGENERIC on GEN.ID_PRESTACIONGENERICA equals BASGEN.ID_PRESTACIONGENERICA
                                join COB in db.FUWEB_P_COBERTURA_PRESTBASICA on BASGEN.ID_PRESTACIONBASICA equals COB.ID_PRESTACIONBASICA
                                join SUB in (from A in db.FUWEB_PRODUCTOLIST_SALUD
                                             join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                             where A.ID_AGRUPACION == GrupoFormulario
                                             select new
                                             {
                                                 B.ID_COBERTURA
                                             }
                                             ).Union(
                                             from A in db.FUWEB_PRODUCTOLIST_VIDAAP
                                             join B in db.FUWEB_P_COBERTURA on A.ID_COBERTURA equals B.ID_COBERTURA
                                             where A.ID_AGRUPACION == GrupoFormulario
                                             select new
                                             {
                                                 B.ID_COBERTURA
                                             }
                                             )on COB.ID_COBERTURA equals SUB.ID_COBERTURA
                                group GEN by new { GEN.ID_PRESTACION, GEN.NOMBRE, GEN.ID_PRESTACIONSUBGRUPO, GEN.ID_PRESTACIONGENERICA, COB.ID_PRESTACIONBASICA } into g
                                orderby g.Key.ID_PRESTACIONGENERICA, g.Key.NOMBRE
                                select new
                                {
                                    g.Key.ID_PRESTACION,
                                    g.Key.NOMBRE,
                                    g.Key.ID_PRESTACIONSUBGRUPO,
                                    g.Key.ID_PRESTACIONGENERICA,
                                    g.Key.ID_PRESTACIONBASICA
                                });
                    foreach (var Datocobertura in list)
                    {
                        ticobertura = new ParametricasBdPrestacionParametrica();
                        ticobertura.IdPrestacion = Datocobertura.ID_PRESTACION;
                        ticobertura.Descripcion = Datocobertura.NOMBRE;
                        ticobertura.IDPrestacionBasica = Datocobertura.ID_PRESTACIONBASICA;
                        ticobertura.IDPrestacionGenerica = Datocobertura.ID_PRESTACIONGENERICA;
                        ticobertura.IdPrestacionSubGrupo = Datocobertura.ID_PRESTACIONSUBGRUPO;
                        lticobertura.Add(ticobertura);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lticobertura;
        }
        public IEnumerable<ProductoSaludDetalleDtoMapper> GetListaProductoSalud(int GrupoPoliza)
        {
            List<ProductoSaludDetalleDtoMapper> ltipoSalud = new List<ProductoSaludDetalleDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from pSalud in db.FUWEB_PRODUCTOLIST_SALUD
                                 where pSalud.ID_AGRUPACION == GrupoPoliza
                                 select pSalud);
                    if (datos.Count() > 0)
                    {
                        foreach (var listaSalud in datos)
                        {
                            ltipoSalud.Add(MapperWrapper.Mapper.Map<ProductoSaludDetalleDtoMapper>(listaSalud));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoSalud;
        }
        public IEnumerable<ProductoVidaApDetalleDtoMapper> GetListaProductoVidaAp(int GrupoPoliza)
        {
            List<ProductoVidaApDetalleDtoMapper> listaVidaAp = new List<ProductoVidaApDetalleDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from pVidaAp in db.FUWEB_PRODUCTOLIST_VIDAAP
                                 where pVidaAp.ID_AGRUPACION == GrupoPoliza
                                 select pVidaAp);
                    if (datos.Count() > 0)
                    {
                        foreach (var lVidaAp in datos)
                        {
                            listaVidaAp.Add(MapperWrapper.Mapper.Map<ProductoVidaApDetalleDtoMapper>(lVidaAp));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return listaVidaAp;
        }
        public ProductoVidaApDtoMapper GetProductoVidaAp(int GrupoPoliza)
        {
            ProductoVidaApDtoMapper vidaAp = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from pSalud in db.FUWEB_PRODUCTO_VIDAAP
                                 where pSalud.ID_AGRUPACION == GrupoPoliza
                                 select pSalud);
                    if (datos.Count() > 0)
                    {
                        vidaAp = MapperWrapper.Mapper.Map<ProductoVidaApDtoMapper>(datos.FirstOrDefault());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return vidaAp;
        }
        public IEnumerable<CascadaDtoMapper> GetCascada(int GrupoPoliza)
        {
            List<CascadaDtoMapper> lcascada = new List<CascadaDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from pSalud in db.FUWEB_PRODUCTOCASCADA
                                 where pSalud.ID_AGRUPACION == GrupoPoliza
                                 select pSalud);
                    if (datos.Count() > 0)
                    {
                        foreach (var listacascada in datos)
                        {
                            lcascada.Add(MapperWrapper.Mapper.Map<CascadaDtoMapper>(listacascada));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lcascada;
        }

        public IEnumerable<ParametricasBdEstandar> GetListaSubGrupo()
        {
            List<ParametricasBdEstandar> lSubGrupo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar subGrupo;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from subG in db.FUWEB_P_TIPOPRODUCTO
                               where subG.VIGENTE == "S"
                               select subG;

                    foreach (var DatoTipoProducto in list)
                    {
                        subGrupo = new ParametricasBdEstandar();
                        subGrupo.Id = DatoTipoProducto.ID_TIPOPRODUCTO;
                        subGrupo.Descripcion = DatoTipoProducto.NOMBRE;
                        lSubGrupo.Add(subGrupo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lSubGrupo;
        }

        public Boolean SetDeleteListaSalud (IEnumerable<ProductoSaludDetalleDtoMapper> listaProductoSalud)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaProductoSalud)
                    {
                        var registro = db.FUWEB_PRODUCTOLIST_SALUD.Where(list => list.ID_PRODUCTO_SALUD == lista.ID_PRODUCTO_SALUD).FirstOrDefault();
                        db.FUWEB_PRODUCTOLIST_SALUD.Remove(registro);
                        db.SaveChanges();
                        
                    }
                }
                return true;
                
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

         public Boolean SetDeleteListaVidaAp (IEnumerable<ProductoVidaApDetalleDtoMapper> listaProductoVidaAp)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaProductoVidaAp)
                    {
                        var registro = db.FUWEB_PRODUCTOLIST_VIDAAP.Where(list => list.ID_PRODUCTOLIST_VIDAAP == lista.ID_PRODUCTOLIST_VIDAAP).FirstOrDefault();
                        db.FUWEB_PRODUCTOLIST_VIDAAP.Remove(registro);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetDeleteCascada(IEnumerable<CascadaDtoMapper> liscaCascada)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in liscaCascada)
                    {
                        var registro = db.FUWEB_PRODUCTOCASCADA .Where(list => list.ID_CASCADA == lista.ID_CASCADA).FirstOrDefault();
                        db.FUWEB_PRODUCTOCASCADA.Remove(registro);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetDeleteVidaAp(ProductoVidaApDtoMapper productovidaAp)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    var registro = db.FUWEB_PRODUCTO_VIDAAP.Where(list => list.ID_PRODUCTO_VIDAAP == productovidaAp.ID_PRODUCTO_VIDAAP).FirstOrDefault();
                    db.FUWEB_PRODUCTO_VIDAAP.Remove(registro);
                    db.SaveChanges();                   
                    return true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetListaVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp)
        {
            try
            {              
                foreach (var lista in listaVidaAp)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_PRODUCTOLIST_VIDAAP.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_PRODUCTOLIST_VIDAAP>(lista));
                        db.SaveChanges();
                    }
                }
                return true;               
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud)
        {
            try
            {
                foreach (var lista in listaSalud)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_PRODUCTOLIST_SALUD.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_PRODUCTOLIST_SALUD>(lista));
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> listacascada)
        {
            try
            {
                foreach (var lista in listacascada)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_PRODUCTOCASCADA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_PRODUCTOCASCADA>(lista));
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetVidaAp(ProductoVidaApDtoMapper vidaAp)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.FUWEB_PRODUCTO_VIDAAP.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_PRODUCTO_VIDAAP>(vidaAp));
                    db.SaveChanges();
                }
                
                return true;
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public IEnumerable<CoberturaDtoMapper> GetCOberturaMapper()
        {
            List<CoberturaDtoMapper> ltipoSalud = new List<CoberturaDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from cober in db.FUWEB_P_COBERTURA
                                 select cober);
                    if (datos.Count() > 0)
                    {
                        foreach (var lista in datos)
                        {
                            ltipoSalud.Add(MapperWrapper.Mapper.Map<CoberturaDtoMapper>(lista));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoSalud;
        }

    }
}