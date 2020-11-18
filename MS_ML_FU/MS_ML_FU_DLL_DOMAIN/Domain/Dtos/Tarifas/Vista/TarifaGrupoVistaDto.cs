using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista
{
    public class TarifaGrupoVistaDto
    {
        [JsonProperty(PropertyName = "idTarifaGrupo")]
        public int ID_TARIFAGRUPO { get; set; }

        [JsonProperty(PropertyName = "idCobertura")]
        public int ID_COBERTURA { get; set; }

        [JsonProperty(PropertyName = "idTipoProducto")]
        public int ID_TIPOPRODUCTO { get; set; }

        [JsonProperty(PropertyName = "idDefinicionTributaria")]
        public int ID_DEFINICIONTRIBUTARIA { get; set; }

        [JsonProperty(PropertyName = "grupoFamiliar")]
        public string GRUPOFAMILIAR { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

        [JsonProperty(PropertyName = "tasaPrima")]
        public IEnumerable<TasaPrimaDtoMapper> FUWEB_TARIFAGRUPOLISTAPRIMA { get; set; }

        [JsonProperty(PropertyName = "tasaEspecial")]
        public IEnumerable<TasaEspecialDtoMapper> FUWEB_TARIFAGRUPOLISTAESPECIAL { get; set; }
    }
}
