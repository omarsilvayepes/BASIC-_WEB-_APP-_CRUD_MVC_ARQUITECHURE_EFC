using WebApp.DataAcces.Repository.IRepository;
using WebAppMVCArquitecture.Data;
using WebAppMVCArquitecture.Models;

namespace WebApp.DataAcces.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public   void Save()
        {
            _dbContext.SaveChanges();
        }

        public Task Update(Category category)
        {
            _dbContext.Update(category);
            return Task.CompletedTask;
        }
    }
}
