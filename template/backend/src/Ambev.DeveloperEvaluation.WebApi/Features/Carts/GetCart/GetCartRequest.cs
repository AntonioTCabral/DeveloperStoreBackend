namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// Request model for getting a cart by ID
/// </summary>
public record GetCartRequest(Guid Id);