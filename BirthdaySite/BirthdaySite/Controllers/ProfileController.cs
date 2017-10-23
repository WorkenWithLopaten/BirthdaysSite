using BirthdaySite.Models;
using Bytes2you.Validation;
using MVCTemplate.Services.Data;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace BirthdaySite.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IPrincipal identity;
        private IUserService users;

        public ProfileController(IPrincipal identity, IUserService users)
        {
            Guard.WhenArgument(identity, "identity").IsNull().Throw();
            Guard.WhenArgument(users, "users").IsNull().Throw();

            this.identity = identity;
            this.users = users;
        }

        public ActionResult Index()
        {
            var model = new ExternalLoginConfirmationViewModel()
            {
                Email = this.identity.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeProfile(ExternalLoginConfirmationViewModel model)
        {
            if (model.Email.Length <= 20)
            {
                this.users.Update(model.Email);
                return RedirectToAction("Index");
            }
            else
            {
                throw new HttpException(404, "Please try again with other Email!");
            }
        }
    }
}