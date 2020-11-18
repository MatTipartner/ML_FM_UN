using MS_ML_FU_P_REQ_ASEG.Utilities;

namespace MS_ML_FU_P_REQ_ASEG.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Foo1, Foo2>().ReverseMap();
            });
            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}