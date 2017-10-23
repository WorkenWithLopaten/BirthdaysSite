using System.Linq;
using System.Collections.Generic;
using Bytes2you.Validation;
using MVCTemplate.Data.Common;
using MVCTemplate.Data.Models;
using MVCTemplate.Data.Common.SaveContext;
using System.Security.Principal;

namespace MVCTemplate.Services.Data
{
    public class UserService : IUserService
    {
        private IDbRepository<User> users;
        private ISaveContext saveContext;
        private IPrincipal identity;

        public UserService(IDbRepository<User> users, ISaveContext saveContext, IPrincipal identity)
        {
            Guard.WhenArgument(users, "userService").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();
            Guard.WhenArgument(identity, "identity").IsNull().Throw();

            this.users = users;
            this.saveContext = saveContext;
            this.identity = identity;
        }

        public ICollection<User> GetAll()
        {
            return this.users.All().Where(u => !u.IsDeleted).ToList();
        }

        public void Update(string userEmail)
        {
            var user = this.users.All()
                .SingleOrDefault(
                u => u.Email == this.identity.Identity.Name);

            Guard.WhenArgument(user, "user").IsNull().Throw();

            user.Email = userEmail;
            user.UserName = userEmail;

            this.users.Update(user);

            this.saveContext.Commit();
        }
    }
}
