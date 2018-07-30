using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Models;

namespace Johnny.ShoeStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IShoeStoreRepository repository;
        public int PageSize = 4;
        public ProductController(IShoeStoreRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int category = 0, int page = 1)
        {
            //return View(repository.Products
            //.OrderBy(p => p.ProductID)
            //.Skip((page - 1) * PageSize)
            //.Take(PageSize));
            ProductsListViewModel model = new ProductsListViewModel {
                Products = repository.Products
                .Where(p => ((category == 0) ? true : p.ProductCategoryId == category))
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == 0 ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.ProductCategoryId == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
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