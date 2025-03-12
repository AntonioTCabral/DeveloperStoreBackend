using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleItemValueObject> SaleItems { get; set; } = new();
}