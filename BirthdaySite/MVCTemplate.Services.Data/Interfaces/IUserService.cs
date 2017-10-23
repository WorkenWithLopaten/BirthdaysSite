using MVCTemplate.Data.Models;
using System.Collections.Generic;

namespace MVCTemplate.Services.Data
{
    public interface IUserService
    {
        ICollection<User> GetAll();

        void Update(string userEmail);
    }
}
