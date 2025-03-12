namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleModifiedEvent
{
    public Guid SaleId { get; set; }
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
}