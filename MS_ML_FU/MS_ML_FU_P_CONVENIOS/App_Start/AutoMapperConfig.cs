using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_P_CONVENIOS.Models;
using MS_ML_FU_P_CONVENIOS.Utilities;

namespace MS_ML_FU_P_CONVENIOS.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {                
                cfg.CreateMap<FUWEB_P_CONVENIO, ConvenioDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOCONVENIO, TipoConvenioDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOFACTURACION, TipoFacturacionDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_VADEMECUM, VademecumDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_CONVENIOOTROS, OtrosConveniosDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_CONVENIOFARMACIA, FarmaciaDtoMapper>().ReverseMap();
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}