using EJEMPLO.RestClients;
using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using Ninject;
using System.Collections.Generic;

namespace EJEMPLO.Services.Impl
{
    public class GitHubService : IGitHubService
    {
        private IGitHubClient apiClient;

        public List<Repository> GetGithubRepositories() => this.apiClient.GetGithubRepositories();

        [Inject]
        public void SetApiClient(IGitHubClient apiClient)
        {
            this.apiClient = apiClient;
        }

    }
}