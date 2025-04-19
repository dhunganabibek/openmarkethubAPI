using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using openmarkethubAPI.Entities;

namespace openmarkethubAPI.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> modelBuilder)
    {
        modelBuilder
            .HasKey(x => x.ProductID);

        modelBuilder
            .Property(x => x.ProductID)
            .ValueGeneratedOnAdd();

        modelBuilder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        modelBuilder
            .Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);
    }
}