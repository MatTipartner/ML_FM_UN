using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_P_TARIFA.Models;
using MS_ML_FU_P_TARIFA.Utilities;

namespace MS_ML_FU_P_TARIFA.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<FUWEB_P_DEFINICIONTRIBUTARIA, DefinicionTributariaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_TARIFAGRUPOLISTAESPECIAL, TasaEspecialDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_TARIFAGRUPOLISTAPRIMA, TasaPrimaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_TARIFAGRUPO, TarifaGrupoDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_TARIFA, TarifaDtoMapper>().ReverseMap();
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}