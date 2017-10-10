using System.Linq;

namespace MVCTemplate.Data.Common
{
    public interface IDbRepository<T>
        where T : class 
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Dispose();
    }
}
