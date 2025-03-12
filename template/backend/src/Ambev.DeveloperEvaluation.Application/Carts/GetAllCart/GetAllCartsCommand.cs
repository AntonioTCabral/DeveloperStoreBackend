using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    /// <summary>
    /// Command for retrieving all carts with pagination and ordering
    /// </summary>
    public record GetAllCartsCommand(string Order) : IRequest<GetAllCartsResult>;
}