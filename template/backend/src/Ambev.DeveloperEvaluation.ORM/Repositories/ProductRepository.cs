using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context)
    {
    }

    public Task<IQueryable<Product>> GetByCategoryAsync(string category, string orderBy, CancellationToken cancellationToken = default)
    {
        var query = _context.Products.Where(p => p.Category == category).AsQueryable();
        
        if (!string.IsNullOrEmpty(orderBy))
            query = query.OrderBy(orderBy);
        
        return Task.FromResult(query);
    }

    public async Task<IEnumerable<string>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Select(p => p.Category)
            .Distinct()
            .ToListAsync(cancellationToken);
    }
}