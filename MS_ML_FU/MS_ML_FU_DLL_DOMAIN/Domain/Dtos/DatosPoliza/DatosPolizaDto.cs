using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza
{
    public class DatosPolizaDto
    {
        [JsonProperty(PropertyName = "nroBizFlow")]
        public EstructuraEntera NroBizFlow { get; set; }

        [JsonProperty(PropertyName = "nroFormulario")]
        public EstructuraEntera NroFormulario { get; set; }

        [JsonProperty(PropertyName = "tipoPoliza")]
        public EstructuraEntera TipoPoliza { get; set; }

        [JsonProperty(PropertyName = "vigenciaInicial")]
        public EstructuraFecha VigenciaInicial { get; set; }

        [JsonProperty(PropertyName = "vigenciaFinal")]
        public EstructuraFecha VigenciaFinal { get; set; }

        [JsonProperty(PropertyName = "riesgo")]
        public EstructuraEntera Riesgo { get; set; }

        [JsonProperty(PropertyName = "moneda")]
        public EstructuraCadena Moneda { get; set; }

        [JsonProperty(PropertyName = "sucursal")]
        public EstructuraEntera Sucursal { get; set; }

        [JsonProperty(PropertyName = "estadoCobertura")]
        public EstructuraEntera EstadoCobertura { get; set; }

        [JsonProperty(PropertyName = "canalVenta")]
        public EstructuraEntera CanalVenta { get; set; }

        [JsonProperty(PropertyName = "lineaNegocio")]
        public EstructuraEntera LineaNegocio { get; set; }

        [JsonProperty(PropertyName = "nuevoNegocio")]
        public EstructuraCadena NuevoNegocio { get; set; }

        [JsonProperty(PropertyName = "addition")]
        public EstructuraCadena Addition { get; set; }

        [JsonProperty(PropertyName = "tipoAddition")]
        public EstructuraEntera TipoAddition { get; set; }

        [JsonProperty(PropertyName = "comentario")]
        public EstructuraCadena Comentario { get; set; }

        [JsonProperty(PropertyName = "idEstadoFormulario")]
        public EstructuraEntera IdEstadoFormualrio { get; set; }

        [JsonProperty(PropertyName = "idEstadoBizFlow")]
        public EstructuraEntera IdEstadoBizFlow { get; set; }

        [JsonProperty(PropertyName = "idFormularioDetalle")]
        public EstructuraEntera IdFormularioDetalle { get; set; }

        [JsonProperty(PropertyName = "nroPolizaSacs")]
        public EstructuraDecimal NroPolizaSacs { get; set; }

        [JsonProperty(PropertyName = "ubicacionesGeograficas")]
        public EstructuraListaReferencia UbicacionesGeograficas { get; set; }

    }
}
