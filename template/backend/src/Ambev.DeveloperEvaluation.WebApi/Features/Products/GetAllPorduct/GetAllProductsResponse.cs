using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllPorduct;

public class GetAllProductsResponse
{
    public IQueryable<ProductDTO> Data { get; set; }
}