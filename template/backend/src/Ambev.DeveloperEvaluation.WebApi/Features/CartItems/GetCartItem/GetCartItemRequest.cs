namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

/// <summary>
/// Request model for getting a cart item by ID.
/// </summary>
public class GetCartItemRequest
{
    /// <summary>
    /// The unique identifier of the cart item to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}