using System.ComponentModel.DataAnnotations;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
using static BookStore.Core.Constants.MessageConstants;
namespace BookStore.Core.Models.Category
{
    public class BookCategoryServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BookCategoryNameMaxLenght,
            MinimumLength = BookCategoryNameminLenght,
            ErrorMessage = LenghtMessage)]
        public string Name { get; set; } = string.Empty;
    }
}