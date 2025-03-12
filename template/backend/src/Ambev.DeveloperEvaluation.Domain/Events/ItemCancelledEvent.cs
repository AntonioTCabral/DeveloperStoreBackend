namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ItemCancelledEvent
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CancelledAt { get; set; } = DateTime.UtcNow;
}