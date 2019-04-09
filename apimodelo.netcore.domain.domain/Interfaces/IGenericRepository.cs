using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apimodelo.netcore.domain.domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Async Methods
        Task<IEnumerable<T>> AllAsync();
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
