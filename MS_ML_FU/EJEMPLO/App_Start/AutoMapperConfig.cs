using EJEMPLO.Models;
using EJEMPLO.Utilities;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;

namespace EJEMPLO.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<FUWEB_POLIZA, DatosPolizaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_UBICACION_GEOGRAFICA, UbicacionGeograficaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_CANALVENTA, CanalVentaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_LINEANEGOCIO, LineaNegocioDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_RIESGO, RiesgoDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOADDITION, TipoAdicionDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOPOLIZA, TipoPolizaDtoMapper>().ReverseMap();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}