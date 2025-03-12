namespace Ambev.DeveloperEvaluation.Application.CartsItems.CreateCartItem;

/// <summary>
/// Represents the response returned after adding an item to a cart.
/// </summary>
public class CreateCartItemResult
{
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}