using System.Web;
using System.Web.Mvc;

namespace MS_ML_FU_ORQUESTADOR
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
