using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.GitHub
{
    public class RepositoryOwner
    {

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    
    }
}
