using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;

/// <summary>
/// Validator for UpdateCartItemRequest that defines validation rules for cart items.
/// </summary>
public class UpdateCartItemRequestValidator : AbstractValidator<UpdateCartItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartItemRequestValidator with defined validation rules.
    /// </summary>
    public UpdateCartItemRequestValidator()
    {
        /*RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("ID is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");*/
    }
}