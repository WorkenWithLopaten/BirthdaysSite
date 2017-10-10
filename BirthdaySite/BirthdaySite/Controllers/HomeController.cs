using System.Linq;
using System.Web.Mvc;
using BirthdaySite.ViewModels.Friends;
using MVCTemplate.Services.Data;

namespace BirthdaySite.Controllers
{
    public class HomeController : Controller
    {
        private IFriendListService friendList;

        public HomeController(IFriendListService friendList)
        {
            this.friendList = friendList;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}