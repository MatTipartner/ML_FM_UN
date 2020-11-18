

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class PrestadorDtoMapper
    {
        public int ID_PRESTADORES { get; set; }
        
        public int ID_PRESTADORGRUPO { get; set; }
        
        public int ID_IMED { get; set; }

        public GrupoPrestadorDtoMapper FUWEB_P_PRESTADORGRUPO { get; set; }
    }
}
