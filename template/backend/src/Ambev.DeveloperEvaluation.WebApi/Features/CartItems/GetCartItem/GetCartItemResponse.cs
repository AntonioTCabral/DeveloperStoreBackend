using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.GetCartItem;

/// <summary>
/// API response model for GetCartItem operation.
/// </summary>
public class GetCartItemResponse
{
    /// <summary>
    /// The unique identifier of the cart item.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique identifier of the cart that this item belongs to.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The unique identifier of the product associated with this cart item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in the cart.
    /// </summary>
    public int Quantity { get; set; }
   
}