using BirthdaySite.App_Start;
using BirthdaySite.Controllers;
using BirthdaySite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace BirthdaySite.UnitTests.ControllerTests.AccountControllerTests
{
    [TestClass]
    public class AccontControllerTests
    {
        [TestMethod]
        public void Constructor_Should_BeThere()
        {
            var accountController = new AccountController();
        }

        [TestMethod]
        public void Constructor_ShoulInitialize_Correctly()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var accountController = new AccountController(userManagerServiceMocked.Object,
                signInManagerServiceMocked.Object);

            Assert.IsNotNull(accountController);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenUserManagerIsNull()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new AccountController(null, signInManagerServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenSignInManagerIsNull()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
            new AccountController(userManagerServiceMocked.Object, null));
        }

        [TestMethod]
        public void LoginShould_RenderCorrectView()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            accountController
                .WithCallTo(m => m.Login("test"))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Register_RenderCorrectView()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            accountController
                .WithCallTo(m => m.Register())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Register_ShouldRedirectToCorrectView()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var result = Task.Run(() => IdentityResultTest());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            userManagerServiceMocked.Setup(m => m.CreateAsync(
                It.IsAny<User>(), It.IsAny<string>()))
                .Returns(result);

            var model = new RegisterViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Register(model))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Login_ShouldRedirectToCorrectView_WhenFailiure()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var result = Task.Run(() => IdentityResultTest());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            signInManagerServiceMocked.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInStatus.Failure); ;

            var model = new LoginViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Login(model, "test"))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Login_ShouldRedirectToCorrectView_WhenSucces()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var result = Task.Run(() => IdentityResultTest());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            signInManagerServiceMocked.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInStatus.Success);

            var urlHelper = new Mock<UrlHelper>();

            urlHelper.Setup(m => m.IsLocalUrl(It.IsAny<string>()))
                .Returns(false);

            accountController.Url = urlHelper.Object;
            

            var model = new LoginViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Login(model, "/home/index"))
                .ShouldRedirectToRoute("");
        }

        [TestMethod]
        public void Login_ShouldRedirectToCorrectView_WhenLockedOut()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var result = Task.Run(() => IdentityResultTest());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            signInManagerServiceMocked.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInStatus.LockedOut); ;

            var model = new LoginViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Login(model, "test"))
                .ShouldRenderView("Lockout");
        }

        [TestMethod]
        public void Login_ShouldRedirectToCorrectView_WhenRequiresVerification()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var result = Task.Run(() => IdentityResultTest());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            signInManagerServiceMocked.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInStatus.RequiresVerification); ;

            var model = new LoginViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Login(model, "test"))
                .ShouldRedirectToRoute("");
        }

        [TestMethod]
        public void Login_ReturnCorrectView_WhenModelIsInvalid()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            accountController.ModelState.AddModelError("error", new InvalidRouteValueException("invalid"));

            var model = new LoginViewModel()
            {
                Email = "invalid",
                Password = "invalidP"
            };

            accountController
                .WithCallTo(m => m.Login(model, "test"))
                .ShouldRenderDefaultView()
                .WithModel<LoginViewModel>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Email, "invalid");
                    Assert.AreEqual(viewModel.Password, "invalidP");
                });
        }

        [TestMethod]
        public void Register_ShouldRedirectToActionWhenSucces()
        {
            var userManagerServiceMocked = new Mock<IUserManagerService>();
            var signInManagerServiceMocked = new Mock<ISignInManagerService>();            

            var result = Task.Run(() => IdentityResultTestSucces());

            var accountController = new AccountController(userManagerServiceMocked.Object,
               signInManagerServiceMocked.Object);

            userManagerServiceMocked.Setup(m => m.CreateAsync(
                It.IsAny<User>(), It.IsAny<string>()))
                .Returns(result);

            var model = new RegisterViewModel()
            {
                Email = "test",
                Password = "1234"
            };

            accountController
                .WithCallTo(m => m.Register(model))
                .ShouldRedirectToRoute("");
        }

        private IdentityResult IdentityResultTest()
        {
            var result = new IdentityResult(new List<string>() { "error" });
           
            return result;
        }

        private IdentityResult IdentityResultTestSucces()
        {
            return IdentityResult.Success;
        }
    }
}
