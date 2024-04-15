using System.ComponentModel.DataAnnotations;
using static BookStore.Core.Constants.MessageConstants;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Core.Models.Author
{
    public class BookFormAuthorServiceModel 
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AuthorNameMaxLenght, MinimumLength = AuthorNameMinLenght, ErrorMessage = LenghtMessage)]
        [Display(Name = "Author Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage =RequiredMessage)]
        [StringLength(AuthobriographyMaxLenght, MinimumLength =AuthobriographyMinLenght,ErrorMessage = LenghtMessage)]    
        public string Authobriography { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessage)]
        public int Age { get; set; }
    }
}
