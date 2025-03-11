using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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
}