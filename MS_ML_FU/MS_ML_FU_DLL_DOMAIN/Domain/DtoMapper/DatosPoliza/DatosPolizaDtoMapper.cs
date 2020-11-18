using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza
{
    public class DatosPolizaDtoMapper
    {
        [JsonProperty(PropertyName = "nroPoliza")]
        public Nullable<int> NRO_POLIZA { get; set; }

        [JsonProperty(PropertyName = "nroBizflow")]
        public Nullable<int> NRO_BIZFLOW { get; set; }

        [JsonProperty(PropertyName = "idTipoPoliza")]
        public Nullable<int> ID_TIPOPOLIZA { get; set; }

        [JsonProperty(PropertyName = "vigenteInicio")]
        public Nullable<System.DateTime> VIGENTE_INICIO { get; set; }

        [JsonProperty(PropertyName = "vigenteFinal")]
        public Nullable<System.DateTime> VIGENTE_FINAL { get; set; }

        [JsonProperty(PropertyName = "idRiesgo")]
        public Nullable<int> ID_RIESGO { get; set; }

        [JsonProperty(PropertyName = "siglaMoneda")]
        public string SIGLA_MONEDA { get; set; }

        [JsonProperty(PropertyName = "idSucursal")]
        public Nullable<int> ID_SUCURSAL { get; set; }

        [JsonProperty(PropertyName = "idEstadoCobertura")]
        public Nullable<int> ID_ESTADOCOBERTURA { get; set; }

        [JsonProperty(PropertyName = "idCanalVenta")]
        public Nullable<int> ID_CANALVENTA { get; set; }

        [JsonProperty(PropertyName = "idLineaNegocio")]
        public Nullable<int> ID_LINEANEGOCIO { get; set; }

        [JsonProperty(PropertyName = "comentario")]
        public string COMENTARIO { get; set; }

        [JsonProperty(PropertyName = "idTipoAdicion")]
        public Nullable<int> ID_TIPOADDITION { get; set; }

        [JsonProperty(PropertyName = "nuevoNegocio")]
        public string NUEVONEGOCIO { get; set; }

        [JsonProperty(PropertyName = "addition")]
        public string ADDITION { get; set; }

        [JsonProperty(PropertyName = "idEstadoFormulario")]
        public Nullable<int> ID_ESTADOFORMULARIO { get; set; }

        [JsonProperty(PropertyName = "idEstadoBizflow")]
        public Nullable<int> ID_ESTADOBISFLOW { get; set; }

        [JsonProperty(PropertyName = "idFormularioDetalle")]
        public Nullable<int> ID_FORMULARIODETALLE { get; set; }

        [JsonProperty(PropertyName = "nroPolizaSacs")]
        public Nullable<decimal> NRO_POLIZA_SACS { get; set; }
   

        // Compuestos

        [JsonProperty(PropertyName = "fuwebUbicacionGeografica")]
        public IEnumerable<UbicacionGeograficaDtoMapper> FUWEB_UBICACION_GEOGRAFICA { get; set; }

        [JsonProperty(PropertyName = "fuwebCanalVenta")]
        public CanalVentaDtoMapper FUWEB_P_CANALVENTA { get; set; }

        [JsonProperty(PropertyName = "fuwebLineaNegocio")]
        public LineaNegocioDtoMapper FUWEB_P_LINEANEGOCIO { get; set; }

        [JsonProperty(PropertyName = "fuwebRiesgo")]
        public RiesgoDtoMapper FUWEB_P_RIESGO { get; set; }

        [JsonProperty(PropertyName = "fuwebTipoAddition")]
        public TipoAdicionDtoMapper FUWEB_P_TIPOADDITION { get; set; }

        [JsonProperty(PropertyName = "fuwebTipoPoliza")]
        public TipoPolizaDtoMapper FUWEB_P_TIPOPOLIZA { get; set; }

    }
}
