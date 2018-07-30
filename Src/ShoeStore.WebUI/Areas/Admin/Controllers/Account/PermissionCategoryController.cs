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
    public class PermissionCategoryController : BaseController
    {
        private IAccountRepository accountRepository;
        
        public PermissionCategoryController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("Permission Category");
        }

        public ViewResult List()
        {
            return View(accountRepository.PermissionCategories);
        }

        public ViewResult Create()
        {
            return View("Edit", new PermissionCategory());
        }

        public ViewResult Edit(int permissionCategoryId)
        {
            PermissionCategory permissionCategory = accountRepository.PermissionCategories.FirstOrDefault(p => p.PermissionCategoryId == permissionCategoryId);
            return View(permissionCategory);
        }

        [HttpPost]
        public ActionResult Edit(PermissionCategory permissionCategory)
        {
            if (ModelState.IsValid)
            {
                accountRepository.SavePermissionCategory(permissionCategory);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", permissionCategory.PermissionCategoryName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(permissionCategory);
            }
        }

        [HttpGet]
        public ActionResult Delete(int permissionCategoryId)
        {
            PermissionCategory deletedPermissionCategory = accountRepository.DeletePermissionCategory(permissionCategoryId);
            if (deletedPermissionCategory != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedPermissionCategory.PermissionCategoryName));
            }
            return RedirectToAction("List");
        }
                       
    }
}
