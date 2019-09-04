using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DieteticSNS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DieteticSNS.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDieteticSNSDbContext _context;

        public Repository(IDieteticSNSDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void DetachAll()
        {
            _context.DetachAll();
        }   
    }
}
