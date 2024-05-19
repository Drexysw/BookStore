using BookStore.Core.Contracts;
using BookStore.Core.Models.Author;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository repository;
        public AuthorService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> AuthorExist(int id)
        {
            return await repository.AllReadOnly<Author>()
                .AnyAsync(a => a.Id == id);
        }

        public async Task CreateAsync(BookFormAuthorServiceModel model)
        {
            var author = new Author()
            {
                Name = model.Name,
                Authobriography = model.Authobriography,
                Age = model.Age,
            };
            try
            {
                await repository.AddAsync(author);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<int> GetAuthorIdByName(string name)
        {
            return await repository.AllReadOnly<Author>()
                 .Where(b => b.Name == name)
                 .Select(b => b.Id)
                 .SingleAsync();

        }
    }
}
