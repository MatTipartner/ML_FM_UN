using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;

namespace MS_ML_FU_P_BMI.Utilities
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
                pEstandar.Id = dRespuesta.ValueReturn1;
                pEstandar.Descripcion = dRespuesta.ValueReturn2;
                listaParamEstantar.Add(pEstandar);
            }
            return listaParamEstantar;
        }
    }
}