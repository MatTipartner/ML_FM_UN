using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas { 
    public class GrupoFormularioDto
    {
        [JsonProperty(PropertyName = "idGrupo")]
        public int IdGrupo { get; set; }

        [JsonProperty(PropertyName = "nombreGrupo")]
        public int NombreGrupo { get; set; }
    }
}
