using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Customers",
                "Customers",
                new { controller = "Customer", action = "Index" }
                );
            routes.MapRoute(
                "CustomersId",
                "Customers/Details/{id}",
                new { controller = "Customer", action = "Details" }
                );
            routes.MapRoute(
                "CustomerNew",
                "Customers/New",
                new { controller="Customer",action="New"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
