
namespace Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;

/// <summary>
/// Represents the response returned after updating a cart item.
/// </summary>
public class UpdateCartItemResult
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}