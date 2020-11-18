using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Transform
{
    public class ObjetoEntity
    {
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public Nullable<Int32> Rut { get; set; }
        public Nullable<DateTime> FechaNacimiento { get; set; }
    }
}
