using BookStore.Core.Contracts.Admin;
using BookStore.Core.Models.Admin;
using BookStore.Infrastructure.Common;
using BookStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Core.Services.Admin
{
    public class UserService : IUserService
    {

        private readonly IRepository repository;

        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Seller)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Seller != null ? u.Seller.PhoneNumber : null,
                    IsAgent = u.Seller != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository
                .GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
