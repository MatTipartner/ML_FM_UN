using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_P_DATOSPOLIZA.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Core;
using MS_ML_FU_P_DATOSPOLIZA.Utilities;
using System.Data.Entity.Migrations;

namespace MS_ML_FU_P_DATOSPOLIZA.Persistence.Impl
{
    public class MsDatosPolizaPersistence : IMsDatosPolizaPersistence
    {
        public IEnumerable<ParametricasBdEstandar> GetListaPoliza()
        {
            List<ParametricasBdEstandar> ltipo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoPol = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from tipoPoliza in db.FUWEB_P_TIPOPOLIZA
                               where tipoPoliza.VIGENTE == "S"
                               orderby tipoPoliza.NOMBRE
                               select tipoPoliza;

                    foreach (var DatoPoliza in list)
                    {
                        tipoPol = new ParametricasBdEstandar();
                        tipoPol.Id = DatoPoliza.ID_TIPOPOLIZA;
                        tipoPol.Descripcion = DatoPoliza.NOMBRE;
                        ltipo.Add(tipoPol);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipo;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaRiesgo()
        {
            List<ParametricasBdEstandar> ltipoRiesgo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoRiesgo = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from riesgo in db.FUWEB_P_RIESGO
                               where riesgo.VIGENTE == "S"
                               orderby riesgo.NOMBRE
                               select riesgo;

                    foreach (var DatoRiesgo in list)
                    {
                        tipoRiesgo = new ParametricasBdEstandar();
                        tipoRiesgo.Id = DatoRiesgo.ID_RIESGO;
                        tipoRiesgo.Descripcion = DatoRiesgo.NOMBRE;
                        ltipoRiesgo.Add(tipoRiesgo);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoRiesgo;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaLineaNegocio()
        {
            List<ParametricasBdEstandar> ltipoRiesgo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoRiesgo = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from lineaNegocio in db.FUWEB_P_LINEANEGOCIO
                               where lineaNegocio.VIGENTE == "S"
                               orderby lineaNegocio.NOMBRE 
                               select lineaNegocio;

                    foreach (var DatoRiesgo in list)
                    {
                        tipoRiesgo = new ParametricasBdEstandar();
                        tipoRiesgo.Id = DatoRiesgo.ID_LINEANEGOCIO;
                        tipoRiesgo.Descripcion = DatoRiesgo.NOMBRE;
                        ltipoRiesgo.Add(tipoRiesgo);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoRiesgo;
        }
        
        public IEnumerable<ParametricasBdEstandar> GetListaCanalVenta()
        {
            List<ParametricasBdEstandar> ltipoRiesgo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoRiesgo = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = (from canalVenta in db.FUWEB_P_CANALVENTA
                               where canalVenta.VIGENTE == "S"
                                orderby canalVenta.NOMBRE
                                select canalVenta);

                    foreach (var DatoRiesgo in list)
                    {
                        tipoRiesgo = new ParametricasBdEstandar();
                        tipoRiesgo.Id = DatoRiesgo.ID_CANALVENTA;
                        tipoRiesgo.Descripcion = DatoRiesgo.NOMBRE;
                        ltipoRiesgo.Add(tipoRiesgo);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoRiesgo;
        }
       
        public IEnumerable<ParametricasBdEstandar> GetListaTipoAdicion()
        {
            List<ParametricasBdEstandar> ltipoRiesgo = new List<ParametricasBdEstandar>();
            ParametricasBdEstandar tipoRiesgo = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var list = from tipoAddition in db.FUWEB_P_TIPOADDITION
                               where tipoAddition.VIGENTE == "S" && tipoAddition.VISIBLE == "S"
                               orderby tipoAddition.NOMBRE
                               select tipoAddition;

                    foreach (var DatoRiesgo in list)
                    {
                        tipoRiesgo = new ParametricasBdEstandar();
                        tipoRiesgo.Id = DatoRiesgo.ID_TIPOADDITION;
                        tipoRiesgo.Descripcion = DatoRiesgo.NOMBRE;
                        ltipoRiesgo.Add(tipoRiesgo);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ltipoRiesgo;
        }

        public DatosPolizaDtoMapper GetFormularioPoliza(int NroPoliza)
        {
            DatosPolizaDtoMapper polizaMapeada = null;
            FUWEB_POLIZA pol = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from poliza in db.FUWEB_POLIZA
                                      where poliza.NRO_POLIZA == NroPoliza
                                      select poliza);
                    if(datos.Count() > 0)
                    {
                        polizaMapeada = MapperWrapper.Mapper.Map<DatosPolizaDtoMapper>(datos.FirstOrDefault());
                        pol = MapperWrapper.Mapper.Map<FUWEB_POLIZA>(polizaMapeada);
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return polizaMapeada;
        }

        public IEnumerable<UbicacionGeograficaDtoMapper> GetUbicacionesGeograficaPorPoliza(int NroPoliza)
        {
            List<UbicacionGeograficaDtoMapper> ubicaciones = new List<UbicacionGeograficaDtoMapper>();
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from grupoGeografico in db.FUWEB_UBICACION_GEOGRAFICA
                                 where grupoGeografico.NRO_POLIZA == NroPoliza
                                 orderby grupoGeografico.NOMBRE_UBICACIONGEOGRAFICA
                                 select grupoGeografico);
                    if (datos.Count() > 0)
                    {
                        foreach(var grupoGeografico in datos)
                        {
                            ubicaciones.Add(MapperWrapper.Mapper.Map<UbicacionGeograficaDtoMapper>(grupoGeografico));
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return ubicaciones;
        }

        public Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza) {
            try
            {
                using (Entities db = new Entities())
                {
                    db.FUWEB_POLIZA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_POLIZA>(datosPoliza));
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

        public Boolean SetDeletebicacionGeografica(IEnumerable<UbicacionGeograficaDtoMapper> listaEliminar)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaEliminar) {
                        var registro = db.FUWEB_UBICACION_GEOGRAFICA.Where(list => list.ID_UBICACIONGEOGRAFICA == lista.ID_UBICACIONGEOGRAFICA).FirstOrDefault();
                        db.FUWEB_UBICACION_GEOGRAFICA.Remove(registro);
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

        public Boolean SetUbicacionGeografica(IEnumerable<UbicacionGeograficaDtoMapper> listaGeorgrafica)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    foreach (var lista in listaGeorgrafica)
                    {
                        db.FUWEB_UBICACION_GEOGRAFICA.AddOrUpdate(MapperWrapper.Mapper.Map<FUWEB_UBICACION_GEOGRAFICA>(lista));
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
    }
}