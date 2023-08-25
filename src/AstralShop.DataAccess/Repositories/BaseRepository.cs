using AstralShop.DataAccess.Contexts;
using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AstralShop.DataAccess.Repositories;

public class BaseRepository<T> : IRepository<T> where T : Auditable
{
    private readonly AstralShopDbContext dbContext;
    private readonly DbSet<T> table;

    public BaseRepository(AstralShopDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null!)
    {
        throw new NotImplementedException();
    }

    public Task<T> SelectAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
