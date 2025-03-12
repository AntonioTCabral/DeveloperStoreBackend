using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.CreateCartItem;

/// <summary>
/// Validator for CreateCartItemRequest that defines validation rules for cart items.
/// </summary>
public class CreateCartItemRequestValidator : AbstractValidator<CreateCartItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartItemRequestValidator with defined validation rules.
    /// </summary>
    public CreateCartItemRequestValidator()
    {
        RuleFor(item => item.CartId)
            .NotEmpty().WithMessage("Cart ID is required.");

        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}