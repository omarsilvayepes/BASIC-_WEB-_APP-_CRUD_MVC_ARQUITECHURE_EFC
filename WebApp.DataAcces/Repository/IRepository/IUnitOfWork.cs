namespace WebApp.DataAcces.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository _categoryRepository { get; }

        void Save();
    }
}
