using System.Linq.Expressions;

namespace Porsche.Domain.Abstractions;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(
        params Expression<Func<T, object>>[] includes);

    Task<List<T>> GetByConditionsAsync(
        Expression<Func<T, bool>> expression,
        params Expression<Func<T, object>>[] includes);

    Task<T?> GetSingleByConditionAsync(
        Expression<Func<T, bool>> expression,
        params Expression<Func<T, object>>[] includes);

    Task InsertAsync(T entity);
    Task InsertRangeAsync(List<T> entities);
    void Update(T entity);
    Task Delete(Guid id);
    void Delete(T entity);
}