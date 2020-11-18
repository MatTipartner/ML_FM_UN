using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJEMPLO.Services
{
    public interface IWikimediaService
    {

        List<WikimediaAvailability> GetWikimediaAvailability();

    }
}
