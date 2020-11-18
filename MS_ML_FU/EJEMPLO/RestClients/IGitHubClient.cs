using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using System.Collections.Generic;

namespace EJEMPLO.RestClients
{
    public interface IGitHubClient
    {
        List<Repository> GetGithubRepositories();

    }
}
