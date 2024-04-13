using BookStore.Core.Models.Category;
using System.ComponentModel.DataAnnotations;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
using static BookStore.Core.Constants.MessageConstants;
using BookStore.Core.Models.Author;
namespace BookStore.Core.Models.Book
{
    public class BookFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "Book's Title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght, ErrorMessage =LenghtMessage)]
        [Display(Name ="Book's Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Price of the book")]
        [Range(BookPriceMinimumValue, BookPriceMaximumValue, ErrorMessage = PriceMessage)]
        public decimal Price { get; set; }
        [Display(Name = "Books' Author")]
        public string Author { get; set; } = string.Empty;
        [Display(Name = "Book's Category")]
        public int CategoryId { get; set; }

        public IEnumerable<BookCategoryServiceModel> Categories { get; set; } = new List<BookCategoryServiceModel>();
    }
}
