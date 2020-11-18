using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio
{
    public class EstructuraFarmacia : EstructuraGeneral
    {
        [JsonProperty(PropertyName = "valor")]
        public IEnumerable<FarmaciaDto> Valor { get; set; }

        public EstructuraFarmacia()
        {
            this.Valor = new List<FarmaciaDto>();
            this.TipoDato = TiposDeDatos.TIPO_DATO_LISTA;
        }
    }
}
