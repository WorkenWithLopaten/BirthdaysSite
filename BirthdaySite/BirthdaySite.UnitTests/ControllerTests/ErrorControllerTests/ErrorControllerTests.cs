using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.ErrorControllerTests
{
    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void Index_ShouldRender_CorrectView()
        {
            var controller = new ErrorController();

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView();               
        }

        [TestMethod]
        public void NotFound_ShouldRender_CorrectView()
        {
            var controller = new ErrorController();

            controller
                .WithCallTo(m => m.NotFound())
                .ShouldRenderDefaultView();
        }
    }
}
