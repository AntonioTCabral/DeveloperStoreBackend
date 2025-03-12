using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

/// <summary>
/// API response model for GetProductsByCategory operation.
/// </summary>
public class GetProductsByCategoryResponse
{
    public List<ProductDTO> Data { get; set; } = new();
}