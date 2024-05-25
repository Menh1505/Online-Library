using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach(var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if(tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    }
    public DbSet<Book> Books { get; set;}
    public DbSet<BookCategory> BookCategories {get; set;}   
    public DbSet<BookPrice> BookPrices { get; set;}
    public DbSet<Category> Categories { get; set;}
    public DbSet<Discount> Discounts{ get; set;}
    public DbSet<Inventory> Inventories { get; set;}
    public DbSet<Warehouse> Warehouses { get; set;}
}
