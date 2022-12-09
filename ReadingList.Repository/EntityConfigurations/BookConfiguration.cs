using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingList.Repository.Entities;

namespace ReadingList.Repository.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(b => b.IsRead)
               .IsRequired();
            builder.Property(b => b.Order)
               .IsRequired();
            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}