namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.DeleteCartItem;

/// <summary>
/// Request model for deleting a cart item
/// </summary>
public class DeleteCartItemRequest
{
    /// <summary>
    /// The unique identifier of the cart item to delete
    /// </summary>
    public Guid Id { get; set; }
}