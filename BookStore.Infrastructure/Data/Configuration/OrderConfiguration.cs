using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBookstoreManagementSystem.Infrastructure.Data.Models;

namespace OnlineBookstoreManagementSystem.Infrastructure.Data.SeedDb
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
