using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(DefaultContext context) : base(context)
    {
    }

    public Task<IQueryable<CartItem>> GetAllByCartIdAsync(string? orderBy,Guid cartId)
    {
        var items = _context.CartItems.Where(i => i.CartId == cartId).AsNoTracking();
        
        if (!string.IsNullOrWhiteSpace(orderBy))
        {
            items = items.OrderBy(orderBy);
        }

        return Task.FromResult(items);
    }
}