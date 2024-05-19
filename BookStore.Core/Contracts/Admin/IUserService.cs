using BookStore.Core.Models.Admin;

namespace BookStore.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> AllAsync();

    }
}
