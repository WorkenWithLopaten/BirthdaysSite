using BirthdaySite.Areas.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BirthdaySite.UnitTests.Common
{
    [TestClass]
    public class AdministrationArea
    {
        [TestMethod]
        public void GetAreaName_ShouldReturnAdministration()
        {
            var administration = new AdministrationAreaRegistration();

            Assert.AreEqual("Administration", administration.AreaName);
        }
    }
}
