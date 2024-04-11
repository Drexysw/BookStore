using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Infrastructure.Data.Models
{
    public class Seller
    {
        [Key]
        [Comment("Seller's identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(SellerNameMaxLengh)]
        [Comment("Seller's name")]
        public string Name { get; set; } = string.Empty;
        [Comment("Seller's rating")]
        public double Rating { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}