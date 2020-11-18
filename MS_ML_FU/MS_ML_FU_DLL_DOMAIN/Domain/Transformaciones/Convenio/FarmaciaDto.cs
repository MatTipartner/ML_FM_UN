using Newtonsoft.Json;
using System;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio
{
    public class FarmaciaDto
    {
        [JsonProperty(PropertyName = "idListaFarmacia")]
        public int ID_LISTAFARMACIA { get; set; }

        [JsonProperty(PropertyName = "IdFarmacia")]
        public int ID_FARMACIA { get; set; }

        [JsonProperty(PropertyName = "idVademecum")]
        public int ID_VADEMECUM { get; set; }

        [JsonProperty(PropertyName = "idTipoFacturacion")]
        public int ID_TIPOFACTURACION { get; set; }

        [JsonProperty(PropertyName = "franquicia")]
        public string FRANQUICIA { get; set; }

        [JsonProperty(PropertyName = "siglaMoneda")]
        public string SIGLAMONEDA { get; set; }

        [JsonProperty(PropertyName = "montoAsegurado")]
        public Nullable<decimal> MONTOASEGURADO { get; set; }

        [JsonProperty(PropertyName = "ops")]
        public string OPS { get; set; }

        [JsonProperty(PropertyName = "modoOperacion")]
        public string MODOOPERACION { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }
    }
}
