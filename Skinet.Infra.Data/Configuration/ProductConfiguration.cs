using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Domain.Product;

namespace Skinet.Infra.Data.Configuration
{
  public class ProductConfiguration: IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
      builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
      builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
      builder.Property(p => p.PictureUrl).IsRequired();
      builder.HasOne(b => b.ProductBrand).WithMany();
      builder.HasOne(b => b.ProductType).WithMany();
    }
  }
}