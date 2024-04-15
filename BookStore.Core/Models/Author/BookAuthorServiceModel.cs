using System.ComponentModel.DataAnnotations;
using static BookStore.Core.Constants.MessageConstants;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Core.Models.Author
{
    public class BookAuthorServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AuthorNameMaxLenght, MinimumLength =AuthobriographyMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "Author Name")]
        public string Name { get; set; } = string.Empty;
    }
}
