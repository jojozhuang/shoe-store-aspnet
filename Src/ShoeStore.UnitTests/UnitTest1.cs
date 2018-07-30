using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Controllers;
using Johnny.ShoeStore.WebUI.Models;
using Johnny.ShoeStore.WebUI.HtmlHelpers;

namespace Johnny.ShoeStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate() {
            // Arrange
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                new Product {ProductId = 2, ProductName = "P2"},
                new Product {ProductId = 3, ProductName = "P3"},
                new Product {ProductId = 4, ProductName = "P4"},
                new Product {ProductId = 5, ProductName = "P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            //IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
            ProductsListViewModel result = (ProductsListViewModel)controller.List(0, 2).Model;
            // Assert
            //Product[] prodArray = result.ToArray();
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].ProductName, "P4");
            Assert.AreEqual(prodArray[1].ProductName, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links() {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
            result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model() {
            // Arrange
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
            new Product {ProductId = 1, ProductName = "P1"},
            new Product {ProductId = 2, ProductName = "P2"},
            new Product {ProductId = 3, ProductName = "P3"},
            new Product {ProductId = 4, ProductName = "P4"},
            new Product {ProductId = 5, ProductName = "P5"}
            });
            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(0, 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Products() {
            // Arrange
            // - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1", ProductCategoryId = 1},
                new Product {ProductId = 2, ProductName = "P2", ProductCategoryId = 2},
                new Product {ProductId = 3, ProductName = "P3", ProductCategoryId = 1},
                new Product {ProductId = 4, ProductName = "P4", ProductCategoryId = 2},
                new Product {ProductId = 5, ProductName = "P5", ProductCategoryId = 3}
            });
                // Arrange - create a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Action
            Product[] result = ((ProductsListViewModel)controller.List(2, 1).Model)
            .Products.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].ProductName == "P2" && result[0].ProductCategoryId == 2);
            Assert.IsTrue(result[1].ProductName == "P4" && result[1].ProductCategoryId == 2);
        }        

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            // - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1", ProductCategoryId = 1},
                new Product {ProductId = 4, ProductName = "P2", ProductCategoryId = 2},
            });
            // Arrange - create the controller
            NavController target = new NavController(mock.Object);
            // Arrange - define the category to selected
            int categoryToSelect = 1;
            // Action
            int result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;
            // Assert
            Assert.AreEqual(categoryToSelect, result);
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count() {
            // Arrange
            // - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1", ProductCategoryId = 1},
                new Product {ProductId = 2, ProductName = "P2", ProductCategoryId = 2},
                new Product {ProductId = 3, ProductName = "P3", ProductCategoryId = 1},
                new Product {ProductId = 4, ProductName = "P4", ProductCategoryId = 2},
                new Product {ProductId = 5, ProductName = "P5", ProductCategoryId = 3}
            });
            // Arrange - create a controller and make the page size 3 items
            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;
            // Action - test the product counts for different categories
            int res1 = ((ProductsListViewModel)target.List(1).Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)target.List(2).Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)target.List(3).Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)target.List(0).Model).PagingInfo.TotalItems;
            // Assert
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
