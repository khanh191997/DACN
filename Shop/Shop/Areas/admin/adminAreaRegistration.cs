﻿using System.Web.Mvc;

namespace Shop.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller="Login", action = "Index", id = UrlParameter.Optional },
                new[] { "Shop.Areas.Admin.Controllers" }
            );
        }
    }
}