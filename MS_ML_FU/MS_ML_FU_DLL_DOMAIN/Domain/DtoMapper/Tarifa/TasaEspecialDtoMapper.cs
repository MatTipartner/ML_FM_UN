using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa
{
    public class TasaEspecialDtoMapper
    {
        [JsonProperty(PropertyName = "idGrupoListaEspecial")] 
        public int ID_GRUPOLISTAESPECIAL { get; set; }
        [JsonProperty(PropertyName = "idTarifaGrupo")] 
        public int ID_TARIFAGRUPO { get; set; }
        [JsonProperty(PropertyName = "siglaRelacion")] 
        public string SIGLA_RELACION { get; set; }
        [JsonProperty(PropertyName = "desde")] 
        public int DESDE { get; set; }
        [JsonProperty(PropertyName = "hasta")] 
        public int HASTA { get; set; }
        [JsonProperty(PropertyName = "tasaCargo")]
        public decimal TASARECARGO { get; set; }
    }
}
