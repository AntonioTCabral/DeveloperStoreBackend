using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    public Product Product { get; set; }
    
    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}