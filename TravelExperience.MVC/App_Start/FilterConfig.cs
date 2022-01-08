using System.Web;
using System.Web.Mvc;
using TravelExperience.MVC.Controllers.HelperClasses;

namespace TravelExperience.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
