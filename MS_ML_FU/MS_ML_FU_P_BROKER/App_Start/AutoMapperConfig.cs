using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_P_BROKER.Models;
using MS_ML_FU_P_BROKER.Utilities;

namespace MS_ML_FU_P_BROKER.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<FUWEB_BROKERCCTE, BrokerCcteDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_BROKERCORREDOR, BrokerCorradorDtoMapper>().ReverseMap();
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}