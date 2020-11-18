using System;
using Newtonsoft.Json;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraEntera : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public Nullable<Int32> Valor { get; set; }

      /*  [JsonProperty(PropertyName = "valorEspejo")]
        public Nullable<Int32> ValorEspejo { get; set; }*/
        public EstructuraEntera()
        {
            this.TipoDato = TiposDeDatos.TIPO_DATO_ENTERO;
        }

    }
}
