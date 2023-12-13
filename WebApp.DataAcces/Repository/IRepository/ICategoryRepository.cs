using WebAppMVCArquitecture.Models;

namespace WebApp.DataAcces.Repository.IRepository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task Update(Category category); 
        void Save();
    }
}
