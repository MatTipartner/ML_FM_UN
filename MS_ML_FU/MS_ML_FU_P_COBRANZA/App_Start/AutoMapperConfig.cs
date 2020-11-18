using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_P_COBRANZA.Models;
using MS_ML_FU_P_COBRANZA.Utilities;

namespace MS_ML_FU_P_COBRANZA.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {   
                cfg.CreateMap<FUWEB_P_AQUIENCOBRANZA, AquienCobranzaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_CALCULOPRIMA, CalculoPrimaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_DESTINATARIOCOBRANZA, DestinatarioCobranzaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_RIESGOFACTURACION, RiesgoFacturacionDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOFACTURACIONCOBR, TipoFactutacionCobranzaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_TIPOCOBRO, TipoCobroDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_CONTRIBUTORIEDAD, ContributoriedadDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_COBRANZARIESGO, CobranzaRiesgoDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_COBRANZAGRUPO, CobranzaGrupoDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_COBRANZA, CobranzaDtoMapper>().ReverseMap();
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}