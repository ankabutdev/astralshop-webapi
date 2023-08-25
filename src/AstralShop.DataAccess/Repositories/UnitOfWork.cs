using AstralShop.DataAccess.Contexts;
using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Domain.Entities.Deliveries;
using AstralShop.Domain.Entities.Discounts;
using AstralShop.Domain.Entities.Orders;
using AstralShop.Domain.Entities.Products;
using AstralShop.Domain.Entities.Users;

namespace AstralShop.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AstralShopDbContext dbContext;

    public UnitOfWork(AstralShopDbContext dbContext)
    {
        this.dbContext = dbContext;

        CategoryRepository = new BaseRepository<Category>(dbContext);
        CompanyRepository = new BaseRepository<Company>(dbContext);
        DeliverRepository = new BaseRepository<Deliver>(dbContext);
        DiscountRepository = new BaseRepository<Discount>(dbContext);
        OrderRepository = new BaseRepository<Order>(dbContext);
        OrderDetailsRepository = new BaseRepository<OrderDetails>(dbContext);
        ProductRepository = new BaseRepository<Product>(dbContext);
        ProductCommentRepository = new BaseRepository<ProductComment>(dbContext);
        ProductDiscountRepository = new BaseRepository<ProductDiscount>(dbContext);
        ProductSupplierRepository = new BaseRepository<ProductSupplier>(dbContext);
        UserRepository = new BaseRepository<User>(dbContext);
    }

    public IRepository<Category> CategoryRepository { get; }

    public IRepository<Company> CompanyRepository { get; }

    public IRepository<Deliver> DeliverRepository { get; }

    public IRepository<Discount> DiscountRepository { get; }

    public IRepository<Order> OrderRepository { get; }

    public IRepository<OrderDetails> OrderDetailsRepository { get; }

    public IRepository<Product> ProductRepository { get; }

    public IRepository<ProductComment> ProductCommentRepository { get; }

    public IRepository<ProductDiscount> ProductDiscountRepository { get; }

    public IRepository<ProductSupplier> ProductSupplierRepository { get; }

    public IRepository<User> UserRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveAsync() =>
        await dbContext.SaveChangesAsync() > 0;
}
