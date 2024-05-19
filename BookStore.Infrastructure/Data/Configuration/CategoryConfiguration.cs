using BookStore.Infrastructure.Data.Configuration;
using BookStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.SeedDb
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();
            builder.HasData(new Category[] { data.NovelCategory, data.PsychologyCategory, data.ThrillerCategory });
        }
    }
}
