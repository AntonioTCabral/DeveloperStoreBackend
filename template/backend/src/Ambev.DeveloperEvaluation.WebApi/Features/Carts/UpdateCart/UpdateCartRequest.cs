using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;
using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

// <summary>
/// API request model for updating a cart.
/// </summary>
public class UpdateCartRequest
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<UpdateCartItemRequest> Items { get; set; } = new();
}