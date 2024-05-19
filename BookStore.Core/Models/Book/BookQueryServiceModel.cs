using OnlineBookstoreManagementSystem.Core.Models.Book;

namespace BookStore.Core.Models.Book
{
    public class BookQueryServiceModel
    {
        public int TotalBooksCount { get; set; }

        public IEnumerable<BooksAllServiceModel> Books { get; set; }
        = new List<BooksAllServiceModel>();
    }
}
