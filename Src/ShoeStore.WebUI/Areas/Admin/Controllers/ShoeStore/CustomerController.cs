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
    public class CustomerController : BaseController
    {
        private IAccountRepository accountRepository;

        public CustomerController(IAccountRepository accountRepo)
        {
            accountRepository = accountRepo;
            base.SetPageHeader("Customer");
        }             

        public ViewResult List()
        {
            AppRole role = RoleManager.FindByName(AdminConstants.ROLE_CUSTOMER);
            if (role == null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is no role defined for Customer!");
                return View(new List<AppUser>());
            }
            else
            {
                return View(GetAppUsersInRole(AdminConstants.ROLE_CUSTOMER));
            }            
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppUser user, string password)
        {
            if (ModelState.IsValid)
            {
                AppUser newuser = new AppUser { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await UserManager.CreateAsync(newuser, password);
                if (result.Succeeded)
                {
                    result = UserManager.AddToRole(newuser.Id, "Customer");
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
                else
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, result);
                    return View(newuser);
                }
            }
            else
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(User);
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
        public async Task<ActionResult> Edit(AppUser edituser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindByIdAsync(edituser.Id);
                if (user == null)
                {
                    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "Customer Not Found!");
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
                    //IdentityResult validPass = null;
                    //if (password != string.Empty)
                    //{
                    //    validPass = await UserManager.PasswordValidator.ValidateAsync(password);
                    //    if (validPass.Succeeded)
                    //    {
                    //        user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                    //    }
                    //    else
                    //    {
                    //        MessageHelper.AppendMessage(validEmail);
                    //    }
                    //}
                    //if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded
                    //        && password != string.Empty && validPass.Succeeded))
                    if (validEmail.Succeeded)
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
                return View(user);
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
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "Customer Not Found!");
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


    }
}
