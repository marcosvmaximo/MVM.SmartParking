using System.Linq.Expressions;

namespace MVM.SmartParking.Data.Core;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T?>> GetByFilter(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T?>> GetAll();
    Task<T?> GetById(Guid id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}