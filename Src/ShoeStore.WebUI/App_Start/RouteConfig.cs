using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Johnny.ShoeStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Lists the first page of products from all categories(eg: /)
            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { Controller = "Product", action = "List", category = 0, page = 1 },
                namespaces: new[] { "Johnny.ShoeStore.WebUI.Controllers" }
            );

            //Lists the specified page (in this case, page 2), showing items from all categories(eg: /Page2)
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { Controller = "Product", action = "List", category = 0 },
                constraints: new { page = @"\d+" },
                namespaces: new[] { "Johnny.ShoeStore.WebUI.Controllers" }
            );

            //Shows the first page of items from a specific category (eg: /Soccer)
            routes.MapRoute(
               name: null,
               url: "{category}",
               defaults: new { Controller = "Product", action = "List", page = 1 },
               constraints: new { category = @"\d+" },
               namespaces: new[] { "Johnny.ShoeStore.WebUI.Controllers" }
            );

            //Shows the specified page (in this case, page 2) of items from the specified category (eg: /Soccer/Page2)
            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new { controller = "Product", action = "List" },                
                constraints: new { category = @"\d+", page = @"\d+" },
                namespaces: new[] { "Johnny.ShoeStore.WebUI.Controllers" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
