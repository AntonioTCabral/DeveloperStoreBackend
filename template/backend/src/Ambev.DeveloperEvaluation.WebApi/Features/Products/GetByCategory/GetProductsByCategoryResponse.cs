using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Products;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

/// <summary>
/// API response model for GetProductsByCategory operation.
/// </summary>
public class GetProductsByCategoryResponse
{
    public List<ProductDTO> Data { get; set; } = new();
}