using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.HomeControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_ShouldRenderCorrectView()
        {         
            var controller = new HomeController();

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView();
        }
    }
}
