using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DefaultContext _context;

    public BaseRepository(DefaultContext context)
    {
        _context = context;
        _context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return false;
        
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public Task<IQueryable<T>> GetAllAsync(string orderBy)
    {
        var entities = _context.Set<T>().AsNoTracking().AsQueryable();
        
        if (!string.IsNullOrEmpty(orderBy))
            entities = entities.OrderBy(orderBy);
        
        return Task.FromResult(entities);
    }
}