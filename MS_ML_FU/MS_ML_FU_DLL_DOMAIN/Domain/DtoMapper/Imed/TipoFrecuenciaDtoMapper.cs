using System;


namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class TipoFrecuenciaDtoMapper
    {
        public int ID_TIPOFRECUENCIA { get; set; }
        
        public string NOMBRE { get; set; }
        
        public string VIGENTE { get; set; }
        
        public Nullable<short> ESTANDAR { get; set; }
    }
}
