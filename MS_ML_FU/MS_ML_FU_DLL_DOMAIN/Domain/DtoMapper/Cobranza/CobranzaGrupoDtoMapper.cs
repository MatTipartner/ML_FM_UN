using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class CobranzaGrupoDtoMapper
    {
        [JsonProperty(PropertyName = "idCobranzaGrupo")] 
        public int ID_COBRANZAGRUPO { get; set; }

        [JsonProperty(PropertyName = "contributoriedad")] 
        public string CONTRIBUTORIEDAD { get; set; }

        [JsonProperty(PropertyName = "idContributoriedad")] 
        public Nullable<int> ID_CONTRIBUTORIEDAD { get; set; }

        [JsonProperty(PropertyName = "porcentajeContratante")] 
        public Nullable<int> PORCENTAJECONTRATANTE { get; set; }

        [JsonProperty(PropertyName = "procentajeAsegurado")] 
        public Nullable<int> PORCENTAJEASEGURADO { get; set; }

        [JsonProperty(PropertyName = "especialContributoriedad")] 
        public string ESPECIALCONTRIBUTORIEDAD { get; set; }
        
        [JsonProperty(PropertyName = "idAQuienCobranza")] 
        public Nullable<int> ID_AQUIENCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "siglaTipoFaatura")] 
        public string SIGLA_TIPOFACTURA { get; set; }

        [JsonProperty(PropertyName = "rutFactutacion")] 
        public Nullable<int> RUT_FACTURACION { get; set; }

        [JsonProperty(PropertyName = "dvFacturacion")] 
        public string DV_FACTURACION { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")] 
        public int ID_AGRUPACION { get; set; }

        [JsonProperty(PropertyName = "aQuienCobranza")] 
        public AquienCobranzaDtoMapper FUWEB_P_AQUIENCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "cobranzaRiesgo")] 
        public IEnumerable<CobranzaRiesgoDtoMapper> FUWEB_COBRANZARIESGO { get; set; }

        [JsonProperty(PropertyName = "pContributoriedad")] 
        public ContributoriedadDtoMapper FUWEB_P_CONTRIBUTORIEDAD { get; set; }
    }
}
