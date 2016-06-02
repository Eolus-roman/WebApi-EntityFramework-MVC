﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EntityFramework_And_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{button}/{id}",
                defaults: new { button= RouteParameter.Optional, id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
