using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using RestSharp;
using System.Collections.Generic;

namespace EJEMPLO.RestClients.Impl
{
    public class GitHubClient : IGitHubClient
    {
        public List<Repository> GetGithubRepositories()
        {
            var client = new RestClient("https://api.github.com/orgs/dotnet/repos");
            var response = client.Execute<List<Repository>>(new RestRequest());
            return response.Data;
        }

    }
}