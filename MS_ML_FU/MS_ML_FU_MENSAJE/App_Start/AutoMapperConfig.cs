using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_MENSAJE.Models;
using MS_ML_FU_MENSAJE.Utilities;

namespace MS_ML_FU_MENSAJE.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<FUWEB_P_ATRIBUTOPESTANA, AtributoPestanaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_ESTADOATRIBUTO ,EstadoAtributoDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_MENSAJES, MensajeDtoMapper>().ReverseMap();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}