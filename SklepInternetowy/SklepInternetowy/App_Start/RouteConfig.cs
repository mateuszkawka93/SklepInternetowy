﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SklepInternetowy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "ProductsList",
                url: "category/{categoryname}",
                defaults: new {controller = "Supplement", action = "List"}

            );

            routes.MapRoute(
                name: "StaticPages",
                url: "page/{name}.html",
                defaults: new {controller = "Home", action = "StaticPages"}

            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
