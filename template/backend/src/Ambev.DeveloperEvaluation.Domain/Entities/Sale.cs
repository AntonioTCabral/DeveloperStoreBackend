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
    public DateTime? UpdateAt { get; set; }
    public DateTime? CanceledAt { get; set; }
    
    public Customer Customer { get; set; }
    public Branch Branch { get; set; }
    
    public void Cancel()
    {
        IsCancelled = true;
        CanceledAt = DateTime.UtcNow;
    }
    
    public void Update(Sale sale)
    {
        SaleNumber = sale.SaleNumber;
        SaleDate = sale.SaleDate;
        CustomerId = sale.CustomerId;
        TotalAmount = sale.TotalAmount;
        BranchId = sale.BranchId;
        IsCancelled = sale.IsCancelled;
        SaleItems = sale.SaleItems;
        UpdateAt = DateTime.UtcNow;
    }

}