using System.Collections.Generic;
using System.Web.Mvc;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System.Linq;

namespace Johnny.ShoeStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IShoeStoreRepository repository;
        public NavController(IShoeStoreRepository repo) {
            repository = repo;
        }
        //public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        //{
        //    ViewBag.SelectedCategory = category;
        //    IEnumerable<string> categories = repository.Products
        //    .Select(x => x.Category)
        //    .Distinct()
        //    .OrderBy(x => x);

        //    string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
        //    return PartialView(viewName, categories);
        //}
        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<ProductCategory> categories = repository.ProductCategories;              
            return PartialView("FlexMenu", categories);
        }
	}
}