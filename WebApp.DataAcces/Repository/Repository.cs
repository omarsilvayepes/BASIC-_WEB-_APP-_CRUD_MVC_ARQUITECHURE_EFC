using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApp.DataAcces.Repository.IRepository;
using WebAppMVCArquitecture.Data;

namespace WebApp.DataAcces.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        async Task IRepository<T>.Add(T entity)
        {
            await _dbSet.AddAsync(entity);

        }


        async Task<T> IRepository<T>.Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        async Task<IEnumerable<T>> IRepository<T>.GetAll()
        {
            IQueryable<T> query = _dbSet;
            return await query.ToListAsync();
        }

        Task IRepository<T>.Remove(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        Task IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            return Task.CompletedTask;
        }
    }
}
