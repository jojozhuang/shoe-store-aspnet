using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using Johnny.ShoeStore.Domain.Abstract;
using Johnny.ShoeStore.Domain.Concrete;
using Johnny.ShoeStore.Domain.Entities;
using System.Configuration;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure.Abstract;
using Johnny.ShoeStore.WebUI.Areas.Admin.Infrastructure.Concrete;

namespace Johnny.ShoeStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //    new Product { Name = "Football", Price = 25 },
            //    new Product { Name = "Surf board", Price = 179 },
            //    new Product { Name = "Running shoes", Price = 95 }
            //    });
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IShoeStoreRepository>().To<EFShoeStoreRepository>();
            kernel.Bind<IAccountRepository>().To<EFAccountRepository>();
            kernel.Bind<IMenuRepository>().To<EFMenuRepositoryRepository>();
            kernel.Bind<IWebsiteConfigRepository>().To<EFWebsiteConfigRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            .WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}