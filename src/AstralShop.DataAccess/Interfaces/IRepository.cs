using System.Linq.Expressions;

namespace AstralShop.DataAccess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<bool> CreateAsync(TEntity entity);

    public Task<bool> UpdateAsync(TEntity entity);

    public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

    public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null!);

    public Task SaveAsync();
}