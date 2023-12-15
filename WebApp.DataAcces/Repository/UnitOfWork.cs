using WebApp.DataAcces.Repository.IRepository;
using WebAppMVCArquitecture.Data;

namespace WebApp.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        public ICategoryRepository _categoryRepository { get; private set; }

        public IProductRepository _productRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
