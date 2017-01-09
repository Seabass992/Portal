using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Portal.Models.UserModels
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual PortalPrincipal CurrentUser => HttpContext.Current.User as PortalPrincipal;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new {controller = "Error", action = "AccessDenied"}));
                    }
                }

                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.User.Id.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new {controller = "Error", action = "AccessDenied"}));
                    }
                }
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}