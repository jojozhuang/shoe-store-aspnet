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
    public class AdminNavController : Controller
    {
        private IMenuRepository menuRepository;
        private IAccountRepository accountRepository;

        public AdminNavController(IMenuRepository menuRepo, IAccountRepository accountRepo)
        {
            menuRepository = menuRepo;
            accountRepository = accountRepo;
        }
       
        public PartialViewResult NavigationBar()
        {
            string actionName = this.ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();            
            //if (actionName.StartsWith("Create") || actionName.StartsWith("Edit") || actionName.StartsWith("Binding") || actionName.StartsWith("Roles"))
            if (AdminConstants.ActionNames.Contains(actionName))
                actionName = "List"; //"Add page" should be treated as same with "list page"
            //if (actionName.StartsWith("Edit"))
            //    actionName = actionName.Substring(4); //"Add page" should be treated as same with "list page"
            string controllerName = this.ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            var topMenus = menuRepository.TopMenus.ToList();
            var topMenuBindings = menuRepository.TopMenuBindings.ToList();
            var menuCategories = menuRepository.MenuCategories.ToList();
            var menus = menuRepository.Menus.ToList();

            var topNodes = topMenus.Select(x => new NavigationNode { Id = x.TopMenuId, NodeText = x.TopMenuName, Image = x.Image }).ToList();
            foreach (var topNode in topNodes)
            {
                //menu category
                var categories = menuCategories.Join(topMenuBindings.Where(x => x.TopMenuId == topNode.Id), x => new { x.MenuCategoryId },
                                                                                                            y => new { y.MenuCategoryId }, (x, y) => x);
                //build category nodes
                topNode.Children = categories.Select(x => new NavigationNode { Id = x.MenuCategoryId, NodeText = x.MenuCategoryName }).ToList();

                foreach (var categoryNode in topNode.Children)
                {
                    //menu
                    var menus2 = menus.Where(x => x.IsDisplay == true)
                        .Join(categories.Where(x => x.MenuCategoryId == categoryNode.Id), x => new { x.MenuCategoryId },
                                                                                          y => new { y.MenuCategoryId }, (x, y) => x);
                    List<NavigationNode> menuNodes = new List<NavigationNode>();
                    //build menu nodes
                    foreach (var item in menus2)
                    {
                        NavigationNode menuNode = new NavigationNode();
                        menuNode.Id = item.MenuId;
                        menuNode.NodeText = item.MenuName;
                        menuNode.NodeLink = String.Concat(item.Controller, "/", item.Action);
                        if (item.Controller == controllerName && item.Action == actionName)
                        {
                            menuNode.Active = true;
                            categoryNode.Active = true;
                            topNode.Active = true;
                        }
                        menuNodes.Add(menuNode);                       
                    }
                    categoryNode.Children = menuNodes;
                }                               
            }

            return PartialView("NavigatonBar", topNodes);
        }
	}
}