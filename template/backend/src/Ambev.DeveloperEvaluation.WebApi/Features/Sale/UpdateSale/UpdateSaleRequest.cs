using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;

// <summary>
/// API request model for updating a cart.
/// </summary>
public class UpdateSaleRequest
{
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItemValueObject> SaleItems { get; set; } = new();
}