using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.GitHub;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub
{
    public class Repository
    {
        public string orquestadorMarca;

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public RepositoryOwner Owner { get; set; }

    }
}
