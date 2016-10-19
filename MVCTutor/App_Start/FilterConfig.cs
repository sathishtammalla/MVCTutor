using MVCTutor.Filters;
using System.Web;
using System.Web.Mvc;

namespace MVCTutor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute(),2);
            filters.Add(new HandleErrorAttribute
            {
                View = "Error"
            }, 1);
            //  filters.Add(new AuthorizeAttribute());
            filters.Add(new EmployeeExceptionFilter());
        }
    }
}
