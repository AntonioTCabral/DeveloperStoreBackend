namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// Represents a request to update an item in a cart.
/// </summary>
public class UpdateCartItemRequest
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