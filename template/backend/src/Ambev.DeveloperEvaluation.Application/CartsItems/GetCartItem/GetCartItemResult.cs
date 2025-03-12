namespace Ambev.DeveloperEvaluation.Application.CartsItems.GetCartItem;

/// <summary>
/// Response model for GetCartItem operation
/// </summary>
public class GetCartItemResult
{
    /// <summary>
    /// The unique identifier of the cart item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique identifier of the cart this item belongs to
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// The unique identifier of the product in the cart
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in the cart
    /// </summary>
    public int Quantity { get; set; }

}