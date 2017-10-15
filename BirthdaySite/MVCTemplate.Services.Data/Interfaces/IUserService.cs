using BirthdaySite.Data.Models;
using System.Collections.Generic;

namespace MVCTemplate.Services.Data
{
    public interface IUserService
    {
        ICollection<ApplicationUser> GetAll();
    }
}
