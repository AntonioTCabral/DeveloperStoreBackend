using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetProduct;

public class GetProductCommand : IRequest<GetProductResult>
{
    public Guid Id { get; set; }
}