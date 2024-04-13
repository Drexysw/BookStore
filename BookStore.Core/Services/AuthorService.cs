using BookStore.Core.Contracts;
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
        public async Task<int> GetAuthorIdByName(string name)
        {
            return await repository.AllReadOnly<Author>()
                 .Where(b => b.Name == name)
                 .Select(b => b.Id)
                 .SingleAsync();

        }
    }
}
