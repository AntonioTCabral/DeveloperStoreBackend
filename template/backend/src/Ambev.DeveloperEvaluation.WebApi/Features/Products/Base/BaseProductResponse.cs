using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Base;

public class BaseResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Description { get; set; } 
    public decimal Price { get; set; }
    public string Image { get; set; } 
    public string Category { get; set; } 
    public RatingValueObject RatingValueObject { get; set; }
}