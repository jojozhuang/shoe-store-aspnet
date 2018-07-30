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
    public class PermissionController : BaseController
    {
        private IAccountRepository accountRepository;

        public PermissionController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("Permission");
        }                      

        public ViewResult List()
        {
            return View(accountRepository.View_Permissions);
        }

        public ViewResult Create()
        {
            ViewBag.PermissionCategories = accountRepository.PermissionCategories.ToList();
            return View("Edit", new Permission());
        }

        public ViewResult Edit(int permissionId)
        {
            ViewBag.PermissionCategories = accountRepository.PermissionCategories.ToList();
            Permission permission = accountRepository.Permissions.FirstOrDefault(p => p.PermissionId == permissionId);
            return View(permission);
        }

        [HttpPost]
        public ActionResult Edit(Permission permission)
        {
            if (ModelState.IsValid)
            {
                accountRepository.SavePermission(permission);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", permission.PermissionName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                ViewBag.PermissionCategories = accountRepository.PermissionCategories.ToList();
                return View(permission);
            }
        }

        [HttpGet]
        public ActionResult Delete(int permissionId)
        {
            Permission deletedPermission = accountRepository.DeletePermission(permissionId);
            if (deletedPermission != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedPermission.PermissionName));
            }
            return RedirectToAction("List");
        }
                
    }
}
