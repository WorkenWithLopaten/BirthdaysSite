using System;
using System.Data.Entity;
using BirthdaySite.Models;
using MVCTemplate.Data.Migrations;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BirthdaySite
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            if (Context.IsCustomErrorEnabled)
            {
                ShowCustomErrorPage(Server.GetLastError());
            }
        }

        private void ShowCustomErrorPage(Exception exception)
        {
            var httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);

            Response.Clear();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("fromAppErrorEvent", true);

            switch (httpException.GetHttpCode())
            {
                case 404:
                    routeData.Values.Add("action", "NotFound");
                    break;
                case 500:                
                    routeData.Values.Add("action", "Index");
                    break;
            }

            Server.ClearError();

            IController controller = ControllerBuilder.Current.GetControllerFactory().CreateController(new RequestContext() { RouteData = routeData }, "Error");
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}
