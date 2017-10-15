using BirthdaySite.Data.Models;
using System.Linq;

namespace MVCTemplate.Services.Data
{
    public interface IUserService
    {
        IQueryable<ApplicationUser> GetAll();
    }
}
