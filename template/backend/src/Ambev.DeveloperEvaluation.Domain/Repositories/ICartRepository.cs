using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart?> GetWithItemsAsync(Guid id, CancellationToken cancellationToken = default);
}