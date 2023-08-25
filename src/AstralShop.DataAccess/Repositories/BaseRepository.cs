using AstralShop.DataAccess.Contexts;
using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    public async Task<T> AddAsync(T entity)
    {
        await table.AddAsync(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await SelectAsync(expression);
        if (entity is not null)
        {
            table.Remove(entity);
            return true;
        }
        return false;
    }

#pragma warning disable
    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression)
    {
        return await table.FirstOrDefaultAsync(expression);
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null!)
    {
        var query = this.table;
        return query;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        EntityEntry<T> entry = this.table.Update(entity);
        return entry.Entity;
    }

    public async Task<long> CountAsync() => 
        await table.LongCountAsync();

    public async Task SaveAsync() => 
        await dbContext.SaveChangesAsync();
}
