using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia
{
    public class WikimediaAvailability
    {
        public string orquestadorMarca { get; set; }

        [JsonProperty(PropertyName = "in_the_news")]
        public List<string> inTheNews { get; set; }

        [JsonProperty(PropertyName = "most_read")]
        public List<string> mostRead { get; set; }

    }
}
