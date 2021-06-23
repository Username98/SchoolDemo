using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SchoolDemo.Filters
{
    public class DbSaveExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
                    {
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectResult("~/Content/DbSaveErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}