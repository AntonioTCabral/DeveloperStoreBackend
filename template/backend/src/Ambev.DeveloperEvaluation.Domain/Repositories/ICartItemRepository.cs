using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task<IQueryable<CartItem>> GetAllByCartIdAsync(string? orderBy, Guid cartId);
}