using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Varios
{
    public class TestObjectJson
    {
        [JsonProperty(PropertyName = "valor_A")]
        public string ValorA { get; set; }
        [JsonProperty(PropertyName = "valor_B")]
        public int ValorB { get; set; }
        public List<TestObjectJsonItem> list { get; set; }
    }
}
