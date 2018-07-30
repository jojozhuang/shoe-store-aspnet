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
    public class UserRoleController : BaseController
    {
        private IAccountRepository accountRepository;
        
        public UserRoleController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("User Role");
        }             

        //public ViewResult List()
        //{
        //    return View(accountRepository.View_AdminRoles);
        //}

        //public ViewResult Edit(int adminId)
        //{
        //    ViewBag.Administrators = accountRepository.Administrators.ToList();
        //    ViewBag.Roles = accountRepository.Roles.ToList();
        //    AdminRole adminRole = accountRepository.AdminRoles.FirstOrDefault(p => p.AdminId == adminId);
        //    return View(adminRole);
        //}

        //[HttpPost]
        //public ActionResult Edit(AdminRole adminRole)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        accountRepository.SaveAdminRole(adminRole);
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", adminRole.AdminId));
        //        return RedirectToAction("List");
        //    }
        //    else
        //    {
        //        //There is something wrong with the data values
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
        //        ViewBag.Administrators = accountRepository.Administrators.ToList();
        //        ViewBag.Roles = accountRepository.Roles.ToList();
        //        return View(adminRole);
        //    }
        //}

        //public ViewResult Create()
        //{
        //    ViewBag.Administrators = accountRepository.Administrators.ToList();
        //    ViewBag.Roles = accountRepository.Roles.ToList();
        //    return View("Edit", new AdminRole());
        //}

        //[HttpGet]
        //public ActionResult Delete(int adminId)
        //{
        //    AdminRole deletedAdminRole = accountRepository.DeleteAdminRole(adminId);
        //    if (deletedAdminRole != null)
        //    {
        //        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", adminId));
        //    }
        //    return RedirectToAction("List");
        //} 

        public ViewResult List()
        {
            return View(UserManager.Users);
        }

        public ViewResult Edit(string id, string controllername = "")
        {
            ViewBag.Users = UserManager.Users;
            var selectedUser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var model = new UserRoleViewModel(selectedUser, controllername, RoleManager.Roles);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserRoleViewModel model)
        {
            ViewBag.Users = UserManager.Users;

            if (String.IsNullOrEmpty(model.SelectedUserId))
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No user is selected!");
                return View(model);
            }            

            IdentityResult result;

            if (ModelState.IsValid)
            {
                //delete existing roles
                var selectedUser = UserManager.Users.Where(x => x.Id == model.SelectedUserId).FirstOrDefault();
                string[] currentRoles = RoleManager.Roles.ToList().Where(x => selectedUser.Roles.Any(y => y.RoleId == x.Id)).Select(x => x.Name).ToArray();
                if (currentRoles.Length > 0)
                {
                    result = UserManager.RemoveFromRoles(model.SelectedUserId, currentRoles);

                    if (!result.Succeeded)
                    {
                        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                        return View(model);
                    }
                }

                //add new roles
                List<SelectRoleEditorViewModel> selectedRoles = model.Roles.Where(x => x.Selected).ToList();
                foreach (var role in selectedRoles)
                {
                    result = UserManager.AddToRole(model.SelectedUserId, role.RoleName);
                    if (!result.Succeeded)
                    {
                        TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                        return View(model);
                    }
                }

                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", selectedUser.UserName));
                if (String.IsNullOrEmpty(model.ControllerName))
                    return RedirectToAction("List"); //Return to current controller
                else
                    return RedirectToAction("List", model.ControllerName); //Return to User controller
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(model);
            }
        }

        public string GetRoles(string id)
        {
            var selectedUser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            var model = new UserRoleViewModel
            {
                //SelectedRoleIds = selectedUser.Roles.Select(x => x.RoleId).ToArray(),
                Roles = GetViewModelRoles(),
                SelectedUserId = id
            };

            return new JavaScriptSerializer().Serialize(model);
        }

        private List<SelectRoleEditorViewModel> GetViewModelRoles()
        {
            var roles = new List<SelectRoleEditorViewModel>();
            foreach (var role in RoleManager.Roles)
            {
                // An EditorViewModel will be used by Editor Template:
                var srevm = new SelectRoleEditorViewModel(role);
                roles.Add(srevm);
            }

            return roles;
        }
    }
}
