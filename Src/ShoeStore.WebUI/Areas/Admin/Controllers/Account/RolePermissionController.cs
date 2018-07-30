using System.Linq;
using System.Web.Mvc;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure.Abstract;
using Johnny.ShoeStore.WebUI.Models;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.Library.Helper;
using System.Web.Security;
using System;
using System.Web;
using System.Collections.Generic;
using Johnny.ShoeStore.WebUI.Areas.Admin.Models;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using Johnny.ShoeStore.Domain.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class RolePermissionController : BaseController
    {
        private IAccountRepository accountRepository;
        
        public RolePermissionController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("Role Permission");
        }             

        //public ViewResult List()
        //{
        //    ViewBag.Roles = RoleManager.Roles;
        //    var model = new RolePermissionViewModel
        //    {
        //        SelectedPermissionIds = new int[] { },
        //        Permissions = accountRepository.Permissions,
        //        SelectedRoleId = ""
        //    };
        //    return View(model);
        //}
        
        //[HttpPost]
        //public ActionResult List(RolePermissionViewModel model)
        //{
        //    ViewBag.Roles = RoleManager.Roles;
        //    model.Permissions = accountRepository.Permissions;
        //    if (String.IsNullOrEmpty(model.SelectedRoleId))
        //    {
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No role is selected!");
        //        return View(model);
        //    }
        //    else if (model.SelectedPermissionIds == null || model.SelectedPermissionIds.Count<int>() == 0)
        //    {
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No permissions are selected!");
        //        return View(model);
        //    }
        //    else
        //    {
        //        accountRepository.DeleteRolePermissions(accountRepository.RolePermissions.Where(x => x.RoleId == model.SelectedRoleId));
        //        accountRepository.SaveRolePermission(model.SelectedRoleId, model.SelectedPermissionIds);
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", RoleManager.FindById(model.SelectedRoleId).Name));
        //        return View(model);
        //    }
        //}

        //public string GetPermissions(string id)
        //{
        //    var permissions = accountRepository.RolePermissions.Where(x => x.RoleId == id);

        //    List<int> selectedPermissions = new List<int>();
        //    foreach (var permission in permissions)
        //    {
        //        selectedPermissions.Add(permission.PermissionId);
        //    }

        //    var model = new RolePermissionViewModel
        //    {
        //        SelectedPermissionIds = selectedPermissions.ToArray(),
        //        Permissions = accountRepository.Permissions,
        //        SelectedRoleId = id
        //    };

        //    return new JavaScriptSerializer().Serialize(model);
        //}
    }
}
