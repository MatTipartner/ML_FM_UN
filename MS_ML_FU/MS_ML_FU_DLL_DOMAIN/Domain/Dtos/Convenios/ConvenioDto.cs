using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios
{
    public class ConvenioDto
    {
        [JsonProperty(PropertyName = "listaOtrosConvenios")]
        public EstructuraOtrosConvenios ListaOtrosConvenios { get; set; }

        [JsonProperty(PropertyName = "listFarmacia")]
        public EstructuraFarmacia ListFarmacia { get; set; }
    }
}
