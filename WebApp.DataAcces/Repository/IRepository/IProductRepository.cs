using WebApp.Models.Models;

namespace WebApp.DataAcces.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        Task Update(Product product);
    }
}

