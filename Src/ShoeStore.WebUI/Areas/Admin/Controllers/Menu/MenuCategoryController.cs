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
    public class MenuCategoryController : BaseController
    {
        private IMenuRepository menuRepository;

        public MenuCategoryController(IMenuRepository menuRepo)
        {
            menuRepository = menuRepo;
            base.SetPageHeader("Menu Category");
         }

        public ViewResult List()
        {
            return View(menuRepository.MenuCategories);
        }

        public ViewResult Create()
        {
            return View("Edit", new MenuCategory());
        }

        public ViewResult Edit(int menuCategoryId)
        {
            MenuCategory menuCategory = menuRepository.MenuCategories.FirstOrDefault(p => p.MenuCategoryId == menuCategoryId);
            return View(menuCategory);
        }

        [HttpPost]
        public ActionResult Edit(MenuCategory menuCategory)
        {
            if (ModelState.IsValid)
            {
                menuRepository.SaveMenuCategory(menuCategory);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", menuCategory.MenuCategoryName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(menuCategory);
            }
        }

        [HttpGet]
        public ActionResult Delete(int menuCategoryId)
        {
            MenuCategory deletedMenuCategory = menuRepository.DeleteMenuCategory(menuCategoryId);
            if (deletedMenuCategory != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedMenuCategory.MenuCategoryName));
            }
            return RedirectToAction("List");
        }
     
	}
}