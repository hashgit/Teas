using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace TeaStall.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "TeaBase",
                routeTemplate: "api/TeaContents/Base/{teaBase}",
                defaults: new { controller = "TeaContents", action = "TeaBase", teaBase = UrlParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TeaBasePrice",
                routeTemplate: "api/TeaContents/Base/{baseId}/price/{price}",
                defaults: new { controller = "TeaContents", action = "TeaBasePrice" }
            );

            config.Routes.MapHttpRoute(
                name: "TeaFlavor",
                routeTemplate: "api/TeaContents/Flavor/{flavor}",
                defaults: new { controller = "TeaContents", action = "Flavor", flavor = UrlParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "FlavorPrice",
                routeTemplate: "api/TeaContents/Flavor/{flavorId}/price/{price}",
                defaults: new { controller = "TeaContents", action = "FlavorPrice" }
            );

            config.Routes.MapHttpRoute(
                name: "TeaTopping",
                routeTemplate: "api/TeaContents/Topping/{topping}",
                defaults: new { controller = "TeaContents", action = "Topping", topping = UrlParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ToppingPrice",
                routeTemplate: "api/TeaContents/Topping/{toppingId}/price/{price}",
                defaults: new { controller = "TeaContents", action = "ToppingPrice" }
            );

            config.Routes.MapHttpRoute(
                name: "Customer",
                routeTemplate: "api/Customers/",
                defaults: new { controller = "Customer", action = "Customer" }
            );
        }
    }
}
