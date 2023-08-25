using AstralShop.Domain.Entities;
using System.Linq.Expressions;

namespace AstralShop.DataAccess.Interfaces;

public interface IRepository<T> where T : Auditable
{
    public Task<bool> CreateAsync(T entity);

    public Task<bool> UpdateAsync(T entity);

    public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);

    public Task<T> SelectAsync(Expression<Func<T, bool>> expression);

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null!);

    public Task SaveAsync();
}