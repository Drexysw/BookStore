using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.SeedDb
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            var data = new SeedData();
            builder.HasData(new Seller[] {data.Seller});
        }
    }
}
