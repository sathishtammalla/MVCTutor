using MVCTutor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTutor.Filters
{
    public class HeaderFooterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewResult vr = filterContext.Result as ViewResult;
            if (vr != null)
            {
                BaseViewModel bvm = vr.Model as BaseViewModel;
                if (bvm != null)
                {
                    bvm.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData = new FooterVM();
                    bvm.FooterData.CompanyName = "Sathish Tutorial Lab!";
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                    bvm.FooterData.Terms = "All Rights Reserved!";

                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}