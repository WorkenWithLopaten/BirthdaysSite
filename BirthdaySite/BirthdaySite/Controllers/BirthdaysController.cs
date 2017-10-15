using BirthdaySite.ViewModels.Friends;
using Bytes2you.Validation;
using MVCTemplate.Services.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;

namespace BirthdaySite.Controllers
{
    public class BirthdaysController : Controller
    {
        private IFriendListService friendList;
        private IPrincipal identity;

        public BirthdaysController(IFriendListService friendList, IPrincipal identity)
        {
            Guard.WhenArgument(friendList, "friendListService").IsNull().Throw();
            Guard.WhenArgument(identity, "principalService").IsNull().Throw();
                                                                        
            this.friendList = friendList;
            this.identity = identity;
        }

        [Authorize]
        public ActionResult Index()
        {
            var index = this.identity.Identity.Name.IndexOf("@");
            if (index < 0)
            {
                Guard.WhenArgument(index, "Name cannot be null").IsLessThan(0)
                    .Throw();
            }

            var friendListName = this.identity.Identity.Name.Substring(0, index);

            var friends = this.friendList.GetAllFriends(friendListName);

            var friendList = new FriendsViewModel();
            var friendsView = new List<FriendViewModel>();

            if (friends.Count != 0)
            {
                friendsView = friends.Select(x => new FriendViewModel()
                {
                    Name = x.Name,
                    Birthday = x.Birthday,
                    Gender = x.Gender
                })
                .ToList();
            }

            return View(friendsView);
        }
    }
}