using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CVGenerator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "UserResume",
               url: "MyCv/{idTemplate}/{idProfile}",
               defaults: new
               {
                   controller = "Resume",
                   action = "ViewUserProfile",
                   idTemplate = "",
                   idProfile = ""
               }
           );

            routes.MapRoute(
               name: "ViewUserResumes",
               url: "MyCvs",
               defaults: new
               {
                   controller = "Resume",
                   action = "ViewMyCvs",
               }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
