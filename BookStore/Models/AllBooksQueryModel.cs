using OnlineBookstoreManagementSystem.Core.Models.Book;
using System.ComponentModel.DataAnnotations;
using static BookStore.Core.Constants.MessageConstants;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Core.Models.Book
{
    public class AllBooksQueryModel
    {
        public const int BooksPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public BookSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalBooksCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<BooksAllServiceModel> Books { get; set; } = Enumerable.Empty<BooksAllServiceModel>();
    }
}
