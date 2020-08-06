using Login.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Users)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccesController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acces/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}