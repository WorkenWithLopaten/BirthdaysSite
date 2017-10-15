using BirthdaySite.Models;
using BirthdaySite.ViewModels.AdminViewModel;
using BirthdaySite.ViewModels.Forum;
using BirthdaySite.ViewModels.Friends;
using Bytes2you.Validation;
using MVCTemplate.Services.Data;
using System.Linq;
using System.Web.Mvc;

namespace BirthdaySite.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        private IGroupService groups;
        private IFriendListService friendLists;
        private IUserService users;

        public AdministrationController(IGroupService groups, IFriendListService friendLists,
            IUserService users)
        {
            Guard.WhenArgument(groups, "Group service cannot be null!").IsNull().Throw();
            Guard.WhenArgument(friendLists, "FriendsLists service cannot be null!").IsNull().Throw();
            Guard.WhenArgument(users, "Users service cannot be null!").IsNull().Throw();

            this.groups = groups;
            this.friendLists = friendLists;
            this.users = users;
        }

        [Authorize]
        public ActionResult Index()
        {
            var groups = this.groups.GetAll().ToList();
            var groupsCount = groups.Count;
            var usersCount = this.users.GetAll().Count();
            var friendLists = this.friendLists.GetAll();
            var friendListsCount = friendLists.Count;
            var friendsCount = 0;
            var messagesCount = 0;

            foreach (var friendList in friendLists)
            {
                friendsCount += friendList.Friends.Count;
            }

            foreach (var group in groups)
            {
                messagesCount += group.Messages.Count;
            }

            var adminViewModel = new AdminDataInitalViewModel();

            adminViewModel.FriendListsCount = friendListsCount;
            adminViewModel.GroupsCount = groupsCount;
            adminViewModel.MessagesCount = messagesCount;
            adminViewModel.UsersCount = usersCount;
            adminViewModel.FriendsCount = friendsCount;

            return View(adminViewModel);
        }

        [Authorize]
        public ActionResult GetAllGroupsAndMessages()
        {
            var groups = this.groups.GetAll()
               .Select(x => new GroupViewModel()
               {
                   Name = x.Name,
                   Messages = x.Messages.Select(y => new MessageViewModel()
                   {
                       Author = y.Author,
                       Content = y.Content
                   }).ToList()

               })
                .ToList();

            return View(groups);
        }

        [Authorize]
        public ActionResult GetAllFriendListsAndFriends()
        {
            var friendLists = this.friendLists.GetAll()
                .Select(x => new FriendsViewModel()
                {
                    Name = x.Name,
                    Friends = x.Friends.Select(y => new FriendViewModel()
                    {
                        Name = y.Name,
                        Birthday = y.Birthday,
                        Gender = y.Gender
                    }).ToList()

                })
                .ToList();

            return View(friendLists);
        }

        [Authorize]
        public ActionResult GetAllUsers()
        {
            var users = this.users.GetAll()
                .Select(u => new LoginViewModel()
                {
                    Email = u.Email,
                    Password = u.PasswordHash
                }).ToList();

            return View(users);
        }
    }
}