using Microsoft.EntityFrameworkCore;
using OnlineBookstoreManagementSystem.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookStore.Infrastructure.Data.Constants.DataConstants;
namespace BookStore.Infrastructure.Data.Models
{
    public class Book
    {
        [Key]
        [Comment("Book Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        [Comment("Book Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [Comment("Book Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Price of the book")]  
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Book Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public Seller Seller { get; set; } = null!;

        public string? BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser? Buyer { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        public bool IsAvailable { get; set; } = true;

    }
}
