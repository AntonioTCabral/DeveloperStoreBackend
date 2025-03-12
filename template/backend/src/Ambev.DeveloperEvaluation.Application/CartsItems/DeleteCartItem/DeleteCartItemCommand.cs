using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartsItems.DeleteCartItem;

/// <summary>
/// Command for deleting a cart item
/// </summary>
public record DeleteCartItemCommand(Guid Id) : IRequest;