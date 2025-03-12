using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetByCategory;

/// <summary>
/// Validator for GetProductsByCategoryRequest.
/// </summary>
public class GetProductsByCategoryRequestValidator : AbstractValidator<GetProductsByCategoryRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductsByCategoryRequest.
    /// </summary>
    public GetProductsByCategoryRequestValidator()
    {
        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.");
    }
}