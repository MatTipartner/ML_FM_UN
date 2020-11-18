using EJEMPLO.RestClients;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using Ninject;
using System.Collections.Generic;

namespace EJEMPLO.Services
{
    public class WikimediaService : IWikimediaService
    {
        private IWikimediaClient apiClient;

        public List<WikimediaAvailability> GetWikimediaAvailability() => this.apiClient.GetWikimediaAvailability();

        [Inject]
        public void SetApiClient(IWikimediaClient apiClient)
        {
            this.apiClient = apiClient;
        }

    }
}