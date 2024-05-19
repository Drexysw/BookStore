using BookStore.Core.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Contracts
{
    public interface IAuthorService
    {
        Task<int> GetAuthorIdByName(string name);

        Task CreateAsync(BookFormAuthorServiceModel model);

        Task<bool> AuthorExist(int id);
    }
}
