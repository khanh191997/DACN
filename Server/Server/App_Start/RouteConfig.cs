using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("{*botdetect}",
            //new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            //routes.MapRoute(
            //    name: "Login",
            //    url: "dang-nhap",
            //    defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
            //    namespaces: new[] { "Server.Controllers" }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"Server.Controllers"}
            );
        }
    }
}
