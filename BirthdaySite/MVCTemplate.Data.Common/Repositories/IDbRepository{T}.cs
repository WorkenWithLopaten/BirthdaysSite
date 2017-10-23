using MVCTemplate.Data.Common.Models;
using System.Linq;

namespace MVCTemplate.Data.Common
{
    public interface IDbRepository<T>
        where T : class, IDeletableEntity 
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        void Add(T entity);

        void Update(T entity);
    }
}
