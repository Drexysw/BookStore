namespace BookStore.Core.Models.Book
{
    public class BookDetailsServiceModel : BookServiceModel
    {
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Seller { get; set; } = string.Empty;
    }
}
