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
    public class TopMenuController : BaseController
    {
        private IMenuRepository menuRepository;

        public TopMenuController(IMenuRepository menuRepo)
        {
            menuRepository = menuRepo;
            base.SetPageHeader("Top Menu");
        }

        public ViewResult List()
        {
            //IEnumerable<View_TopMenu> topmenus = menuRepository.View_TopMenus;
            //var queryTopMenuIds =
            //    from topmenu in topmenus
            //    group topmenu by topmenu.TopMenuId into newGroup
            //    orderby newGroup.Key
            //    select newGroup;

            //List<TopMenu> list = new List<TopMenu>();
            //foreach (var idGroup in queryTopMenuIds)
            //{
            //    TopMenu newTopMenu = new TopMenu();
            //    newTopMenu.TopMenuId = idGroup.Key;
            //    //Console.WriteLine("Key: {0}", nameGroup.Key);
            //    foreach (var item in idGroup)
            //    {
            //        newTopMenu.TopMenuId = item.TopMenuId;
            //        newTopMenu.TopMenuName = item.TopMenuName;
            //        newTopMenu.PageLink = item.PageLink;
            //        MenuCategory category = new MenuCategory();
            //        category.MenuCategoryId = item.MenuCategoryId;
            //        category.MenuCategoryName = item.MenuCategoryName;
            //        newTopMenu.MenuCategories.Add(category);
            //    }
            //    list.Add(newTopMenu);
            //}
            return View(menuRepository.TopMenus);
        }
        
        public ViewResult Create()
        {
            return View("Edit", new TopMenu());
        }

        public ViewResult Edit(int topMenuId)
        {
            TopMenu TopMenu = menuRepository.TopMenus.FirstOrDefault(p => p.TopMenuId == topMenuId);
            return View(TopMenu);
        }

        [HttpPost]
        public ActionResult Edit(TopMenu topMenu)
        {
            if (ModelState.IsValid)
            {
                menuRepository.SaveTopMenu(topMenu);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", topMenu.TopMenuName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(topMenu);
            }
        }

        [HttpGet]
        public ActionResult Delete(int topMenuId)
        {
            TopMenu deletedTopMenu = menuRepository.DeleteTopMenu(topMenuId);
            if (deletedTopMenu != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedTopMenu.TopMenuName));
            }
            return RedirectToAction("List");
        }

        public ViewResult Binding(int id)
        {
            ViewBag.TopMenus = menuRepository.TopMenus;
            var topMenuBindings = menuRepository.TopMenuBindings.Where(x => x.TopMenuId == id);
            var model = new TopMenuViewModel(id, menuRepository.MenuCategories, topMenuBindings);
            return View(model);
        }

        [HttpPost]
        public ActionResult Binding(TopMenuViewModel model)
        {
            ViewBag.TopMenus = menuRepository.TopMenus;
            //model.MenuCategories = menuRepository.MenuCategories;
            if (model.SelectedTopMenuId == 0)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No Top Menu is selected!");
                return View(model);
            }
            //else if (model.SelectedMenuCategoryIds == null || model.SelectedMenuCategoryIds.Count<int>() == 0)
            //{
            //    TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No Menu Categories are selected!");
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                menuRepository.DeleteTopMenuBindings(menuRepository.TopMenuBindings.Where(x => x.TopMenuId == model.SelectedTopMenuId));
                menuRepository.SaveTopMenuBinding(model.SelectedTopMenuId, model.MenuCategories.Where(x => x.Selected).Select(x => x.MenuCategoryId).ToArray());                

                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been saved!", model.SelectedTopMenuId));
                //if (String.IsNullOrEmpty(model.ControllerName))
                //    return RedirectToAction("List"); //Return to current controller
                //else
                //    return RedirectToAction("List", model.ControllerName); //Return to User controller
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