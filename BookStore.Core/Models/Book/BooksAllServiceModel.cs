using System.ComponentModel.DataAnnotations;
using static BookStore.Core.Constants.MessageConstants;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace OnlineBookstoreManagementSystem.Core.Models.Book
{
    public class BooksAllServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "Book's Title")]
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Price of the book")]
        [Range(BookPriceMinimumValue, BookPriceMaximumValue, ErrorMessage = PriceMessage)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
