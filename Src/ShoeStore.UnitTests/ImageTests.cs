using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Johnny.ShoeStore.UnitTests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Arrange - create a Product with image data
            Product prod = new Product
            {
                ProductId = 2,
                ProductName = "Test",
                ImageData = new byte[] { },
                ImageMimeType = "image/png"
            };
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                prod,
                new Product {ProductId = 3, ProductName = "P3"}
            }.AsQueryable());
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Act - call the GetImage action method
            ActionResult result = target.GetImage(2);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(prod.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            // Arrange - create the mock repository
            Mock<IShoeStoreRepository> mock = new Mock<IShoeStoreRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, ProductName = "P1"},
                new Product {ProductId = 2, ProductName = "P2"}
            }.AsQueryable());
            // Arrange - create the controller
            ProductController target = new ProductController(mock.Object);
            // Act - call the GetImage action method
            ActionResult result = target.GetImage(100);
            // Assert
            Assert.IsNull(result);
        }
    }
}
