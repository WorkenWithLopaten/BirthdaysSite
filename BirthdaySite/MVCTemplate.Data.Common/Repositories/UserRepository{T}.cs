using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCTemplate.Data.Common.Repositories;

namespace MVCTemplate.Data.Common
{
    public class UserRepository<T> : IUserRepository<T>
       where T : IdentityUser
    {
        public UserRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(object id)
        {
            var item = this.DbSet.Find(id);        

            return item;
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
