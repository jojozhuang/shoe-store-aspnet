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
    public class RoleController : BaseController
    {
        private IAccountRepository accountRepository;

        public RoleController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("Role");
        }       

        public ViewResult List()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            //return View("Edit", new AppRole());
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppRole role)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                }
            }
            return View(role);
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            return View(role);
            //AppRole role = await RoleManager.FindByIdAsync(id);
            //string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            //IEnumerable<AppUser> members
            //    = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            //IEnumerable<AppUser> nonMembers = UserManager.Users.Except(members);
            //return View(new RoleEditModel
            //{
            //    Role = role,
            //    Members = members,
            //    NonMembers = nonMembers
            //});
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AppRole editrole)
        {
            if (ModelState.IsValid)
            {
                AppRole role = await RoleManager.FindByIdAsync(editrole.Id);
                if (role == null)
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "Role Not Found!");
                }
                else 
                {
                    MessageHelper.ClearMessage();
                    role.Name = editrole.Name;
                    IdentityResult result = await RoleManager.UpdateAsync(role);
                    if (!result.Succeeded)
                    {
                        MessageHelper.AppendMessage(result);
                    }
                    else
                    {
                        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", role.Name));
                        return RedirectToAction("List");
                    }
                    TempData["message"] = MessageHelper.GetMessage(EnumSevereLevel.Error);
                }
                return View(editrole);
            }
            else
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(editrole);
            }

            //IdentityResult result;
            //if (ModelState.IsValid)
            //{
            //    foreach (string userId in model.IdsToAdd ?? new string[] { })
            //    {
            //        result = await UserManager.AddToRoleAsync(userId, model.RoleName);
            //        if (!result.Succeeded)
            //        {
            //            TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
            //        }
            //    }
            //    foreach (string userId in model.IdsToDelete ?? new string[] { })
            //    {
            //        result = await UserManager.RemoveFromRoleAsync(userId, model.RoleName);
            //        if (!result.Succeeded)
            //        {
            //            TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
            //        }
            //    }
            //    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", model.RoleName));
            //    return RedirectToAction("List");
            //}            
            //else
            //{
            //    //There is something wrong with the data values
            //    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
            //    return View(model);
            //}
        }       

        //[HttpGet]
        //public ActionResult Delete(int roleId)
        //{
        //    Role deletedRole = accountRepository.DeleteRole(roleId);
        //    if (deletedRole != null)
        //    {
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedRole.RoleName));
        //    }
        //    return RedirectToAction("List");
        //}        

        public ViewResult Permissions(string id)
        {
            ViewBag.Roles = RoleManager.Roles;
            var rolePermissions = accountRepository.RolePermissions.Where(x => x.RoleId == id);
            var model = new RolePermissionViewModel(id, accountRepository.Permissions, rolePermissions);
            return View(model);
        }

        [HttpPost]
        public ActionResult Permissions(RolePermissionViewModel model)
        {
            ViewBag.Roles = RoleManager.Roles;
            //model.MenuCategories = menuRepository.MenuCategories;
            if (String.IsNullOrEmpty(model.SelectedRoleId))
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No role is selected!");
                return View(model);
            }
            //else if (model.SelectedMenuCategoryIds == null || model.SelectedMenuCategoryIds.Count<int>() == 0)
            //{
            //    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No Menu Categories are selected!");
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                accountRepository.DeleteRolePermissions(accountRepository.RolePermissions.Where(x => x.RoleId == model.SelectedRoleId));
                accountRepository.SaveRolePermission(model.SelectedRoleId, model.Permissions.Where(x => x.Selected).Select(x => x.PermissionId).ToArray());
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", RoleManager.FindById(model.SelectedRoleId).Name));

                return View(model);
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(model);
            }
        }
    }
}
