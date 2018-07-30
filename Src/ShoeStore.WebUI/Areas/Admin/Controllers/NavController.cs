using Johnny.ShoeStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class NavController : Controller
    {
        private IMenuRepository menuRepository;
        public NavController(IMenuRepository menuRepo)
        {
            menuRepository = menuRepo;
        }
        public PartialViewResult NavigatonBar()
        {
            ViewBag.SelectedMenuId = 1;
            return PartialView("NavigatonBar", menuRepository.TopMenus);
        }
	}
}