using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesCommand, GetCategoriesResult>
{
    private readonly IProductRepository _productRepository;

    public GetCategoriesHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetCategoriesResult> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetAllCategoriesAsync(cancellationToken);
        return new GetCategoriesResult(categories);
    }
}