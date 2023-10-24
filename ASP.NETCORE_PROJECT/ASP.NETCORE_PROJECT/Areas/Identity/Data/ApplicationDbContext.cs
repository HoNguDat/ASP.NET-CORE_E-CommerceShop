using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using ASP.NETCORE_PROJECT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ASP.NETCORE_PROJECT.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        modelBuilder.Entity<Category>()
             .HasMany(c => c.Products)
             .WithOne(p => p.Category)
             .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Brand>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId);

        modelBuilder.Entity<TypeLaptop>()
           .HasMany(c => c.Products)
           .WithOne(p => p.TypeLaptop)
           .HasForeignKey(p => p.TypeId);

        modelBuilder.Entity<Product>()
            .HasMany(c => c.Comments)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<ApplicationUser>()
          .HasMany(c => c.Comments)
          .WithOne(p => p.ApplicationUser)
          .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(c => c.Orders)
            .WithOne(p => p.ApplicationUser)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Order>()
            .HasMany(c => c.OrderDetails)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId);

        modelBuilder.Entity<Product>()
            .HasMany(c => c.OrderDetails)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);
    }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<TypeLaptop> TypeLaptop { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
}
