using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetByCategory;

public record GetByCategoryCommand(string Category, string Order) : IRequest<GetAllProductResult>;