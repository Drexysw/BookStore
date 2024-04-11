using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.SeedDb
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => new { o.BuyerId, o.BookId });

            builder
                .HasOne(o => o.Book)
                .WithMany(o => o.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
