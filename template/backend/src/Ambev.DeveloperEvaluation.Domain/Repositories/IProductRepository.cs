using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
   Task<IQueryable<Product>> GetByCategoryAsync(string category, string? orderBy, CancellationToken cancellationToken = default);
   Task<IEnumerable<string>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
}