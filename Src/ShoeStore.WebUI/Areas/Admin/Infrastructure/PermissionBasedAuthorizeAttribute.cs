using Johnny.ShoeStore.Domain.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.Domain.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    public class PermissionBasedAuthorizeAttribute : AuthorizeAttribute
    {
        private string contoller = "";
        private readonly string[] allowedroles;  
        public PermissionBasedAuthorizeAttribute(params string[] roles)  
        {  
            this.allowedroles = roles;  
        }

        public override void OnAuthorization(AuthorizationContext filterContext) 
        {
            contoller = filterContext.RouteData.GetRequiredString("controller");
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                // The user is not authenticated
                return false;
            }

            EFDbContext context = new EFDbContext();
            var permission = context.sp_GetUserPermission(httpContext.User.Identity.Name, contoller);
            return permission > 0;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }        

    }
}