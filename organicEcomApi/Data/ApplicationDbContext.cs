using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using organicEcomApi.Models;

namespace organicEcomApi.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CatergoryId });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(p => p.Product)
            .WithMany(pc => pc.ProductCategories)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<ProductCategory>()
           .HasOne(c => c.Category)
           .WithMany(pc => pc.ProductCategories)
           .HasForeignKey(c => c.CatergoryId);
    }

}
