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

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _entities.SingleOrDefaultAsync(s => s.Id.Equals(id));
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
    }

    public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }
}