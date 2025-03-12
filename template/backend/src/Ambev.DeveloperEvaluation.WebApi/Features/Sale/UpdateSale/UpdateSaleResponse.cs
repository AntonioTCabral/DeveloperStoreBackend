using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

/// <summary>
/// API response model for UpdateCart operation.
/// </summary>
public class UpdateSaleResponse
{ public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItemValueObject> SaleItems { get; set; } = new();
}