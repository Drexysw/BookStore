using BookStore.Core.Models.Category;

namespace BookStore.Core.Models.Book
{
    public class BookFormModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; } 

        public IEnumerable<BookCategoryServiceModel> Categories { get; set; } = new List<BookCategoryServiceModel>();
    }
}
