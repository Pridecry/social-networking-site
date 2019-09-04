using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DieteticSNS.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
        void DetachAll();
    }
}
