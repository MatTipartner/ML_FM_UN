using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_P_PRODUCTOS.Utilities
{
    public class MapperParametricas
    {
        public static List<ParametricaServicioEstandar> CrearListaParametroEstandarServicio(GetSettingDataRespuesta dataRespuesta)
        {
            List<ParametricaServicioEstandar> listaParamEstantar = new List<ParametricaServicioEstandar>();
            ParametricaServicioEstandar pEstandar;
            foreach (var dRespuesta in dataRespuesta.SettingsData)
            {
                pEstandar = new ParametricaServicioEstandar();
                pEstandar.Id = dRespuesta.ValueReturn1.Trim(); 
                pEstandar.Descripcion = dRespuesta.ValueReturn2.Trim(); 
                listaParamEstantar.Add(pEstandar);
            }
            return listaParamEstantar;
        }
        public static List<ParametricaServicioReferencia> CrearListaParametroEstandarServicioReferencia(GetSettingDataRespuesta dataRespuesta)
        {
            List<ParametricaServicioReferencia> listaParamEstantar = new List<ParametricaServicioReferencia>();
            ParametricaServicioReferencia pEstandar;
            foreach (var dRespuesta in dataRespuesta.SettingsData)
            {
                pEstandar = new ParametricaServicioReferencia();
                pEstandar.Id = dRespuesta.ValueReturn1;
                pEstandar.Descripcion = dRespuesta.ValueReturn2.Trim(); 
                pEstandar.IdReferencia = dRespuesta.ValueReturn3.Trim(); 
                listaParamEstantar.Add(pEstandar);
            }
            return listaParamEstantar;
        }

        public static List<ParametricaServicioReferencia> CrearListaParametroCobertura(GetSettingDataRespuesta dataRespuesta, IEnumerable<CoberturaDtoMapper> listCobertura)
        {
            List<ParametricaServicioReferencia> listaParamEstantar = new List<ParametricaServicioReferencia>();
            ParametricaServicioReferencia pEstandar;
            foreach (var dRespuesta in dataRespuesta.SettingsData)
            {
                var lisr = listCobertura.Where(x => x.NRO_SACS == Convert.ToInt32(dRespuesta.ValueReturn3.Trim())).FirstOrDefault();
                //String cobertura = lisr.ID_COBERTURA.ToString();
                 if(lisr != null){
                pEstandar = new ParametricaServicioReferencia();
                    pEstandar.Id = dRespuesta.ValueReturn1;
                    pEstandar.Descripcion = dRespuesta.ValueReturn2.Trim();

                    pEstandar.IdReferencia = lisr.ID_COBERTURA.ToString();
                    listaParamEstantar.Add(pEstandar);
                }               
            }
            listaParamEstantar = listaParamEstantar.OrderBy(x=>x.IdReferencia).ToList();
            return listaParamEstantar;
        }
    }
}