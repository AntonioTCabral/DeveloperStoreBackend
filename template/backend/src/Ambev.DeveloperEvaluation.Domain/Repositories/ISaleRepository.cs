using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository : IBaseRepository<Sale>
{
   Task<int> GetLastSaleNumberAsync();
   Task<Sale?> GetWithIncludeAsync(Guid id, CancellationToken cancellationToken = default);
}