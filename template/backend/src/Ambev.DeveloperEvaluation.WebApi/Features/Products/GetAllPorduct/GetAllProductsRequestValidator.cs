using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllPorduct.Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllPorduct;

/// <summary>
/// Validator for GetAllProductsRequest.
/// </summary>
public class GetAllProductsRequestValidator : AbstractValidator<GetAllProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetAllProductsRequest.
    /// </summary>
    public GetAllProductsRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("Size must be greater than zero.");
    }
}