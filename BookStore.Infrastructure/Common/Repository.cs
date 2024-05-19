using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.Infrastructure.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;
        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return this.context.Set<T>();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            Delete<T>(entity);
        }

        public  void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

       
    }
}
