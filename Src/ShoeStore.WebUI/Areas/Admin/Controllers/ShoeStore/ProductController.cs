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
    public class ProductController : BaseController
    {
        private IShoeStoreRepository shoeStoreRepository;

        public ProductController(IShoeStoreRepository shoeStoreRepo)
        {
            shoeStoreRepository = shoeStoreRepo;
            base.SetPageHeader("Product");
        }

        public ViewResult List()
        {
            return View(shoeStoreRepository.View_Products);
        }

        public ViewResult Create()
        {
            ViewBag.ProductCategories = shoeStoreRepository.ProductCategories;
            return View("Edit", new Product());
        }

        public ViewResult Edit(int productId)
        {
            ViewBag.ProductCategories = shoeStoreRepository.ProductCategories;
            Product product = shoeStoreRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                shoeStoreRepository.SaveProduct(product);
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} has been created!", product.ProductName));
                return RedirectToAction("List");
            }
            else
            {
                //There is something wrong with the data values
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Error, "There is something wrong with the data values, please check!");
                ViewBag.ProductCategories = shoeStoreRepository.ProductCategories;
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = shoeStoreRepository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = MessageHelper.BuildMessage(EnumSevereLevel.Success, string.Format("{0} was deleted!", deletedProduct.ProductName));
            }
            return RedirectToAction("List");
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = shoeStoreRepository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        
	}
}