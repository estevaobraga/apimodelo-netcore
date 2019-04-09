using apimodelo.netcore.domain.domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apimodelo.netcore.infra.Data.MSSQL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> entity_;
        protected Context.Context context;

        public GenericRepository(Context.Context context)
        {
            this.context = context;
            entity_ = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await entity_.ToListAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            entity_.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            entity_.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            entity_.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
