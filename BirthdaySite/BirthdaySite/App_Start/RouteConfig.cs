using System.Web.Mvc;
using System.Web.Routing;

namespace BirthdaySite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            //routes.MapRoute(
            //    name: "BirthdaysRoute",
            //    url: "birthdays",
            //    defaults: new {
            //        controller = "Birthdays",
            //        action = "Index"             
            //    }
            //);

            //routes.MapRoute(
            //    name: "ForumRoute",
            //    url: "forum",
            //    defaults: new
            //    {
            //        controller = "Forum",
            //        action = "Index"
            //    }
            //);

            //routes.MapRoute(
            //    name: "PresentsRoute",
            //    url: "presents",
            //    defaults: new
            //    {
            //        controller = "Presents",
            //        action = "Index"
            //    }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
