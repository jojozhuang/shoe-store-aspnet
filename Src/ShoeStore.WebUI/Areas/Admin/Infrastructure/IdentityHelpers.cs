using Johnny.ShoeStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr
                = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }

        public static MvcHtmlString GetRoleName(this HtmlHelper html, string id)
        {
            AppRoleManager mgr
                = HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.Name);
        }
    }
}