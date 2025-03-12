using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<Cart?> GetWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts.Include(x => x.Items).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        return cart;
    }

    public Task<IQueryable<Cart>> GetAllWithIncludeAsync(string orderBy)
    {
        var carts = _context.Carts.Include(x => x.Items).AsNoTracking().AsQueryable();
        
        if(!string.IsNullOrWhiteSpace(orderBy))
            carts = carts.OrderBy(orderBy);
        
        return Task.FromResult(carts);
    }
}