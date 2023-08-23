using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Domain.Entities.Deliveries;
using AstralShop.Domain.Entities.Discounts;
using AstralShop.Domain.Entities.Orders;
using AstralShop.Domain.Entities.Products;
using AstralShop.Domain.Entities.Suppliers;
using AstralShop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AstralShop.DataAccess.Contexts;

public class AstralShopDbContext : DbContext
{
    public AstralShopDbContext(DbContextOptions<AstralShopDbContext> options) : base(options)
    { }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Deliver> Delivers { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<User> Users { get; set; }
}
