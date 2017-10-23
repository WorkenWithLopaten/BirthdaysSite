using System.Linq;
using System.Web.Mvc;
using BirthdaySite.ViewModels.Forum;
using MVCTemplate.Services.Data;
using Bytes2you.Validation;
using BirthdaySite.Common;

namespace BirthdaySite.Controllers
{
    public class ForumController : Controller
    {
        private IGroupService groups;

        public ForumController(IGroupService groups)
        {
            Guard.WhenArgument(groups, "groupsService").IsNull().Throw();

            this.groups = groups;
        }

        [Authorize]
        public ActionResult Index()
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
        [HttpGet]
        public ActionResult RenderMessages(string groupName)
        {
            var group = this.groups.GetAll()
                .Where(x => x.Name.ToLower() == groupName.ToLower())
                .Select(x => new GroupViewModel()
                {
                    Name = x.Name,
                    Messages = x.Messages.Select(y => new MessageViewModel()
                    {
                        Author = y.Author,
                        Content = y.Content
                    }).ToList()
                })
                .SingleOrDefault();

            return View("_MessagesPartial", group);
        }
     
        [Authorize]
        [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Message(string groupName)
        {
            var group = this.groups.GetAll()
                .Where(x => x.Name.ToLower() == groupName.ToLower())
                .Select(x => new GroupViewModel()
                {
                    Name = x.Name,
                    Messages = x.Messages.Select(y => new MessageViewModel()
                    {
                        Author = y.Author,
                        Content = y.Content
                    }).ToList()
                })
                .SingleOrDefault();


            return PartialView("Message", group);
        }
    }
}