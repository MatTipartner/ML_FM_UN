using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_CONVENIOS.Models;
using MS_ML_FU_P_CONVENIOS.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_CONVENIOS.Persistence.Impl
{
    public class MsConveniosPersistence : IMsConveniosPersistence
    {
        public IEnumerable<ParametricasBdEstandar> GetListaVademecum()
        {
            List<ParametricasBdEstandar> lVademecum = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar vademecum;
            try
            {
                using (Entities db = new Entities())
                {                
                    var list = from tvademecum in db.FUWEB_P_VADEMECUM
                               where tvademecum.VIGENTE == "S"
                               orderby tvademecum.NOMBRE
                               select tvademecum;

                    foreach (var Datovademecum in list)
                    {
                        vademecum = new ParametricasBdEstandar();
                        vademecum.Id = Datovademecum.ID_VADEMECUM;
                        vademecum.Descripcion = Datovademecum.NOMBRE;
                        lVademecum.Add(vademecum);
                    }
                }                
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lVademecum;
        }
        public IEnumerable<ParametricasBdEstandar> GetListaTipoFacturacion()
        {
            List<ParametricasBdEstandar> ltipoFacturacion = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoFacturacion;
            try
            {
                using (Entities db = new Entities())
                {               
                    var list = from tipoFac in db.FUWEB_P_TIPOFACTURACION
                               where tipoFac.VIGENTE == "S"
                               orderby tipoFac.NOMBRE
                               select tipoFac;

                    foreach (var DatoTipoProducto in list)
                    {
                        tipoFacturacion = new ParametricasBdEstandar();
                        tipoFacturacion.Id = DatoTipoProducto.ID_TIPOFACTURACION;
                        tipoFacturacion.Descripcion = DatoTipoProducto.NOMBRE;
                        ltipoFacturacion.Add(tipoFacturacion);
                    }
                }                
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoFacturacion;
        }
        public IEnumerable<ParametricasBdReferencia> GetListaConvenio()
        {
            List<ParametricasBdReferencia> lConvenios = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia convenio;
            try
            {
                using (Entities db = new Entities())
                {               
                    var list = from convenioList in db.FUWEB_P_CONVENIO
                               where convenioList.VIGENTE == "S"
                               orderby convenioList.ID_TIPOCONVENIO, convenioList.ORDEN
                               select convenioList;
                    foreach (var DatoConvenio in list)
                    {
                        convenio = new ParametricasBdReferencia();
                        convenio.Id = DatoConvenio.ID_CONVENIO;
                        convenio.Descripcion = DatoConvenio.NOMBRE;
                        convenio.IdReferencia = DatoConvenio.ID_TIPOCONVENIO;
                        lConvenios.Add(convenio);
                    }
                }                
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lConvenios;
        }

        public IEnumerable<OtrosConveniosDtoMapper> GetConvenioPorGrupo(int GrupoPoliza) {
            List<OtrosConveniosDtoMapper> lConvenio = new List<OtrosConveniosDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = from convenio in db.FUWEB_CONVENIOOTROS
                                 where convenio.ID_AGRUPACION == GrupoPoliza
                                 select convenio;
                    if (datos.Count() > 0)
                    {
                        foreach (var listacascada in datos)
                        {
                            lConvenio.Add(MapperWrapper.Mapper.Map<OtrosConveniosDtoMapper>(listacascada));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lConvenio;
        }

        public IEnumerable<FarmaciaDtoMapper> GetFarmaciaPorGrupo(int GrupoPoliza)
        {
            List<FarmaciaDtoMapper> lFarmacia = new List<FarmaciaDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from far in db.FUWEB_CONVENIOFARMACIA
                                 where far.ID_AGRUPACION == GrupoPoliza
                                 select far);
                    if (datos.Count() > 0)
                    {
                        foreach (var listFarmacia in datos)
                        {
                            lFarmacia.Add(MapperWrapper.Mapper.Map<FarmaciaDtoMapper>(listFarmacia));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lFarmacia;
        }

        public Boolean SetDeleteOtrosConvenios(IEnumerable<OtrosConveniosDtoMapper> listaOtrosConveniosMapper)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaOtrosConveniosMapper)
                    {
                        var registro = db.FUWEB_CONVENIOOTROS.Where(list => list.ID_OTROSCONVENIOS == lista.ID_OTROSCONVENIOS).FirstOrDefault();
                        db.FUWEB_CONVENIOOTROS.Remove(registro);
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

        public Boolean SetOtrosConvenios(IEnumerable<OtrosConveniosDtoMapper> listaOtrosConveniosMapper)
        {
            try
            {               
                foreach (var lista in listaOtrosConveniosMapper)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_CONVENIOOTROS.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_CONVENIOOTROS>(lista));
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

        public Boolean SetDeleteFarmacia(IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaFarmaciaMapper)
                    {
                        var registro = db.FUWEB_CONVENIOFARMACIA.Where(list => list.ID_LISTAFARMACIA == lista.ID_LISTAFARMACIA).FirstOrDefault();
                        db.FUWEB_CONVENIOFARMACIA.Remove(registro);
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

        public Boolean SetsFarmacia(IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper)
        {
            try
            {                
                foreach (var lista in listaFarmaciaMapper)
                {
                    using (Entities db = new Entities())
                    {
                        db.FUWEB_CONVENIOFARMACIA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_CONVENIOFARMACIA>(lista));
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
    }
}