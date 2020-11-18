using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_P_TARIFA.Utilities
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
                pEstandar.Id = dRespuesta.ValueReturn1.Trim(); ;
                pEstandar.Descripcion = dRespuesta.ValueReturn2.Trim(); ;
                listaParamEstantar.Add(pEstandar);
            }
            return listaParamEstantar;
        }


        public static List<TarifaGrupoDtoMapper> MapperDtoVistaMapperaDtoVistaTarifaGrupo(IEnumerable<TarifaGrupoDto> listaTarifaMapper)
        {
            List<TarifaGrupoDtoMapper> listaTarifa = new List<TarifaGrupoDtoMapper>();
            TarifaGrupoDtoMapper tarifa = null;
            foreach (var lTari in listaTarifaMapper)
            {
                tarifa = new TarifaGrupoDtoMapper();
                tarifa.ID_AGRUPACION           = lTari.ID_AGRUPACION;
                tarifa.GRUPOFAMILIAR           = lTari.GRUPOFAMILIAR;
                tarifa.ID_COBERTURA            = lTari.ID_COBERTURA;
                tarifa.ID_DEFINICIONTRIBUTARIA = lTari.ID_DEFINICIONTRIBUTARIA;
                tarifa.ID_TARIFAGRUPO          = lTari.ID_TARIFAGRUPO;
                tarifa.ID_TIPOPRODUCTO         = lTari.ID_TIPOPRODUCTO;
                listaTarifa.Add(tarifa);
            }
            return listaTarifa;
        }


        public static List<TasaPrimaDtoMapper> MapperDtoVistaMapperaDtoVistaTasaPrima(IEnumerable<TasaPrimaDtoMapper> listaTasaPrimaMapper)
        {
            List<TasaPrimaDtoMapper> listaTasaPrima = new List<TasaPrimaDtoMapper>();
            TasaPrimaDtoMapper tasaPrima = null;
            foreach (var lTari in listaTasaPrimaMapper)
            {
                tasaPrima = new TasaPrimaDtoMapper();
                tasaPrima.ID_TARIFAGRUPO = lTari.ID_TARIFAGRUPO;
                tasaPrima.ID_GRUPOLISTAPRIMA = lTari.ID_GRUPOLISTAPRIMA;
                tasaPrima.DESDE = lTari.DESDE;
                tasaPrima.HASTA = lTari.HASTA;
                tasaPrima.PRIMAFIJA = lTari.PRIMAFIJA;
                tasaPrima.TASA = lTari.TASA;
                listaTasaPrima.Add(tasaPrima);
            }
            return listaTasaPrima;
        }

        internal static IEnumerable<TasaPrimaDtoMapper> MapperDtoVistaMapperaDtoVistaTasaPrima(List<TasaPrimaDto> noExisteEnFronTasaPrima)
        {
            throw new NotImplementedException();
        }

        public static List<TasaEspecialDtoMapper> MapperDtoVistaMapperaDtoVistaTasaEspecial(IEnumerable<TasaEspecialDto> listaTasaEspecialMapper)
        {
            List<TasaEspecialDtoMapper> listaTasaEspecial = new List<TasaEspecialDtoMapper>();
            TasaEspecialDtoMapper tasaEspecial = null;
            foreach (var lTari in listaTasaEspecialMapper)
            {
                tasaEspecial = new TasaEspecialDtoMapper();
                tasaEspecial.ID_TARIFAGRUPO = lTari.ID_TARIFAGRUPO;
                tasaEspecial.ID_GRUPOLISTAESPECIAL = lTari.ID_GRUPOLISTAESPECIAL;
                tasaEspecial.ID_TARIFAGRUPO = lTari.ID_TARIFAGRUPO;
                tasaEspecial.SIGLA_RELACION = lTari.SIGLA_RELACION;
                tasaEspecial.DESDE = lTari.DESDE;
                tasaEspecial.HASTA = lTari.HASTA;
                tasaEspecial.TASARECARGO = lTari.TASARECARGO;
                listaTasaEspecial.Add(tasaEspecial);
            }
            return listaTasaEspecial;
        }

        internal static IEnumerable<TasaEspecialDtoMapper> MapperDtoVistaMapperaDtoVistaTasaEspecial(List<TasaEspecialDto> noExisteEnFronTasaEspecial)
        {
            throw new NotImplementedException();
        }
    }
}