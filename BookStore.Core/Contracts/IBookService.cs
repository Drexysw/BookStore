using BookStore.Core.Models.Author;
using BookStore.Core.Models.Book;
using BookStore.Core.Models.Category;
using OnlineBookstoreManagementSystem.Core.Models.Book;

namespace BookStore.Core.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<BookServiceModel>> LastThreeBooksAsync();
        public Task<IEnumerable<BooksAllServiceModel>> AllBooksAsync();
        public Task<IEnumerable<BookCategoryServiceModel>> AllCategoriesAsync();
        public Task<BookQueryServiceModel> AllAsync(
              string? category = null,
              string? searchTerm = null,
              BookSorting sorting = BookSorting.Newest,
              int currentPage = 1,
              int housesPerPage = 1);
        public Task<IEnumerable<string>> AllCategoriesNameAsync();

        public Task<bool> ExistByIdAsync(int id);
        public Task<BookDetailsServiceModel> BookDetailsByIdAsync(int id);

        public Task<int> CreateAsync(BookFormModel model, int sellerId);
        public Task<bool> AuthorExist(string name);

        public Task<bool> CategoryExist(int id);

        public Task<bool> IsBought(int id);

        Task<bool> IsBoughtByUserWithId(int houseId, string currentUserId);

        public Task Buy(int houseId, string currentUserId);

        public Task<IEnumerable<BookDetailsServiceModel>> AllBooksByUserIdAsync(string userId);
        Task<IEnumerable<BookDetailsServiceModel>> AllBooksBySellerId(int sellerId);

        public Task Edit(int bookId,  BookFormModel model);

        public Task<bool> HasSellerWithId(int bookId, string currentUserId);  

        public Task<int> GetBookCategoryId(int bookId);
        
    }
}
