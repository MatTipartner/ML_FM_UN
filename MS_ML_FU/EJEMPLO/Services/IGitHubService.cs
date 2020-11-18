using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using System.Collections.Generic;

namespace EJEMPLO.Services
{
    public interface IGitHubService
    {
        List<Repository> GetGithubRepositories();

    }
}
