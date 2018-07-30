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
    public class UserController : BaseController
    {
        private IAccountRepository accountRepository;              

        public UserController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("User");
        }             

        public ViewResult List()
        {
            return View(UserManager.Users);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppUser user, string password)
        {
            AppUser newuser = new AppUser { UserName = user.UserName, Email = user.Email };
            IdentityResult result = await UserManager.CreateAsync(newuser, password);
            if (result.Succeeded)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", newuser.UserName));
                return RedirectToAction("List");
            }
            else
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                return View(newuser);
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AppUser edituser, string password)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindByIdAsync(edituser.Id);
                if (user == null)
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "User Not Found!");
                }
                else
                {
                    MessageHelper.ClearMessage();
                    user.UserName = edituser.UserName;
                    user.Email = edituser.Email;
                    IdentityResult validEmail
                        = await UserManager.UserValidator.ValidateAsync(user);
                    if (!validEmail.Succeeded)
                    {
                        MessageHelper.AppendMessage(validEmail);
                    }
                    IdentityResult validPass = null;
                    if (password != string.Empty)
                    {
                        validPass = await UserManager.PasswordValidator.ValidateAsync(password);
                        if (validPass.Succeeded)
                        {
                            user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                        }
                        else
                        {
                            MessageHelper.AppendMessage(validEmail);
                        }
                    }
                    if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded
                            && password != string.Empty && validPass.Succeeded))
                    {
                        IdentityResult result = await UserManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", user.UserName));
                            return RedirectToAction("List");
                        }
                        else
                        {
                            MessageHelper.AppendMessage(result);
                        }
                    }
                    TempData["message"] = MessageHelper.GetMessage(EnumSevereLevel.Error);
                }                
                return View(User);
            }
            else
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(User);
            }
        }        

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "User Not Found!");
            }
            else
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", user.UserName));
                }
                else
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                }
            }    

            return RedirectToAction("List");
        }

        public ViewResult Roles(string id)
        {
            ViewBag.Users = UserManager.Users;
            var selectedUser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var model = new UserRoleViewModel(selectedUser, "", RoleManager.Roles);
            return View(model);
        }

        [HttpPost]
        public ActionResult Roles(UserRoleViewModel model)
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
    }
}
