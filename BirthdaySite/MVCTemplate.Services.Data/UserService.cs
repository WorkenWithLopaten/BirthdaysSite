using System.Linq;
using BirthdaySite.Data.Models;
using MVCTemplate.Data.Common.Repositories;
using System.Collections.Generic;
using Bytes2you.Validation;

namespace MVCTemplate.Services.Data
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> users;

        public UserService(IUserRepository<ApplicationUser> users)
        {
            Guard.WhenArgument(users, "userService").IsNull().Throw();

            this.users = users;
        }

        public ICollection<ApplicationUser> GetAll()
        {
            return this.users.All().ToList();
        }
    }
}
