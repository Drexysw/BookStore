namespace BookStore.Core.Contracts
{
    public interface ISellerService
    {
        Task<bool> ExistsById(string userId);


        Task<bool> UserHasBuys(string userId);

        Task Create(string userId, string phoneNumber, string name);

        Task<int> GetSellerId(string userId);
        Task<bool> UserWithPhoneNumberExists( string phoneNumber);


    }
}
