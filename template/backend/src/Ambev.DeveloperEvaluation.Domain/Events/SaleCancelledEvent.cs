namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleCancelledEvent
{
    public Guid SaleId { get; set; }
    public DateTime CancelledAt { get; set; } = DateTime.UtcNow;
}
