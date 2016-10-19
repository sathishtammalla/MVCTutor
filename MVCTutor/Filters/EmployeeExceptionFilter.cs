using MVCTutor.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutor.Filters
{
    public class EmployeeExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger log = new FileLogger();
            log.LogException(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ContentResult() {
                Content = "Sorry For the Error Please check the Log file for Error details"
            };

            base.OnException(filterContext);
        }
    }
}