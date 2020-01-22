using System.Web;
using System.Web.Mvc;

namespace cs330215MIS4200_1045_sp20
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
