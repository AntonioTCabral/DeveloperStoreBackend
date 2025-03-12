using Ambev.DeveloperEvaluation.Application.Products.GetAllProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetByCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

/// <summary>
/// Profile for mapping GetProductsByCategory feature requests to commands.
/// </summary>
public class GetProductsByCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProductsByCategory feature.
    /// </summary>
    public GetProductsByCategoryProfile()
    {
        CreateMap<GetProductsByCategoryRequest, GetByCategoryCommand>();
        CreateMap<GetAllProductResult, GetProductsByCategoryResponse>();
    }
}