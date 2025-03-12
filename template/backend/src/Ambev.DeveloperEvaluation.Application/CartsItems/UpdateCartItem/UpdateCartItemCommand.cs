using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.UpdateCartItem;

/// <summary>
/// Command for updating a cart item.
/// </summary>
public class UpdateCartItemCommand : IRequest<UpdateCartItemResult>
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}