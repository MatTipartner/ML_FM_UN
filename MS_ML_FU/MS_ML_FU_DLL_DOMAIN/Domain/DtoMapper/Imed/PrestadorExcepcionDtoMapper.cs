using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class PrestadorExcepcionDtoMapper
    {
        public int ID_PRESTADORES_EXCEPCION { get; set; }
        public int ID_PRESTADORGRUPOSACS { get; set; }
        public int ID_IMED { get; set; }

        public GrupoPrestadorSacsDtoMapper FUWEB_P_PRESTADORGRUPOSACS { get; set; }
    }
}
