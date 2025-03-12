using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

public class GetSaleResponse
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public Guid BranchId { get; set; }
    public string IsCancelled { get; set; } = string.Empty;
    public List<SaleItemValueObject> Items { get; set; } = new();
}