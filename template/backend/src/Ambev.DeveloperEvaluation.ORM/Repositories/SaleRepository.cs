using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    public SaleRepository(DefaultContext context) : base(context)
    {
    }

   public async Task<int> GetLastSaleNumberAsync()
   {
       return await _context.Sales.AnyAsync()
           ? await _context.Sales.MaxAsync(s => s.SaleNumber)
           : 0;
   }

   public async Task<Sale?> GetWithIncludeAsync(Guid id, CancellationToken cancellationToken = default)
   {
       return await _context.Sales
           .Include(s => s.Customer)
           .Include(s => s.Branch)
           .Include(s => s.SaleItems)
           .ThenInclude(si => si.Product)
           .AsNoTracking()
           .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
   }
}