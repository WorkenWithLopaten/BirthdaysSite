using System;
using BirthdaySite.Models;

namespace MVCTemplate.Data.Common.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly IApplicationDbContext context;

        public SaveContext(IApplicationDbContext context)
        {
            if(context == null)

            {
                throw new ArgumentNullException("Context cannot be null!");
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
