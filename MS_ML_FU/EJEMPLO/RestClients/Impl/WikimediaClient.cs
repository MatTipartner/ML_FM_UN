using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EJEMPLO.RestClients.Impl
{
    public class WikimediaClient : IWikimediaClient
    {
        public List<WikimediaAvailability> GetWikimediaAvailability()
        {
            var client = new RestClient("https://wikimedia.org/api/rest_v1/feed/availability");
            var response = client.Execute<List<WikimediaAvailability>>(new RestRequest());
            return response.Data;
        }

    }
}