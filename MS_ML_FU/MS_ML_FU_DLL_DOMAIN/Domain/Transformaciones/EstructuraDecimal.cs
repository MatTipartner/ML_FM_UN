using System;
using Newtonsoft.Json;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraDecimal : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public Nullable<decimal> Valor { get; set; }

       /* [JsonProperty(PropertyName = "valorEspejo")]
        public Nullable<decimal> ValorEspejo { get; set; }*/

        public EstructuraDecimal()
        {
            this.TipoDato = TiposDeDatos.TIPO_DATO_DECIMAL;
        }
    }
}
