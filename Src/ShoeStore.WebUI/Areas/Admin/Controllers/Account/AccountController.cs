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
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                //RedirectToAction("Index", "Home");
                return View("Error", new string[] { "Access Denied" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    Session["UserId"] = user.Id;
                    Session["UserName"] = user.UserName;
                    return Redirect(String.IsNullOrEmpty(returnUrl) ? Url.Action("Index", "Home") : returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
            //if (ModelState.IsValid) {
            //    //if (authProvider.Authenticate(model.UserName, model.Password)) {
            //    if (accountRepository.Authenticate(model.UserName, model.Password))
            //    {
            //        return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            //    } else {
            //        ModelState.AddModelError("", "Incorrect username or password");
            //        return View();
            //    }
            //} else {
            //    return View();
            //}
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login", "Account");
        }                
    }
}
