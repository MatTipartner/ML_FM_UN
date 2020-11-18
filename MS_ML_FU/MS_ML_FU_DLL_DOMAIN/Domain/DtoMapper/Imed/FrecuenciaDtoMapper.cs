using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class FrecuenciaDtoMapper
    {
        public int ID_FRECUENCIA { get; set; }
        
        public Nullable<int> ID_TIPOFRECUENCIA { get; set; }
        
        public int CANTIDAD { get; set; }
        
        public int ID_IMED { get; set; }

        public TipoFrecuenciaDtoMapper FUWEB_P_TIPOFRECUENCIA { get; set; }
    }
}
