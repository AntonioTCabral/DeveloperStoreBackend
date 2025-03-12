namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

public class GetProductsByCategoryRequest
{
    public string Category { get; set; } = string.Empty;
    public string Order { get; set; } = "ASC";
}