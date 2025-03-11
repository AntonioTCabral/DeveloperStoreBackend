using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; }
    public bool IsCancelled { get; set; }
    public ICollection<SaleItem> SaleItems { get; set; }
    
    public Customer Customer { get; set; }

}