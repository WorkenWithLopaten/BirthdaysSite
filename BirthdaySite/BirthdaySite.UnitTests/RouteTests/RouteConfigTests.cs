using BirthdaySite.Areas.Administration.Controllers;
using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using System;
using System.Web.Routing;

namespace BirthdaySite.UnitTests.RouteTests
{

    public class RoutingBaseFact : IDisposable
    {
        protected static readonly Guid TestGuid = Guid.NewGuid();
        //protected HttpConfiguration config;
        protected RouteCollection testRoutes;
        public RoutingBaseFact()
        {
            //config = GlobalConfiguration.Configuration;
            testRoutes = RouteTable.Routes;
            //WebApiConfig.Register(config);
            RouteConfig.RegisterRoutes(testRoutes);
        }
        public void Dispose()
        {
            RouteTable.Routes.Clear();
        }
    }

    [TestClass]
    public class RouteFacts : RoutingBaseFact
    {
        [TestMethod]
        public void DefaultRoute_RootWithNoControllerNoActionNoId_ShouldMapToIndex()
        {
            testRoutes.ShouldMap("/").To<HomeController>(c => c.Index());
        }

        [TestMethod]
        public void Birthdays_ShouldRenderIndexView()
        {
            testRoutes.ShouldMap("/birthdays/").To<BirthdaysController>(c => c.Index());
        }
        [TestMethod]
        public void Error_ShouldRenderDefaulIndex()
        {
            testRoutes.ShouldMap("/error/").To<ErrorController>(c => c.Index());
        }
        [TestMethod]
        public void Error_NotFound_ShouldRenderNotFound()
        {
            testRoutes.ShouldMap("/error/notfound").To<ErrorController>(c => c.NotFound());
        }
        [TestMethod]
        public void Forum_Default_ShouldRender_Index()
        {
            testRoutes.ShouldMap("/forum/").To<ForumController>(c => c.Index());
        }
        [TestMethod]
        public void Presents_Default_ShouldRenderIndex()
        {
            testRoutes.ShouldMap("/presents/").To<PresentsController>(c => c.Index());
        }
        [TestMethod]
        public void Profile_Default_ShouldRenderIndex()
        {
            testRoutes.ShouldMap("/profile/").To<ProfileController>(c => c.Index());
        }
        [TestMethod]
        public void Administration_Default_ShouldRenderIndex()
        {
            //testRoutes.ShouldMap("/administration/administration/index").To<AdministrationController>(c => c.Index());
        }
    }
}
