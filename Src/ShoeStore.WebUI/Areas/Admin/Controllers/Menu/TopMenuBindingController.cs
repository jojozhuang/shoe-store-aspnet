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
    public class TopMenuBindingController : BaseController
    {
        private IMenuRepository menuRepository;

        public TopMenuBindingController(IMenuRepository menuRepo)
        {
            menuRepository = menuRepo;
            base.SetPageHeader("Top Menu Binding");
        }

        //public ViewResult List()
        //{            
        //    ViewBag.TopMenus = menuRepository.TopMenus;
        //    var model = new TopMenuBindingViewModel
        //    {
        //        SelectedMenuCategoryIds = new int[] { },
        //        MenuCategories = menuRepository.MenuCategories,
        //        SelectedTopMenuId = 0
        //    };
        //    return View(model);
        //}

        public ViewResult List(int id, string controllername = "")
        {
            ViewBag.TopMenus = menuRepository.TopMenus;
            var topMenuBindings = menuRepository.TopMenuBindings.Where(x => x.TopMenuId == id);
            var model = new TopMenuViewModel(id, menuRepository.MenuCategories, topMenuBindings);
            return View(model);
        }

        public string GetMenuCategories(int id)
        {
            var categories = menuRepository.TopMenuBindings.Where(x => x.TopMenuId == id).Select(x => new 
                {  
                  category = x.MenuCategoryId
                });

            List<int> selectedCategories = new List<int>();
            foreach (var item in categories)
            {
                selectedCategories.Add(item.category);
            }

            var model = new TopMenuBindingViewModel
            {
                SelectedMenuCategoryIds = selectedCategories.ToArray(),
                MenuCategories = menuRepository.MenuCategories,
                SelectedTopMenuId = id
            };

            return new JavaScriptSerializer().Serialize(model);
        }
        
        [HttpPost]
        public ActionResult List(TopMenuBindingViewModel model)
        {
            ViewBag.TopMenus = menuRepository.TopMenus;
            model.MenuCategories = menuRepository.MenuCategories;
            if (model.SelectedTopMenuId == 0)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No Top Menu is selected!");
                return View(model);
            }
            else if (model.SelectedMenuCategoryIds == null || model.SelectedMenuCategoryIds.Count<int>() == 0)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "No Menu Categories are selected!");
                return View(model);
            }
            else
            {
                menuRepository.DeleteTopMenuBindings(menuRepository.TopMenuBindings.Where(x => x.TopMenuId == model.SelectedTopMenuId));
                menuRepository.SaveTopMenuBinding(model.SelectedTopMenuId, model.SelectedMenuCategoryIds);
                return View(model);
            }
        }

	}
}