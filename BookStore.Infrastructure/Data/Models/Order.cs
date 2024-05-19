using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Infrastructure.Data.Models
{
    public class Order
    {
        public string BuyerId { get; set; } = string.Empty;
        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser Buyer { get; set; } = null!;

        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}