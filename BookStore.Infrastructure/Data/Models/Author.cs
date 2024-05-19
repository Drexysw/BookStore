using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Infrastructure.Data.Models
{
    public class Author
    {
        [Key]
        [Comment("Author's identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Author's name")]
        [MaxLength(AuthorNameMaxLenght)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Comment("Author's authobriography")]
        [MaxLength(AuthobriographyMaxLenght)]
        public string Authobriography { get; set; } = string.Empty;
        [Comment("Author's age")]
        public int Age { get; set; }
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}