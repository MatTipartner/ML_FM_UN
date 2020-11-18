using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_CONVENIOS.Utilities
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
        public static List<OtrosConvenioDto> MapperDtoMapperaDtoVistaOtrosConvenios(IEnumerable<OtrosConveniosDtoMapper> listaConeviosMapper)
        {
            List<OtrosConvenioDto> listaOtrosConvenio = new List<OtrosConvenioDto>();
            OtrosConvenioDto convenio = null;
            foreach (var lConve in listaConeviosMapper)
            {
                convenio = new OtrosConvenioDto();
                convenio.ID_AGRUPACION = lConve.ID_AGRUPACION;
                convenio.ID_CONVENIO = lConve.ID_CONVENIO;
                convenio.ID_OTROSCONVENIOS = lConve.ID_OTROSCONVENIOS;
                convenio.ID_TIPO_CONVENIO = lConve.FUWEB_P_CONVENIO.FUWEB_P_TIPOCONVENIO.ID_TIPOCONVENIO;
                listaOtrosConvenio.Add(convenio);
            }
            return listaOtrosConvenio;
        }

        public static List<FarmaciaDto> MapperDtoMapperaDtoVistaFarmacia(IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper)
        {
            List<FarmaciaDto> listaFarmacia = new List<FarmaciaDto>();
            FarmaciaDto farmacia = null;
            foreach (var far in listaFarmaciaMapper)
            {
                farmacia = new FarmaciaDto();
                farmacia.ID_AGRUPACION = far.ID_AGRUPACION;
                farmacia.FRANQUICIA = far.FRANQUICIA;
                farmacia.ID_FARMACIA = far.ID_FARMACIA;
                farmacia.ID_LISTAFARMACIA = far.ID_LISTAFARMACIA;
                farmacia.ID_VADEMECUM = far.ID_VADEMECUM;
                farmacia.MODOOPERACION = far.MODOOPERACION;
                farmacia.MONTOASEGURADO = far.MONTOASEGURADO;
                farmacia.SIGLAMONEDA = far.SIGLAMONEDA;
                farmacia.OPS = far.OPS;
                farmacia.ID_TIPOFACTURACION = far.ID_TIPOFACTURACION;
                listaFarmacia.Add(farmacia);
            }
            return listaFarmacia;
        }

        public static List<OtrosConveniosDtoMapper> MapperDtoVistaADtoMapperaOtrosConvenios(IEnumerable<OtrosConvenioDto> listaOtrosConeviosVista)
        {
            List<OtrosConveniosDtoMapper> listaOtrosConvenioMapper = new List<OtrosConveniosDtoMapper>();
            OtrosConveniosDtoMapper convenioMapper = null;
            foreach (var lConve in listaOtrosConeviosVista)
            {
                convenioMapper = new OtrosConveniosDtoMapper();
                convenioMapper.ID_AGRUPACION = lConve.ID_AGRUPACION;
                convenioMapper.ID_CONVENIO = lConve.ID_CONVENIO;
                convenioMapper.ID_OTROSCONVENIOS = lConve.ID_OTROSCONVENIOS;
                listaOtrosConvenioMapper.Add(convenioMapper);
            }
            return listaOtrosConvenioMapper;
        }

        public static List<FarmaciaDtoMapper> MapperDtoVistaADtoMapperaFarmacia(IEnumerable<FarmaciaDto> listaFarmaciaVista)
        {
            List<FarmaciaDtoMapper> listaFarmaciaMapper = new List<FarmaciaDtoMapper>();
            FarmaciaDtoMapper farmaciaMapper = null;
            foreach (var far in listaFarmaciaVista)
            {
                farmaciaMapper = new FarmaciaDtoMapper();
                farmaciaMapper.ID_AGRUPACION = far.ID_AGRUPACION;
                farmaciaMapper.FRANQUICIA = far.FRANQUICIA;
                farmaciaMapper.ID_FARMACIA = far.ID_FARMACIA;
                farmaciaMapper.ID_LISTAFARMACIA = far.ID_LISTAFARMACIA;
                farmaciaMapper.ID_VADEMECUM = far.ID_VADEMECUM;
                farmaciaMapper.MODOOPERACION = far.MODOOPERACION;
                farmaciaMapper.MONTOASEGURADO = far.MONTOASEGURADO;
                farmaciaMapper.SIGLAMONEDA = far.SIGLAMONEDA;
                farmaciaMapper.OPS = far.OPS;
                farmaciaMapper.ID_TIPOFACTURACION = far.ID_TIPOFACTURACION;
                listaFarmaciaMapper.Add(farmaciaMapper);
            }
            return listaFarmaciaMapper;
        }
    }
}