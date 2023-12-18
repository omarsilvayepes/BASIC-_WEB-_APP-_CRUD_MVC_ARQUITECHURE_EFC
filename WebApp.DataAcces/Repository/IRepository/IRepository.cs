using System.Linq.Expressions;

namespace WebApp.DataAcces.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T-> category
        Task <IEnumerable<T>> GetAll(string? includeProperties = null);
        Task<T> Get(Expression<Func<T,bool>> filter, string? includeProperties = null);
        Task Add(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T>entity);
    }
}
