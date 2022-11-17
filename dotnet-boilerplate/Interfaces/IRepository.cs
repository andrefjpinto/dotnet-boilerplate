using System.Linq.Expressions;
using dotnet_boilerplate.Models;

namespace dotnet_boilerplate.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> FindAllAsync();
    Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
}