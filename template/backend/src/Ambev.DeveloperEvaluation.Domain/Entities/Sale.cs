using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int SaleNumber { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    
    public Customer Customer { get; set; }
    public Branch Branch { get; set; }

}