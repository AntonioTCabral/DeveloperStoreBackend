namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

/// <summary>
/// Represents a request to add an item to a cart.
/// </summary>
public class CreateCartItemRequest
{
    /// <summary>
    /// Gets or sets the cart ID.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    public int Quantity { get; set; }
}