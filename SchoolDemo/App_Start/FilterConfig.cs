using SchoolDemo.Filters;
using System.Web;
using System.Web.Mvc;

namespace SchoolDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new DbSaveExceptionAttribute());
        }
    }
}
