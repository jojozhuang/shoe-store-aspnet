using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Johnny.ShoeStore.Domain.Entities;
using Johnny.ShoeStore.WebUI.Infrastructure.Binders;
using System.Data.Entity;
using Johnny.ShoeStore.Domain.Concrete;

namespace Johnny.ShoeStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            Database.SetInitializer<EFDbContext>(null);
        }
    }
}
