using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion
{
    /*
     * IMPORTANTE: Clase que debe ser removida.
     * Hasta SharpRest 106.11.7, la serializacion no funciona bien con Newtonsoft.
     * Segun https://github.com/adamfisher/RestSharp.Serializers.Newtonsoft.Json, desde la version 107 habra full soporte.
     * Por lo tanto, esta Clase solo suple conversiones especificas.
     * Cuando haya soporte, se debe utilizar de forma normal, similar que el resto de las llamadas
     * 
     * https://github.com/restsharp/RestSharp/blob/dev/releasenotes.md
     */
    public class JsonNetSerializer : IRestSerializer
    {
        public string Serialize(object obj) => JsonConvert.SerializeObject(obj);

        [System.Obsolete]
        public string Serialize(Parameter bodyParameter) => JsonConvert.SerializeObject(bodyParameter.Value);

        public T Deserialize<T>(IRestResponse response) {
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else {
                return default(T);
            }
          }

        public string[] SupportedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;

    }
}
