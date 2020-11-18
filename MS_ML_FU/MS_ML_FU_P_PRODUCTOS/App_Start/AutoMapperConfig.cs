using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_P_PRODUCTOS.Models;
using MS_ML_FU_P_PRODUCTOS.Utilities;

namespace MS_ML_FU_P_PRODUCTOS.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<FUWEB_PRODUCTOCASCADA, CascadaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_P_COBERTURA, CoberturaDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_PRODUCTOLIST_SALUD, ProductoSaludDetalleDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_PRODUCTOLIST_VIDAAP, ProductoVidaApDetalleDtoMapper>().ReverseMap();
                cfg.CreateMap<FUWEB_PRODUCTO_VIDAAP, ProductoVidaApDtoMapper>().ReverseMap();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}