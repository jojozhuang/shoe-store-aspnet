using Johnny.Library.Helper;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure;
using Johnny.ShoeStore.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private IMenuRepository menuRepository;
        private IAccountRepository accountRepository;

        public MenuController(IMenuRepository menuRepo, IAccountRepository accountRepo)
        {
            menuRepository = menuRepo;
            accountRepository = accountRepo;
            base.SetPageHeader("Menu");
        }

        public ViewResult List()
        {
            return View(menuRepository.View_Menus);
        }

        public ViewResult Create()
        {
            ViewBag.MenuCategories = menuRepository.MenuCategories;
            ViewBag.Permissions = accountRepository.Permissions;
            return View("Edit", new Menu() { IsDisplay = true });
        }

        public ViewResult Edit(int menuId)
        {
            ViewBag.MenuCategories = menuRepository.MenuCategories;
            ViewBag.Permissions = accountRepository.Permissions;
            Menu menu = menuRepository.Menus.FirstOrDefault(p => p.MenuId == menuId);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                menuRepository.SaveMenu(menu);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", menu.MenuName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                ViewBag.Permissions = accountRepository.Permissions;
                ViewBag.MenuCategories = menuRepository.MenuCategories;
                return View(menu);
            }
        }
        
        [HttpGet]
        public ActionResult Delete(int menuId)
        {
            Menu deletedMenu = menuRepository.DeleteMenu(menuId);
            if (deletedMenu != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedMenu.MenuName));
            }
            return RedirectToAction("Menu");
        }
        
	}
}