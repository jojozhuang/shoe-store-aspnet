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
    public class PageBindingController : BaseController
    {
        private IMenuRepository menuRepository;

        public PageBindingController(IMenuRepository menuRepo)
        {
            menuRepository = menuRepo;
            base.SetPageHeader("Page Binding");
        }

        public ViewResult List()
        {
            return View(menuRepository.View_PageBindings);
        }

        public ViewResult Create()
        {
            ViewBag.MenuCategories = menuRepository.MenuCategories;
            ViewBag.Menus = menuRepository.Menus;
            return View("Edit", new PageBinding());
        }

        public ViewResult Edit(int pageBindingId)
        {
            ViewBag.MenuCategories = menuRepository.MenuCategories;
            ViewBag.Menus = menuRepository.Menus;
            PageBinding pageBinding = menuRepository.PageBindings.FirstOrDefault(p => p.PageBindingId == pageBindingId);
            return View(pageBinding);
        }

        [HttpPost]
        public ActionResult Edit(PageBinding pageBinding)
        {
            if (ModelState.IsValid)
            {
                menuRepository.SavePageBinding(pageBinding);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", pageBinding.PageTitle));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                ViewBag.MenuCategories = menuRepository.MenuCategories;
                ViewBag.Menus = menuRepository.Menus;
                return View(pageBinding);
            }
        }

        [HttpGet]
        public ActionResult Delete(int pageBindingId)
        {
            PageBinding deletedPageBinding = menuRepository.DeletePageBinding(pageBindingId);
            if (deletedPageBinding != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedPageBinding.PageTitle));
            }
            return RedirectToAction("List");
        }       
	}
}