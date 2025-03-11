namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public Guid CustomerId { get; set; }
    public Guid CartId { get; set; }
    public Guid BranchId { get; set; }
}