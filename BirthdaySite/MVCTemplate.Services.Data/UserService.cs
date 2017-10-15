using System.Linq;
using BirthdaySite.Data.Models;
using MVCTemplate.Data.Common.Repositories;

namespace MVCTemplate.Services.Data
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> users;

        public UserService(IUserRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }
    }
}
