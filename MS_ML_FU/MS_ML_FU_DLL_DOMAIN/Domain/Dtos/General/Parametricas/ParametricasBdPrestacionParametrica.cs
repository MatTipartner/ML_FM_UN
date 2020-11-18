using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas
{
    public class ParametricasBdPrestacionParametrica
    {
        [JsonProperty(PropertyName = "idPrestacion")]
        public int IdPrestacion { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public String Descripcion { get; set; }

        [JsonProperty(PropertyName = "IdPrestacionBasica")]
        public int IDPrestacionBasica { get; set; }

        [JsonProperty(PropertyName = "IdPrestacionGenerica")]
        public int IDPrestacionGenerica{ get; set; }

        [JsonProperty(PropertyName = "IdPrestacionSubGrupo")]
        public int IdPrestacionSubGrupo { get; set; }
    }
}
