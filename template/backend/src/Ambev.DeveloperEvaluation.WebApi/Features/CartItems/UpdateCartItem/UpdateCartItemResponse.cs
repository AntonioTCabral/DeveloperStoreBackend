namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// API response model for UpdateCartItem operation.
/// </summary>
public class UpdateCartItemResponse
{
    /// <summary>
    /// The unique identifier of the cart item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The updated quantity of the product.
    /// </summary>
    public int Quantity { get; set; }
}