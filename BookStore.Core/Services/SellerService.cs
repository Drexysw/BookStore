using BookStore.Core.Contracts;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Services
{
    public class SellerService : ISellerService
    {
        private readonly IRepository repository;
        public SellerService(IRepository _repository)
        {
            repository = _repository;
        }
        public async  Task Create(string userId, string name)
        {
            var seller = new Seller()
            {
                UserId = userId,
                Name = name
            };

            await repository.AddAsync(seller);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Seller>()
                .AnyAsync(s => s.UserId == userId);
        }

        public async Task<int> GetSellerId(string userId)
        {
            return (await repository.AllReadOnly<Seller>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserHasBuys(string userId)
        {
            return await repository.All<Book>()
                .AnyAsync(h => h.BuyerId == userId);
        }
    }
}
