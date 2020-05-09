using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            
            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{Name}-{cateId}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "Shop.Controllers" }

            );
            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{Code}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Shop.Controllers" }

            );
            
            routes.MapRoute(
                name: "trang-chu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces:   new[] { "Shop.Controllers" }

            );
        }
    }
}
