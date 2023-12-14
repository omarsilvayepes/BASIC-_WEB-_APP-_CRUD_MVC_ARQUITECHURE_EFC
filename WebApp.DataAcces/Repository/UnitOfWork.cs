using WebApp.DataAcces.Repository.IRepository;
using WebAppMVCArquitecture.Data;

namespace WebApp.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        public ICategoryRepository _categoryRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _categoryRepository=new CategoryRepository(dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
