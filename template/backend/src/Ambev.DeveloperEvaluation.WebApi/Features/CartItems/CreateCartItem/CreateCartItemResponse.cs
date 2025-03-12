namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

/// <summary>
/// API response model for CreateCartItem operation.
/// </summary>
public class CreateCartItemResponse
{
    /// <summary>
    /// The unique identifier of the cart item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The cart ID associated with this item.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The product ID.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product.
    /// </summary>
    public int Quantity { get; set; }
}