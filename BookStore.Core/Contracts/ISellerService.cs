using BookStore.Core.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Contracts
{
    public interface ISellerService
    {
        Task<bool> ExistsById(string userId);


        Task<bool> UserHasBuys(string userId);

        Task Create(string userId, string phoneNumber);

        Task<int> GetSellerId(string userId);

        
    }
}
