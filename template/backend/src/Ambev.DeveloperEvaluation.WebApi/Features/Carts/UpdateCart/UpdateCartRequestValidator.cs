using Ambev.DeveloperEvaluation.WebApi.Features.CartItems.UpdateCartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartRequest that defines validation rules for updating a cart.
/// </summary>
public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
    /// </summary>
    public UpdateCartRequestValidator()
    {
        RuleFor(cart => cart.Id)
            .NotEmpty().WithMessage("Cart ID is required.");

        RuleFor(cart => cart.UserId)
            .NotEmpty().WithMessage("User ID is required.");

        RuleFor(cart => cart.Items)
            .NotEmpty().WithMessage("Cart must contain at least one item.");

        RuleForEach(cart => cart.Items)
            .SetValidator(new UpdateCartItemRequestValidator());
    }
}