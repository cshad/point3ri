using System.Web;
using System.Web.Mvc;

namespace point3ri_Alpha_0._51
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
