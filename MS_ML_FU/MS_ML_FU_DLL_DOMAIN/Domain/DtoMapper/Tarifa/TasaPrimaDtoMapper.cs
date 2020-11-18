using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa
{
    public class TasaPrimaDtoMapper
    {
        [JsonProperty(PropertyName = "idGrupoListaPrima")]
        public int ID_GRUPOLISTAPRIMA { get; set; }

        [JsonProperty(PropertyName = "idTarifaGrupo")] 
        public int ID_TARIFAGRUPO { get; set; }

        [JsonProperty(PropertyName = "desde")] 
        public int DESDE { get; set; }

        [JsonProperty(PropertyName = "hasta")] 
        public int HASTA { get; set; }

        [JsonProperty(PropertyName = "primaFija")]
        public Nullable<decimal> PRIMAFIJA { get; set; }

        [JsonProperty(PropertyName = "tasa")]
        public Nullable<decimal> TASA { get; set; }



    }
}
