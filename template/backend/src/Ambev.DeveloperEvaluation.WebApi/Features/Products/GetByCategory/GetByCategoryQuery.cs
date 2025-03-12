using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

/// <summary>
/// Query for retrieving products by category.
/// </summary>
public class GetByCategoryQuery : IRequest<List<GetProductsByCategoryResponse>>
{
    public string Category { get; set; }
}