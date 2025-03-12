namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCreatedEvent
{
    public Guid SaleId { get; set; }
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
}