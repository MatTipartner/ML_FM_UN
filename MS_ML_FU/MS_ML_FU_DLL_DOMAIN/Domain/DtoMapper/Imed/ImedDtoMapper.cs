using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class ImedDtoMapper
    {
        public int ID_IMED { get; set; }
        
        public int ID_TIPOIMED { get; set; }
        
        public int ID_AGRUPACION { get; set; }

        public virtual IEnumerable<FrecuenciaDtoMapper> FUWEB_IMEDFRECUENCIA { get; set; }
        
        public virtual IEnumerable<PrestadorDtoMapper> FUWEB_IMEDPRESTADORES { get; set; }
        
        public virtual IEnumerable<PrestadorExcepcionDtoMapper> FUWEB_IMEDPRESTADORESEXCEPCION { get; set; }
        
        public virtual IEnumerable<TopeMontoDtoMapper> FUWEB_IMEDTOPEMONTO { get; set; }

    }
}
