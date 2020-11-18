﻿using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_P_REQ_ASEG.Utilities;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_REQ_ASEG.RestClients.Impl
{
    public class MsReqAsegClient : IMsReqAsegClient
    {
        private ValoresAmbiente vAmbiente = new ValoresAmbiente();

        public GetSettingDataRespuesta RespuestaCliente(GetSettingDataSolicitud soliRest)
        {
            try
            {
                var client = new RestClient(vAmbiente.ServicioMetLife);
                client.Authenticator = new HttpBasicAuthenticator(vAmbiente.UsuarioServicioMetLife, vAmbiente.ClaveServicioMetLife);
                //client.Encoding = Encoding.;

                var request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;

                string json = JsonConvert.SerializeObject(soliRest);
                request.AddJsonBody(json);
                var response = client.Execute<GetSettingDataRespuesta>(request);
                return response.Data;
            }
            catch
            {
                return null;
            }
        }
    }
}