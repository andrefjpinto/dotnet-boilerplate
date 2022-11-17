using System.Linq.Expressions;
using dotnet_boilerplate.Data;
using dotnet_boilerplate.Interfaces;
using dotnet_boilerplate.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_boilerplate.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> FindAllAsync() => await _entities.ToListAsync();
    public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) =>
        await _entities.Where(expression).AsNoTracking().ToListAsync();
    public void Create(T entity) => _entities.Add(entity);
    public void Update(T entity) => _entities.Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
    public async Task<bool> SaveChangesAsync() => 
        (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
}