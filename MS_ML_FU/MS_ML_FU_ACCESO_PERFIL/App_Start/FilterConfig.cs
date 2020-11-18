using System.Web;
using System.Web.Mvc;

namespace MS_ML_FU_ACCESO_PERFIL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
