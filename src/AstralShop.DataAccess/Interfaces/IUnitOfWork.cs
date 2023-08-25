using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Domain.Entities.Deliveries;
using AstralShop.Domain.Entities.Discounts;
using AstralShop.Domain.Entities.Orders;
using AstralShop.Domain.Entities.Products;
using AstralShop.Domain.Entities.Users;

namespace AstralShop.DataAccess.Interfaces;

public interface IUnitOfWork
{
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

    public Task<bool> SaveAsync();
}