using BirthdaySite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.PresentsControllerTests
{
    [TestClass]
    public class PresentsControllerTests
    {
        [TestMethod]
        public void Index_ShouldRenderCorrectView()
        {
            var controller = new PresentsController();

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView();
        }
    }
}
