using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Johnny.ShoeStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                new Product {ProductId = 2, ProductName = "P2"},
                new Product {ProductId = 3, ProductName = "P3"},
            });
            // Arrange - create a controller
            ProductController target = new ProductController(mock.Object);
            // Action
            Product[] result = ((IEnumerable<Product>)target.ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("P1", result[0].ProductName);
            Assert.AreEqual("P2", result[1].ProductName);
            Assert.AreEqual("P3", result[2].ProductName);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                new Product {ProductId = 2, ProductName = "P2"},
                new Product {ProductId = 3, ProductName = "P3"},
            });
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Act
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;
            // Assert
            Assert.AreEqual(1, p1.ProductId);
            Assert.AreEqual(2, p2.ProductId);
            Assert.AreEqual(3, p3.ProductId);
        }
        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                new Product {ProductId = 2, ProductName = "P2"},
                new Product {ProductId = 3, ProductName = "P3"},
            });
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Act
            Product result = (Product)target.Edit(4).ViewData.Model;
            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {

            // Arrange - create mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Arrange - create a product
            Product product = new Product { ProductName = "Test" };

            // Act - try to save the product
            ActionResult result = target.Edit(product);

            // Assert - check that the repository was called
            mock.Verify(m => m.SaveProduct(product));
            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {

            // Arrange - create mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Arrange - create a product
            Product product = new Product { ProductName = "Test" };
            // Arrange - add an error to the model state
            target.ModelState.AddModelError("error", "error");

            // Act - try to save the product
            ActionResult result = target.Edit(product);

            // Assert - check that the repository was not called
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange - create a Product
            Product prod = new Product { ProductId = 2, ProductName = "Test" };
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"}, prod,
                new Product {ProductId = 3, ProductName = "P3"},
            });
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Act - delete the product
            target.Delete(prod.ProductId);
            // Assert - ensure that the repository delete method was
            // called with the correct Product
            mock.Verify(m => m.DeleteProduct(prod.ProductId));
        }
    }
}
