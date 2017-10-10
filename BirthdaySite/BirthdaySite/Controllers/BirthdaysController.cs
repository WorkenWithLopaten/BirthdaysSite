using BirthdaySite.ViewModels.Friends;
using MVCTemplate.Services.Data;
using System.Linq;
using System.Web.Mvc;

namespace BirthdaySite.Controllers
{
    public class BirthdaysController : Controller
    {
        private IFriendListService friendList;

        public BirthdaysController(IFriendListService friendList)
        {
            this.friendList = friendList;
        }

        [Authorize]
        public ActionResult Index()
        {
            var index = this.User.Identity.Name.IndexOf("@");
            var friendListName = this.User.Identity.Name.Substring(0, index);

            var friends = this.friendList.GetAllFriends(friendListName);

            var friendList = new FriendsViewModel();

            var friendsView = friends.Select(x => new FriendViewModel()
            {
                Name = x.Name,
                Birthday = x.Birthday,
                Gender = x.Gender
            })
            .ToList();

            return View(friendsView);
        }
    }
}