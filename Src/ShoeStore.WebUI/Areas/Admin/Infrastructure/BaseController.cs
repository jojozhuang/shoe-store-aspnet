using Johnny.ShoeStore.Domain.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Routing;
using Johnny.ShoeStore.Domain.Concrete;
using Johnny.ShoeStore.WebUI.Areas.Admin.Models;
using Johnny.ShoeStore.Domain.Entities;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure
{
    //[Authorize(Roles = "BasicAdmin222")]
    [PermissionBasedAuthorizeAttribute]
    public class BaseController : Controller
    {
        private string controllerName = "";
        private string actionName = "";
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            controllerName = requestContext.RouteData.Values["controller"].ToString();
            actionName = requestContext.RouteData.Values["action"].ToString();
            if (AdminConstants.ActionNames.Contains(actionName))
                actionName = "List";
        }
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            
            ViewBag.AdminHome = "Admin Home";
            //ViewBag.AdminHome = "No authorization";
            ViewBag.Management = "Management";
            //context.Result = new RedirectResult("/Admin/Home/Index"); 

            BuildListAdd();
        }

        protected void SetPageHeader(string pageheader)
        {
            ViewBag.PageHeader = pageheader;
        }

        protected IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        protected AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        protected AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }

        private void BuildListAdd()
        {
            EFDbContext dbContext = new EFDbContext();
            var menus = dbContext.Menus.ToList();
            var menu = menus.Where(x => x.Controller == controllerName && x.Action == actionName).FirstOrDefault();

            List<ListAddModel> list = new List<ListAddModel>();
            if (menu != null && menu.MenuId != 0)
            {
                var pagebindings = dbContext.PageBindings.ToList();
                foreach (var item in pagebindings)
                {
                    if (item.ListMenuId == menu.MenuId || item.AddMenuId == menu.MenuId)
                    {
                        if (item.ListMenuId == item.AddMenuId)
                        {
                            ListAddModel listadd = new ListAddModel();
                            listadd.Title = item.PageTitle;
                            listadd.Action = menu.Action;
                            list.Add(listadd);
                        }
                        else
                        {
                            ListAddModel listitem = new ListAddModel();
                            listitem.Title = "List";
                            listitem.Action = menus.FirstOrDefault(x => x.MenuId == item.ListMenuId).Action;
                            list.Add(listitem);

                            ListAddModel additem = new ListAddModel();
                            additem.Title = "Add";
                            additem.Action = menus.FirstOrDefault(x => x.MenuId == item.AddMenuId).Action;
                            list.Add(additem);
                        }
                        break;
                    }
                }
            }

            ViewBag.ListAdds = list;
        }

        public IEnumerable<AppUser> GetAppUsersInRole(string roleName)
        {
            return from role in RoleManager.Roles
                   where role.Name == roleName
                   from userRoles in role.Users
                   join user in UserManager.Users
                   on userRoles.UserId equals user.Id
                   //where user.EmailConfirmed == true
                   //  && user.IsDeleted == false
                   select user;
        }
    }
}