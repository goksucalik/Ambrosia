using Ambrosia.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambrosia.Data.Concrete.EntityFramework.Mappings
{
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Count).IsRequired().HasColumnType("int");
            builder.HasOne<Product>(b => b.Product).WithMany(p => p.Basket).HasForeignKey(b => b.ProductId);
            builder.HasOne<User>(b => b.User).WithMany(u => u.Basket).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.CreatedName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.ModifiedName).IsRequired().HasMaxLength(50);
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.ToTable("Basket");

        }
    }
}
