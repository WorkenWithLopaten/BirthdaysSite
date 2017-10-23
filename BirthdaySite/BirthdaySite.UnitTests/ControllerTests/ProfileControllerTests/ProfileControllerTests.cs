using BirthdaySite.Controllers;
using BirthdaySite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Services.Data;
using System;
using System.Net;
using System.Security.Principal;
using System.Web;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.ProfileControllerTests
{
    [TestClass]
    public class ProfileControllerTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorretly()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new ProfileController(identityMocked.Object, usersMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenIdentity_IsNull()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            Assert.ThrowsException<ArgumentNullException>(() =>
            new ProfileController(null, usersMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenUsersRepo_IsNull()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            Assert.ThrowsException<ArgumentNullException>(() =>
            new ProfileController(identityMocked.Object,
            null));
        }

        [TestMethod]
        public void Index_ShouldRenderCorrectView()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new ProfileController(identityMocked.Object, usersMocked.Object);

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            controller
                .WithCallTo(m => m.Index())
                .ShouldRenderDefaultView()
                .WithModel<ExternalLoginConfirmationViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Email, "test");
                });
        }

        [TestMethod]
        public void ChangeProfile_ShouldCallUpdateMethod_Once()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new ProfileController(identityMocked.Object, usersMocked.Object);

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var model = new ExternalLoginConfirmationViewModel()
            {
                Email = "test"
            };

            controller.ChangeProfile(model);            

            usersMocked.Verify(m => m.Update("test"), Times.Once);
        }


        [TestMethod]
        public void ChangeProfile_ShouldRedirect()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new ProfileController(identityMocked.Object, usersMocked.Object);

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var model = new ExternalLoginConfirmationViewModel()
            {
                Email = "test"
            };

            controller
                .WithCallTo(m => m.ChangeProfile(model))
                .ShouldRedirectToRoute("");
        }

        [TestMethod]
        public void ChangeProfile_ShouldReturnHttpNotFoundIfModelIsInvalid()
        {
            var usersMocked = new Mock<IUserService>();
            var identityMocked = new Mock<IPrincipal>();
            var controller = new ProfileController(identityMocked.Object, usersMocked.Object);

            identityMocked.Setup(m => m.Identity.Name).Returns("test");

            var invalidModel = new ExternalLoginConfirmationViewModel()
            {
                Email = "testasggasssdhshsdhsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss"
            };

            Assert.ThrowsException<HttpException>(()
                => controller.ChangeProfile(invalidModel));
        }
    }
}
