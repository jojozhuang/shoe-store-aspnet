using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Johnny.Library.Helper;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure;
using Johnny.ShoeStore.WebUI.Areas.Admin.Models;

namespace Johnny.ShoeStore.WebUI.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private IShoeStoreRepository shoeStoreRepository;

        public ProductCategoryController(IShoeStoreRepository shoeStoreRepo)
        {
            shoeStoreRepository = shoeStoreRepo;
            base.SetPageHeader("Product Category");
        }

        public ViewResult List()
        {
            return View(shoeStoreRepository.ProductCategories);
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductCategory());
        }

        public ViewResult Edit(int productCategoryId)
        {
            ProductCategory productCategory = shoeStoreRepository.ProductCategories.FirstOrDefault(p => p.ProductCategoryId == productCategoryId);
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                shoeStoreRepository.SaveProductCategory(productCategory);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", productCategory.ProductCategoryName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                return View(productCategory);
            }
        }

        [HttpGet]
        public ActionResult Delete(int productCategoryId)
        {
            ProductCategory deletedProductCategory = shoeStoreRepository.DeleteProductCategory(productCategoryId);
            if (deletedProductCategory != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedProductCategory.ProductCategoryName));
            }
            return RedirectToAction("List");
        }
        
	}
}