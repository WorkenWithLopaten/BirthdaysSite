using System.Linq;

namespace MVCTemplate.Data.Common.Repositories
{
    public interface IUserRepository<T>
           where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void HardDelete(T entity);

        void Dispose();
    }
}
