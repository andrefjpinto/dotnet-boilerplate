using System.Linq.Expressions;
using dotnet_boilerplate.Models;

namespace dotnet_boilerplate.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
   Task<IEnumerable<T>> GetAllAsync();
   Task<T> GetByIdAsync(Guid id);
   void Add(T entity);
   Task<bool> SaveChangesAsync();
   Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
}
