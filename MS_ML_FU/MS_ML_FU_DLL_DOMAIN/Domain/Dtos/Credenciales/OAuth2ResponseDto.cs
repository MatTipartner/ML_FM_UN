using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales
{
    public class OAuth2ResponseDto
    {
        [JsonProperty(PropertyName = "access_token")]
        public String AccessToken { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public String TokenType { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public Int32 ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "refresh_token")]
        public String RefreshToken { get; set; }
        [JsonProperty(PropertyName = "error")]
        public String Error { get; set; }
    }
}
