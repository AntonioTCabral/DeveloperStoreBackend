using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetProductCommand : IRequest<GetProductResult>
{
    public Guid Id { get; set; }
}