using System.ComponentModel.DataAnnotations;
using static BookStore.Core.Constants.MessageConstants;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Core.Models.Book
{
    public class BookServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght, ErrorMessage = LenghtMessage)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}