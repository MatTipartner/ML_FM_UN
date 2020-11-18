using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker
{
    public class BrokerDto
    {
        [JsonProperty(PropertyName = "idCorredor")]
        public EstructuraEntera IdCorredor { get; set; }

        [JsonProperty(PropertyName = "rutCorredor")]
        public EstructuraEntera RutCorredor { get; set; }

        [JsonProperty(PropertyName = "dvCorredor")]
        public EstructuraCadena DvCorredor { get; set; }

        [JsonProperty(PropertyName = "nombreCorredor")]
        public EstructuraCadena NombreCorredor { get; set; }

        [JsonProperty(PropertyName = "telefono")]
        public Nullable<int> Telefono { get; set; }

        [JsonProperty(PropertyName = "giro")]
        public EstructuraCadena Giro { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public EstructuraCadena Direccion { get; set; }

        [JsonProperty(PropertyName = "ciudad")]
        public EstructuraCadena Ciudad { get; set; }

        [JsonProperty(PropertyName = "comuna")]
        public EstructuraCadena Comuna { get; set; }

        [JsonProperty(PropertyName = "polizaGarantiaVigente")]
        public EstructuraCadena PolizaGarantiaVigente { get; set; }

        [JsonProperty(PropertyName = "nombreContacto")]
        public EstructuraCadena NombreContacto { get; set; }

        [JsonProperty(PropertyName = "email")]
        public EstructuraCadena Email { get; set; }

        [JsonProperty(PropertyName = "formaPago")]
        public EstructuraEntera FormaPago { get; set; }

        [JsonProperty(PropertyName = "tipoCuneta")]
        public EstructuraEntera TipoCuenta { get; set; }

        [JsonProperty(PropertyName = "nroCuenta")]
        public EstructuraEntera NroCuenta { get; set; }

        [JsonProperty(PropertyName = "banco")]
        public EstructuraEntera Banco { get; set; }

        [JsonProperty(PropertyName = "idHolding")]
        public EstructuraEntera IdHolding { get; set; }

        [JsonProperty(PropertyName = "idAdministrador")]
        public EstructuraCadena IdAdministrador { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoCobranza")]
        public EstructuraCadena IdEjecutivoCobranza { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoComercial")]
        public EstructuraCadena IdEjecutivoComercial { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoMovimiento")]
        public EstructuraCadena IdEjecutivoMovimiento { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public EstructuraEntera IdAgrupacion { get; set; }

        /**--- CONTRATANTE---**/
        [JsonProperty(PropertyName = "idContratante")]
        public EstructuraEntera IdContratante { get; set; }

        [JsonProperty(PropertyName = "rutContratante")]
        public EstructuraEntera RutContratante{ get; set; }

        [JsonProperty(PropertyName = "dvContratante")]
        public EstructuraCadena DvContratante { get; set; }

        [JsonProperty(PropertyName = "nombreContratante")]
        public EstructuraCadena NombreContratante { get; set; }

        [JsonProperty(PropertyName = "grupoEmpresaCont")]
        public EstructuraCadena GrupoEmpresaCont { get; set; }

        [JsonProperty(PropertyName = "telefonCont")]
        public EstructuraEntera TelefonCont { get; set; }

        [JsonProperty(PropertyName = "direccionCont")]
        public EstructuraCadena DireccionCont { get; set; }

        [JsonProperty(PropertyName = "comunaCont")]
        public EstructuraCadena ComunaCont { get; set; }

        [JsonProperty(PropertyName = "ciudadCont")]
        public EstructuraCadena CiudadCont { get; set; }

        [JsonProperty(PropertyName = "giroCont")]
        public EstructuraCadena GiroCont { get; set; }

        [JsonProperty(PropertyName = "nombreContactoCont")]
        public EstructuraCadena NombreContactoCont { get; set; }

        [JsonProperty(PropertyName = "emailCont")]
        public EstructuraCadena EmailCont { get; set; }

        [JsonProperty(PropertyName = "nombreMandante")]
        public EstructuraCadena nombreMandante { get; set; }

        [JsonProperty(PropertyName = "rutMandante")]
        public EstructuraCadena RutMandante { get; set; }


        /**--- FILIAL --**/
        [JsonProperty(PropertyName = "idFilial")]
        public EstructuraEntera IdFilial { get; set; }

        [JsonProperty(PropertyName = "rutFilial")]
        public EstructuraEntera RutFilial { get; set; }

        [JsonProperty(PropertyName = "dvFilial")]
        public EstructuraCadena DvFilial { get; set; }

        [JsonProperty(PropertyName = "nombreFilial")]
        public EstructuraCadena NombreFilial { get; set; }

        [JsonProperty(PropertyName = "grupoEmpresaFilial")]
        public EstructuraCadena GrupoEmpresaFilial { get; set; }

        [JsonProperty(PropertyName = "tlefonFilial")]
        public EstructuraEntera TelefonFilial { get; set; }

        [JsonProperty(PropertyName = "direccionFilialt")]
        public EstructuraCadena DireccionFilialt { get; set; }

        [JsonProperty(PropertyName = "comunaFilial")]
        public EstructuraCadena ComunaFilial { get; set; }

        [JsonProperty(PropertyName = "ciudadFilial")]
        public EstructuraCadena CiudadFilial { get; set; }

        [JsonProperty(PropertyName = "giroFilial")]
        public EstructuraCadena GiroFilial { get; set; }

        [JsonProperty(PropertyName = "nombreContactoFilial")]
        public EstructuraCadena NombreContactoFilial { get; set; }

        [JsonProperty(PropertyName = "emailFilial")]
        public EstructuraCadena EmailFilial { get; set; }

    }
}
