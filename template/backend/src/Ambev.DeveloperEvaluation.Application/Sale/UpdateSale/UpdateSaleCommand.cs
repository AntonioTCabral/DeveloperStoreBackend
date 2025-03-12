using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItemValueObject> SaleItems { get; set; } = new();
}