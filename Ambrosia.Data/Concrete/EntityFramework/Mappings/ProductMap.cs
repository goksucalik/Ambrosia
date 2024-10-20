using Ambrosia.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambrosia.Data.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(75).IsRequired();
            builder.Property(p => p.Content).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal");
            builder.Property(p => p.Thumbnail).IsRequired().HasMaxLength(250);
            builder.Property(p => p.CommentCount).IsRequired();
            builder.Property(p => p.SeoAuthor).IsRequired().HasMaxLength(50);
            builder.Property(p => p.SeoDescription).IsRequired().HasMaxLength(250);
            builder.Property(p => p.SeoTags).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.CreatedName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ModifiedName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasOne<User>(p => p.User).WithMany(u => u.Products).HasForeignKey(p => p.UserId);
            builder.ToTable("Products");

            
        }
    }
}
