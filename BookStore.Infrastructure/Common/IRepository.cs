namespace BookStore.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task<T> GetByIdsAsync<T>(object[] id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;

        void Delete<T>(T entity) where T : class;

        void Detach<T>(T entity) where T : class;
    }
}
