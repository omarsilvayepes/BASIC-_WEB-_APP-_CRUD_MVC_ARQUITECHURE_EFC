using WebApp.DataAcces.Repository.IRepository;
using WebApp.Models.Models;
using WebAppMVCArquitecture.Data;

namespace WebApp.DataAcces.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Update(Product product)
        {
            _dbContext.Update(product);
            return Task.CompletedTask;
        }
    }
}
