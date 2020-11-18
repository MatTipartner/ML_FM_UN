using System;
using Newtonsoft.Json;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraCadena : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public String Valor { get; set; }

       /* [JsonProperty(PropertyName = "valorEspejo")]
        public String ValorEspejo { get; set; }*/
        public EstructuraCadena()
        {
            this.TipoDato = TiposDeDatos.TIPO_DATO_CADENA;
        }
    }
}
