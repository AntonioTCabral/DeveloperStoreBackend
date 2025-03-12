using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;

public record GetAllProductsCommand(string Order) : IRequest<GetAllProductResult>;