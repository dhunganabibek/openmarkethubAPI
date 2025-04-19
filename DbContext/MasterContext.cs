using Microsoft.EntityFrameworkCore;
using openmarkethubAPI.Configurations;
using openmarkethubAPI.Entities;

public class MasterContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations for entities
        modelBuilder
        .ApplyConfiguration(new ProductConfiguration());
    }
}